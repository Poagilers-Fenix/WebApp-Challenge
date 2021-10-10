using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Cardapp.WebApp.Models;
using System.Linq;
using System;
using Cardapp.WebApp.Repository.Context;
using FireSharp.Interfaces;
using FireSharp.Config;
using FireSharp.Response;
using Cardapp.WebApp.SessionHelper;
using Newtonsoft.Json.Linq;
using FireSharp;

namespace Cardapp.WebApp.Controllers
{
    public class ItemCardapioController : Controller
    {
        IList<Item> items; Estabelecimento estab; JObject json;

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "wvg4O1GNPzXqpGK95uGjhVValAjRiLX4iIM3P6YK",
            BasePath = "https://cardapp-d8eba-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;

        private void GetItems(out IList<Item> items, out Estabelecimento estab, out JObject json)
        {
            client = new FireSharp.FirebaseClient(config);
            items = new List<Item>();
            estab = HttpContext.Session.GetObjectFromJson<Estabelecimento>("EstabelecimentoSessao");
            FirebaseResponse response = client.Get("/itemCardapio/");
            if (response.Body != "null")
            {
                json = JObject.Parse(response.Body);
                return;
            }
            json = null;
        }

        public IActionResult Index()
        {
            GetItems(out items, out estab, out json);

            if (json != null)
            {
                foreach (var i in json)
                {
                    var item = i.Value.ToObject<Item>();
                    if (item.CodigoEstabelecimento == estab.CodigoEstabelecimento && item.Destaque == 'S')
                    {
                        items.Add(item);
                    }
                }
            }

            return View(items);
        }
        public IActionResult Pratos()
        {
            GetItems(out items, out estab, out json);

            if (json != null)
            {
                foreach (var i in json)
                {
                    var item = i.Value.ToObject<Item>();
                    if (item.CodigoEstabelecimento == estab.CodigoEstabelecimento && item.Categoria == CategoriaItem.Prato)
                    {
                        items.Add(item);
                    }
                }
            }

            return View(items);
        }
        public IActionResult Bebidas()
        {
            GetItems(out items, out estab, out json);

            if(json != null)
            {
                foreach (var i in json)
                {
                    var item = i.Value.ToObject<Item>();
                    if (item.CodigoEstabelecimento == estab.CodigoEstabelecimento && item.Categoria == CategoriaItem.Bebida)
                    {
                        items.Add(item);
                    }
                }
            }

            return View(items);
        }
        public IActionResult Lanches()
        {
            GetItems(out items, out estab, out json);

            if (json != null)
            {
                foreach (var i in json)
                {
                    var item = i.Value.ToObject<Item>();
                    if (item.CodigoEstabelecimento == estab.CodigoEstabelecimento && item.Categoria == CategoriaItem.Lanche)
                    {
                        items.Add(item);
                    }
                }
            }

            return View(items);
        }
        public IActionResult Sobremesas()
        {
            GetItems(out items, out estab, out json);

            if (json != null)
            {
                foreach (var i in json)
                {
                    var item = i.Value.ToObject<Item>();
                    if (item.CodigoEstabelecimento == estab.CodigoEstabelecimento && item.Categoria == CategoriaItem.Sobremesa)
                    {
                        items.Add(item);
                    }
                }
            }

            return View(items);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            var estabelecimento = HttpContext.Session.GetObjectFromJson<Estabelecimento>("EstabelecimentoSessao");
            ViewBag.status = new List<string>(new string[] { "S", "N" });
            if (estabelecimento == null)
            {
                return RedirectToAction("Index");
            }

            Item item = new Item()
            {
                CodigoEstabelecimento = estabelecimento.CodigoEstabelecimento
            };
            return View(item);
        }

        [HttpPost]
        public IActionResult Cadastrar(Item item)
        {
            GetItems(out items, out estab, out json);
            client = new FireSharp.FirebaseClient(config);
            try
            {
                var data = item;
                foreach (var i in json)
                {
                    var itemJson = i.Value.ToObject<Item>();
                    if (itemJson.Nome == item.Nome)
                    {
                        TempData["Erro"] = "Um item com o nome '" + item.Nome + "' já está cadastrado!";
                        return RedirectToAction("Cadastrar");
                    }
                }
                PushResponse response = client.Push("itemCardapio/", data);
                data.CodigoItem = response.Result.name;
                SetResponse setResponse = client.Set("itemCardapio/" + data.CodigoItem, data);
                TempData["Sucesso"] = "Cadastrado com sucesso";
            }
            catch (Exception)
            {
                TempData["Erro"] = "Erro ao cadastrar";
            }
            return RedirectToAction("Cadastrar");
        }

        [HttpGet]
        public IActionResult Editar(string id)
        {
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
                if (item.Categoria.ToString() == "Bebida") { return RedirectToAction("Bebidas"); }
                else if (item.Categoria.ToString() == "Sobremesa") { return RedirectToAction("Sobremesas"); }
                else if (item.Categoria.ToString() == "Prato") { return RedirectToAction("Pratos"); }
                else if (item.Categoria.ToString() == "Lanche") { return RedirectToAction("Lanches"); }
                return RedirectToAction("Index");
            } catch (Exception)
            {
                TempData["Erro"] = "Não foi possível editar o item do cardápio.";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Remover(string id)
        {
            //try
            //{
                client = new FireSharp.FirebaseClient(config);
            client.Delete("/itemCardapio/"+id);
            Console.WriteLine("id:"+id);
                TempData["Sucesso"] = "Item Removido!";
                return RedirectToAction("Index");
            //}
            //catch (Exception e)
            //{
                //TempData["Erro"] = "Erro ao remover";
                //Console.WriteLine(e);
                //return RedirectToAction("Index");
            //}

        }



    }
}