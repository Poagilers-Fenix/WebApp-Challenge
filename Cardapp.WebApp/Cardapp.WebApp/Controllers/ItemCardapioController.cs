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

namespace Cardapp.WebApp.Controllers
{
    public class ItemCardapioController : Controller
    {
        private static DataBaseContext ctx = new DataBaseContext();

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "wvg4O1GNPzXqpGK95uGjhVValAjRiLX4iIM3P6YK",
            BasePath = "https://cardapp-d8eba-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;


        public IActionResult Index()
        {
            ViewBag.itens = ctx.Item.ToList<Item>();
            return View();
        }
        [HttpPost]
        public IActionResult Login()
        {
            return RedirectToAction("Index");
        }
        public IActionResult Pratos()
        {
            return View();
        }
        public IActionResult Bebidas()
        {
            return View();
        }
        public IActionResult Lanches()
        {
            return View();
        }
        public IActionResult Sobremesas()
        {
            return View();
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
            try
                {
                    client = new FireSharp.FirebaseClient(config);
                    var data = item;
                    PushResponse response = client.Push("itemCardapio/", data);
                    data.CodigoItem = response.Result.name;
                    SetResponse setResponse = client.Set("itemCardapio/" + data.CodigoItem, data);
                    TempData["success"] = "Cadastrado com sucesso";
                }
                catch (Exception ex)
                {
                    TempData["Erro"] = "Erro ao cadastrar";
                }
                return RedirectToAction("Cadastrar");
            }
        [HttpGet]
        public IActionResult Editar(int id)
        {
            var item = ctx.Item.Find(id);
            ViewBag.status = new List<string>(new string[] { "S", "N" });
            return View(item);
        }

        [HttpPost]
        public IActionResult Editar(Item item)
        {
            //try
            //{
            var entry = ctx.Item.First(e => e.CodigoItem == item.CodigoItem);
            ctx.Entry(entry).CurrentValues.SetValues(item);
            ctx.SaveChanges();
            TempData["Sucesso"] = "Item atualizado!";
            return RedirectToAction("Index");
            //} catch(Exception e)
            //{
            //    TempData["Erro"] = "Erro ao editar";
            //    Console.WriteLine(e);
            //    return RedirectToAction("Index");
            //}
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            try
            {
                var conta = ctx.Item.Find(id);
                ctx.Item.Remove(conta);
                ctx.SaveChanges();
                TempData["Sucesso"] = "Item Removido!";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["Erro"] = "Erro ao remover";
                Console.WriteLine(e);
                return RedirectToAction("Index");
            }

        }



    }
}