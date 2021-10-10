using FireSharp.Interfaces;
using FireSharp.Config;
using Microsoft.AspNetCore.Mvc;
using System;
using Cardapp.WebApp.Models;
using FireSharp.Response;
using Microsoft.AspNetCore.Http;
using Cardapp.WebApp.SessionHelper;

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
                    TempData["Sucesso"] = "Salvo com sucesso";

                    var data = gerente;
                    gerente.CodigoEstabelecimento = estabelecimento.CodigoEstabelecimento;
                    PushResponse responseGerente = client.Push("gerente/", data);
                    data.CodigoGerente = responseGerente.Result.name;
                    SetResponse setResponseGerente = client.Set("gerente/" + data.CodigoGerente, data);

                    // Guardar estab na sessão novamente
                    HttpContext.Session.SetObjectAsJson("EstabelecimentoSessao", estabelecimento);
                    HttpContext.Session.SetObjectAsJson("GerenteSessao", gerente);

                }
                catch (Exception ex)
                {
                    TempData["Erro"] = "Erro ao cadastrar";
                }
                return RedirectToAction("index", "ItemCardapio");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditarGerente()
        {
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
                return RedirectToAction("Index", "ItemCardapio");
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
            try
            {
                client = new FireSharp.FirebaseClient(config);
                client.Update("/estab/" + estab.CodigoEstabelecimento, estab);
                HttpContext.Session.SetObjectAsJson("EstabelecimentoSessao", estab);
                HttpContext.Session.SetString("NomeEstabelecimento", estab.NomeFantasia);
                TempData["Sucesso"] = "Alterações salvas com sucesso!";
                return RedirectToAction("Index", "ItemCardapio");
            }
            catch (Exception)
            {
                TempData["Erro"] = "Não foi possível salvar as alterações!";
                return RedirectToAction("EditarEstabelecimento");
            }
        }

    }
}