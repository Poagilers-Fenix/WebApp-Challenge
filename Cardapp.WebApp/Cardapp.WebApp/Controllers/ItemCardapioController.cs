using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Cardapp.WebApp.Models;
using System;
using FireSharp.Interfaces;
using FireSharp.Config;
using FireSharp.Response;
using Cardapp.WebApp.SessionHelper;
using Newtonsoft.Json.Linq;

namespace Cardapp.WebApp.Controllers
{
    public class ItemCardapioController : Controller
    {
        List<Item> items; 
        Estabelecimento estab;
        JObject json;

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "wvg4O1GNPzXqpGK95uGjhVValAjRiLX4iIM3P6YK",
            BasePath = "https://cardapp-d8eba-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;

        private void GetItems(string Categoria, bool Destaque = false)
        {
            client = new FireSharp.FirebaseClient(config);
            items = new List<Item>();
            estab = HttpContext.Session.GetObjectFromJson<Estabelecimento>("EstabelecimentoSessao");
            FirebaseResponse response = client.Get("/itemCardapio/");
            if (response.Body != "null")
            {
                json = JObject.Parse(response.Body);
                foreach (var i in json)
                {
                    var item = i.Value.ToObject<Item>();
                    if (item.CodigoEstabelecimento == estab.CodigoEstabelecimento)
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
            if (HttpContext.Session.GetObjectFromJson<Estabelecimento>("EstabelecimentoSessao") == null)
            {
                TempData["Erro"] = "Faça o login para acessar o sistema!";
                return RedirectToAction("Login", "Home");
            }
            GetItems("None", true);
            return View(items);
        }
        public IActionResult Pratos()
        {
            if (HttpContext.Session.GetObjectFromJson<Estabelecimento>("EstabelecimentoSessao") == null)
            {
                TempData["Erro"] = "Faça o login para acessar o sistema!";
                return RedirectToAction("Login", "Home");
            }
            GetItems("Prato");
            return View(items);
        }
        public IActionResult Bebidas()
        {
            if (HttpContext.Session.GetObjectFromJson<Estabelecimento>("EstabelecimentoSessao") == null)
            {
                TempData["Erro"] = "Faça o login para acessar o sistema!";
                return RedirectToAction("Login", "Home");
            }
            GetItems("Bebida");
            return View(items);
        }
        public IActionResult Lanches()
        {
            if (HttpContext.Session.GetObjectFromJson<Estabelecimento>("EstabelecimentoSessao") == null)
            {
                TempData["Erro"] = "Faça o login para acessar o sistema!";
                return RedirectToAction("Login", "Home");
            }
            GetItems("Lanche");
            return View(items);
        }
        public IActionResult Sobremesas()
        {
            if (HttpContext.Session.GetObjectFromJson<Estabelecimento>("EstabelecimentoSessao") == null)
            {
                TempData["Erro"] = "Faça o login para acessar o sistema!";
                return RedirectToAction("Login", "Home");
            }
            GetItems("Sobremesa");
            return View(items);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            ViewBag.status = new List<string>(new string[] { "S", "N" });
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Item item)
        {
            if (ModelState.IsValid)
            {
                GetItems("All");
                client = new FireSharp.FirebaseClient(config);
                try
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
                    var estabelecimento = HttpContext.Session.GetObjectFromJson<Estabelecimento>("EstabelecimentoSessao");
                    item.CodigoEstabelecimento = estabelecimento.CodigoEstabelecimento;
                    PushResponse response = client.Push("itemCardapio/", item);
                    item.CodigoItem = response.Result.name;
                    SetResponse setResponse = client.Set("itemCardapio/" + item.CodigoItem, item);
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
            if (HttpContext.Session.GetObjectFromJson<Estabelecimento>("EstabelecimentoSessao") == null)
            {
                TempData["Erro"] = "Faça o login para acessar o sistema!";
                return RedirectToAction("Login", "Home");
            }
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("/itemCardapio/"+id);
            json = JObject.Parse(response.Body);
            var item = json.ToObject<Item>();
            ViewBag.status = new List<string>(new string[] { "S", "N" });
            return View(item);
        }

        [HttpPost]
        public IActionResult Editar(Item item)
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
                client.Update("/itemCardapio/" + item.CodigoItem, item);
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
            client = new FireSharp.FirebaseClient(config);
            client.Delete("/itemCardapio/"+id);
            Console.WriteLine("id:"+id);
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
            if (HttpContext.Session.GetObjectFromJson<Estabelecimento>("EstabelecimentoSessao") == null)
            {
                TempData["Erro"] = "Faça o login para acessar o sistema!";
                return RedirectToAction("Login", "Home");
            }
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