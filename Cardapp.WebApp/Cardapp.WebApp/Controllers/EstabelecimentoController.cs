using FireSharp.Interfaces;
using FireSharp.Config;
using Microsoft.AspNetCore.Mvc;
using System;
using Cardapp.WebApp.Models;
using FireSharp.Response;
using Microsoft.AspNetCore.Http;
using Cardapp.WebApp.SessionHelper;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Cardapp.WebApp.Controllers
{
    public class EstabelecimentoController : Controller
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "wvg4O1GNPzXqpGK95uGjhVValAjRiLX4iIM3P6YK",
            BasePath = "https://cardapp-d8eba-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;

        [HttpGet]
        public IActionResult CadastroGerente()
        {
            var estabelecimento = HttpContext.Session.GetObjectFromJson<Estabelecimento>("EstabelecimentoSessao");

            if (estabelecimento == null)
            {
                return RedirectToAction("CadastroEstabelecimento");
            }
                return View();

        }

        [HttpPost]
        public IActionResult CadastroGerente(Gerente gerente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    client = new FireSharp.FirebaseClient(config);

                    var estabelecimento = HttpContext.Session.GetObjectFromJson<Estabelecimento>("EstabelecimentoSessao");
                    PushResponse responseEstab = client.Push("estab/", estabelecimento);
                    estabelecimento.CodigoEstabelecimento = responseEstab.Result.name;
                    SetResponse setResponseEstab = client.Set("estab/" + estabelecimento.CodigoEstabelecimento, estabelecimento);
                    TempData["Sucesso"] = "Bem vindo(a) ao Cardapp!";

                    var data = gerente;
                    gerente.CodigoEstabelecimento = estabelecimento.CodigoEstabelecimento;
                    PushResponse responseGerente = client.Push("gerente/", data);
                    data.CodigoGerente = responseGerente.Result.name;
                    SetResponse setResponseGerente = client.Set("gerente/" + data.CodigoGerente, data);

                    // Guardar estab na sessão novamente
                    HttpContext.Session.SetObjectAsJson("EstabelecimentoSessao", estabelecimento);
                    HttpContext.Session.SetObjectAsJson("GerenteSessao", gerente);
                    return RedirectToAction("index");

                }
                catch (Exception)
                {
                    TempData["Erro"] = "Erro ao cadastrar!";
                    return View();
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            Estabelecimento estab = HttpContext.Session.GetObjectFromJson<Estabelecimento>("EstabelecimentoSessao");
            if (estab == null)
            {
                TempData["Erro"] = "Faça o login para acessar o sistema!";
                return RedirectToAction("Login", "Home");
            }
            return View(estab);
        }

        [HttpGet]
        public IActionResult EditarGerente()
        {
            if (HttpContext.Session.GetObjectFromJson<Estabelecimento>("EstabelecimentoSessao") == null)
            {
                TempData["Erro"] = "Faça o login para acessar o sistema!";
                return RedirectToAction("Login", "Home");
            }
            Gerente gerente = HttpContext.Session.GetObjectFromJson<Gerente>("GerenteSessao");

            return View(gerente);
        }

        [HttpPost]
        public IActionResult EditarGerente(Gerente gerente)
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
                client.Update("/gerente/" + gerente.CodigoGerente, gerente);
                HttpContext.Session.SetObjectAsJson("GerenteSessao", gerente);
                TempData["Sucesso"] = "Alterações salvas com sucesso!";
                return RedirectToAction("Index");
            } catch(Exception)
            {
                TempData["Erro"] = "Não foi possível salvar as alterações!";
                return RedirectToAction("EditarGerente");
            }
        }

        [HttpGet]
        public IActionResult CadastroEstabelecimento()
        {
            HttpContext.Session.Clear();
            return View();
        }

        [HttpPost]
        public IActionResult CadastroEstabelecimento(Estabelecimento estab)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetObjectAsJson("EstabelecimentoSessao", estab);
                HttpContext.Session.SetString("NomeEstabelecimento", estab.NomeFantasia);
                return RedirectToAction("CadastroGerente");
            }
            TempData["Erro"] = "Erro ao cadastrar o estabelecimento, cheque se as informações estão corretas e tente novamente.";
            return View();
        }

        [HttpGet]
        public IActionResult EditarEstabelecimento()
        {
            Estabelecimento estab = HttpContext.Session.GetObjectFromJson<Estabelecimento>("EstabelecimentoSessao");
            return View(estab);
        }

        [HttpPost]
        public IActionResult EditarEstabelecimento(Estabelecimento estab)
        {
            if (HttpContext.Session.GetObjectFromJson<Estabelecimento>("EstabelecimentoSessao") == null)
            {
                TempData["Erro"] = "Faça o login para acessar o sistema!";
                return RedirectToAction("Login", "Home");
            }
            try
            {
                client = new FireSharp.FirebaseClient(config);
                client.Update("/estab/" + estab.CodigoEstabelecimento, estab);
                HttpContext.Session.SetObjectAsJson("EstabelecimentoSessao", estab);
                HttpContext.Session.SetString("NomeEstabelecimento", estab.NomeFantasia);
                TempData["Sucesso"] = "Alterações salvas com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["Erro"] = "Não foi possível salvar as alterações!";
                return RedirectToAction("EditarEstabelecimento");
            }
        }

        [HttpPost]
        public IActionResult Remover(string id)
        {
            client = new FireSharp.FirebaseClient(config);
            Gerente gerente = HttpContext.Session.GetObjectFromJson<Gerente>("GerenteSessao");
            FirebaseResponse response = client.Get("/itemCardapio/");
            if (response.Body != "null")
            {
                JObject json = JObject.Parse(response.Body);

                foreach (var i in json)
                {
                    var item = i.Value.ToObject<Item>();
                    if (item.CodigoEstabelecimento == gerente.CodigoEstabelecimento)
                    {
                        client.Delete("/itemCardapio/"+item.CodigoItem);
                    }
                }

            }
            client.Delete("/gerente/" + gerente.CodigoGerente);
            client.Delete("/estab/" + gerente.CodigoEstabelecimento);

            //GetItems(out items, out estab, out json);

            return RedirectToAction("Index", "Home");
        }

    }
}