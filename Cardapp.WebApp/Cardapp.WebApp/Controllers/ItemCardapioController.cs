using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Cardapp.WebApp.Models;
using System.Linq;
using System;
using Cardapp.WebApp.Repository.Context;

namespace Cardapp.WebApp.Controllers
{
    public class ItemCardapioController : Controller
    {
        private static DataBaseContext ctx = new DataBaseContext();

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
            ViewBag.status = new List<string>(new string[] { "S", "N" });
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Item item)
        {
            try
                {
                ctx.Item.Add(item);
                ctx.SaveChanges();
                TempData["Sucesso"] = "Cadastrado com sucesso";
                return RedirectToAction("Cadastrar");
            }
            catch (Exception e)
            {
                TempData["Erro"] = "Erro ao cadastrar";
                Console.WriteLine(e);
                return RedirectToAction("Cadastrar");
            }

        }
        public IActionResult Editar(int id)
        {
            var item = ctx.Item.Find(id);
            ViewBag.status = new List<string>(new string[] { "S", "N" });
            return View(item);
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
            } catch(Exception e)
            {
                TempData["Erro"] = "Erro ao remover";
                Console.WriteLine(e);
                return RedirectToAction("Index");
            }

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


    }
}
