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
        private bool isNotLogged => Estab == null;
        IFirebaseClient Client => new FireSharp.FirebaseClient(config);
        Estabelecimento Estab => HttpContext.Session.GetObjectFromJson<Estabelecimento>("EstabelecimentoSessao");
        Gerente Gerente => HttpContext.Session.GetObjectFromJson<Gerente>("GerenteSessao");
        private ISession _session => HttpContext.Session;

        private IActionResult isLogged(List<Item> items = null, Estabelecimento estab = null, Gerente gerente = null, String pag = null)
        {
            if (isNotLogged)
            {
                TempData["Erro"] = "Faça o login para acessar o sistema!";
                return RedirectToAction("Login", "Home");
            }
            if (items != null)
            {
                return View(items);
            }
            else if (estab != null)
            {
                return View(estab);
            }
            else if (gerente != null)
            {
                return View(gerente);
            }
            else
            {
                return RedirectToAction(pag);
            }
        }

        [HttpGet]
        public IActionResult CadastroGerente()
        {
            return isLogged(null, null, null, "CadastroEstabelecimento");
        }

        private void CadastraEstabelecimento()
        {
            Estabelecimento estabb = Estab;
            PushResponse responseEstab = Client.Push("estab/", estabb);
            estabb.CodigoEstabelecimento = responseEstab.Result.name;
            Client.Set("estab/" + estabb.CodigoEstabelecimento, estabb);
            _session.SetObjectAsJson("EstabelecimentoSessao", estabb);
        }

        private void CadastraGerente(Gerente gerente)
        {
            gerente.CodigoEstabelecimento = Estab.CodigoEstabelecimento;
            PushResponse responseGerente = Client.Push("gerente/", gerente);
            gerente.CodigoGerente = responseGerente.Result.name;
            Client.Set("gerente/" + gerente.CodigoGerente, gerente);
        }

        [HttpPost]
        public IActionResult CadastroGerente(Gerente gerente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CadastraEstabelecimento();
                    TempData["Sucesso"] = "Bem vindo(a) ao Cardapp!";
                    CadastraGerente(gerente);

                    // seta gerente na sessão
                    _session.SetObjectAsJson("GerenteSessao", gerente);
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
            return isLogged(null,Estab,null, null);
        }

        [HttpGet]
        public IActionResult EditarGerente()
        {
            return isLogged(null, null, Gerente, null);
        }

        [HttpPost]
        public IActionResult EditarGerente(Gerente gerente)
        {
            if(ModelState.IsValid)
            {
                Client.Update("/gerente/" + gerente.CodigoGerente, gerente);
                _session.SetObjectAsJson("GerenteSessao", gerente);
                TempData["Sucesso"] = "Alterações salvas com sucesso!";
                return RedirectToAction("Index");
            } 
            TempData["Erro"] = "Não foi possível salvar as alterações!";
            return View();
        }

        [HttpGet]
        public IActionResult CadastroEstabelecimento()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastroEstabelecimento(Estabelecimento estab)
        {
            if (ModelState.IsValid)
            {
                _session.SetObjectAsJson("EstabelecimentoSessao", estab);
                _session.SetString("NomeEstabelecimento", estab.NomeFantasia);
                return RedirectToAction("CadastroGerente");
            }
            TempData["Erro"] = "Erro ao cadastrar o estabelecimento, cheque se as informações estão corretas e tente novamente.";
            return View();
        }

        [HttpGet]
        public IActionResult EditarEstabelecimento()
        {
            return isLogged(null, Estab, null, null);
        }

        [HttpPost]
        public IActionResult EditarEstabelecimento(Estabelecimento estab)
        {
            if(ModelState.IsValid)
            {
                Client.Update("/estab/" + estab.CodigoEstabelecimento, estab);
                _session.SetObjectAsJson("EstabelecimentoSessao", estab);
                _session.SetString("NomeEstabelecimento", estab.NomeFantasia);
                TempData["Sucesso"] = "Alterações salvas com sucesso!";
                return isLogged(null, null, null, "Index");
            }
            TempData["Erro"] = "Não foi possível salvar as alterações!";
            return View();
        }

        [HttpPost]
        public IActionResult Remover(string id)
        {
            FirebaseResponse response = Client.Get("/itemCardapio/");
            if (response.Body != "null")
            {
                JObject json = JObject.Parse(response.Body);

                foreach (var i in json)
                {
                    var item = i.Value.ToObject<Item>();
                    if (item.CodigoEstabelecimento == Gerente.CodigoEstabelecimento)
                    {
                        Client.Delete("/itemCardapio/"+item.CodigoItem);
                    }
                }

            }
            Client.Delete("/gerente/" + Gerente.CodigoGerente);
            Client.Delete("/estab/" + Gerente.CodigoEstabelecimento);
            return RedirectToAction("Index", "Home");
        }

    }
}