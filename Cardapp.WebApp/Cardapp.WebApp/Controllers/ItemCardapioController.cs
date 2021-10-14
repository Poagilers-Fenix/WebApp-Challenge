using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Cardapp.WebApp.Models;
using System;
using FireSharp.Interfaces;
using FireSharp.Config;
using FireSharp.Response;
using Cardapp.WebApp.SessionHelper;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;

namespace Cardapp.WebApp.Controllers
{
    public class ItemCardapioController : Controller
    {
        List<Item> items; 
        JObject json;

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "wvg4O1GNPzXqpGK95uGjhVValAjRiLX4iIM3P6YK",
            BasePath = "https://cardapp-d8eba-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient Client => new FireSharp.FirebaseClient(config);
        Estabelecimento Estab => HttpContext.Session.GetObjectFromJson<Estabelecimento>("EstabelecimentoSessao");
        private ISession _session => HttpContext.Session;
        private bool isNotLogged => Estab == null;


        private IActionResult isLogged(List<Item> items = null, Item item = null, String pag = null)
        {
            if (isNotLogged)
            {
                TempData["Erro"] = "Faça o login para acessar o sistema!";
                return RedirectToAction("Login", "Home");
            }
            if(items != null)
            {
                return View(items);
            }
            else if(item != null)
            {
                return View(item);
            }
            else
            {
                return View(pag);
            }
        }


        private void GetItems(string Categoria, bool Destaque = false)
        {
            items = new List<Item>();
            FirebaseResponse response = Client.Get("/itemCardapio/");
            if (response.Body != "null")
            {
                json = JObject.Parse(response.Body);
                foreach (var i in json)
                {
                    var item = i.Value.ToObject<Item>();
                    if (item.CodigoEstabelecimento == Estab.CodigoEstabelecimento)
                    {
                        if(Categoria != "None" && Categoria != "All")
                        {
                            if(item.Categoria == (CategoriaItem)Enum.Parse(typeof(CategoriaItem), Categoria))
                            {
                                items.Add(item);
                            }
                        }
                        else if(Destaque)
                        {
                            if(item.Destaque == 'S')
                            {
                                items.Add(item);
                            }
                        }
                        else if(Categoria == "All")
                        {
                            items.Add(item);
                        }
                    }
                }
                return;
            }
            json = null;
        }

        public IActionResult Index()
        {
            GetItems("None", true);
            return isLogged(items);
        }
        public IActionResult Pratos()
        {
            GetItems("Prato");
            return isLogged(items);
        }
        public IActionResult Bebidas()
        {
            GetItems("Bebida");
            return isLogged(items);
        }
        public IActionResult Lanches()
        {
            GetItems("Lanche");
            return isLogged(items);
        }
        public IActionResult Sobremesas()
        {
            GetItems("Sobremesa");
            return isLogged(items);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            ViewBag.status = new List<string>(new string[] { "S", "N" });
            return isLogged(null, null, "Cadastrar");
        }

        [HttpPost]
        public IActionResult Cadastrar(Item item)
        {
            if (ModelState.IsValid)
            {
                GetItems("All");
                try
                {
                    if (json != null)
                    {
                        foreach (var i in json)
                        {
                            var itemJson = i.Value.ToObject<Item>();
                            if (itemJson.Nome.ToLower() == item.Nome.ToLower())
                            {
                                TempData["Erro"] = "Um item com o nome '" + item.Nome + "' já está cadastrado!";
                                return RedirectToAction("Cadastrar");
                            }
                        }
                    }
                    item.CodigoEstabelecimento = Estab.CodigoEstabelecimento;
                    PushResponse response = Client.Push("itemCardapio/", item);
                    item.CodigoItem = response.Result.name;
                    SetResponse setResponse = Client.Set("itemCardapio/" + item.CodigoItem, item);
                    TempData["Sucesso"] = "Cadastrado com sucesso";
                    return RedirectToAction("Cadastrar");
                }
                catch (Exception)
                {
                    TempData["Erro"] = "Erro ao cadastrar";
                    return RedirectToAction("Cadastrar");
                }
            }
            TempData["Erro"] = "Erro ao cadastrar o item, cheque se as informações estão corretas e tente novamente.";
            ViewBag.status = new List<string>(new string[] { "S", "N" });
            return View();
        }

        [HttpGet]
        public IActionResult Editar(string id)
        {
            FirebaseResponse response = Client.Get("/itemCardapio/"+id);
            json = JObject.Parse(response.Body);
            var item = json.ToObject<Item>();
            ViewBag.status = new List<string>(new string[] { "S", "N" });
            return isLogged(null,item,null);
        }

        [HttpPost]
        public IActionResult Editar(Item item)
        {
            try
            {
                Client.Update("/itemCardapio/" + item.CodigoItem, item);
                TempData["Sucesso"] = "Item atualizado!";
                var categoria = item.Categoria.ToString();
                return categoria switch
                {
                    "Bebida" => RedirectToAction("Bebidas"),
                    "Sobremesa" => RedirectToAction("Sobremesas"),
                    "Prato" => RedirectToAction("Pratos"),
                    "Lanche" => RedirectToAction("Lanches"),
                    _ => RedirectToAction("Index"),
                };
            } catch (Exception)
            {
                TempData["Erro"] = "Não foi possível editar o item do cardápio.";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Remover(string id)
        {
            try
            {
                Client.Delete("/itemCardapio/"+id);
                TempData["Sucesso"] = "Item Removido!";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["Erro"] = "Erro ao remover";
                return RedirectToAction("Index");
            }

        }

        public IActionResult BuscarTodos(string nomeBusca)
        {
            GetItems("All");
            if (!string.IsNullOrEmpty(nomeBusca))
            {
                var filter = items.FindAll(i => i.Nome.ToLower().Contains(nomeBusca.ToLower()));
                ViewBag.nomeItem = nomeBusca;
                return View(filter);
            }

            return View(items);
        }

    }
}