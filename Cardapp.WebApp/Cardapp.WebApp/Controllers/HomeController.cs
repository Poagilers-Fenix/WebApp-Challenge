using Cardapp.WebApp.Models;
using Cardapp.WebApp.SessionHelper;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;

namespace Cardapp.WebApp.Controllers
{
    public class HomeController : Controller
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "wvg4O1GNPzXqpGK95uGjhVValAjRiLX4iIM3P6YK",
            BasePath = "https://cardapp-d8eba-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient Client => new FireSharp.FirebaseClient(config);
        private ISession _session => HttpContext.Session;


        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Projeto()
        {
            return View();
        }

        public ActionResult Grupo()
        {
            return View();
        }
        
        public IActionResult Contato()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            if (ModelState.IsValid)
            {
                FirebaseResponse response = Client.Get("/gerente/");
                JObject json = JObject.Parse(response.Body);

                foreach (var g in json)
                {
                    var gerente = g.Value.ToObject<Gerente>();
                    if (gerente.Email == email && gerente.Senha == senha)
                    {
                        response = Client.Get("/estab/");
                        json = JObject.Parse(response.Body);
                        foreach (var e in json)
                        {
                            var estab = e.Value.ToObject<Estabelecimento>();
                            if (gerente.CodigoEstabelecimento == estab.CodigoEstabelecimento)
                            {
                                _session.SetObjectAsJson("EstabelecimentoSessao", estab);
                                _session.SetObjectAsJson("GerenteSessao", gerente);
                                _session.SetString("NomeEstabelecimento", estab.NomeFantasia);
                                return RedirectToAction("Index", "Estabelecimento");
                            }
                        }
                    }
                }
            }

            TempData["Erro"] = "Login inválido! Verifique se o e-mail e senha estão corretos.";
            return View();
        }

        public IActionResult Logout()
        {
            _session.Clear();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
