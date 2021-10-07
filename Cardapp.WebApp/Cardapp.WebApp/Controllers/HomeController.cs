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

        public bool Logado { get; set; }

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "wvg4O1GNPzXqpGK95uGjhVValAjRiLX4iIM3P6YK",
            BasePath = "https://cardapp-d8eba-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
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
            client = new FireSharp.FirebaseClient(config);

            FirebaseResponse response = client.Get("/gerente/");
            JObject json = JObject.Parse(response.Body);

            foreach (var g in json)
            {
                var gerente = g.Value.ToObject<Gerente>();
                if (gerente.Email == email && gerente.Senha == senha)
                {
                    if (ModelState.IsValid)
                    {
                        response = client.Get("/estab/");
                        json = JObject.Parse(response.Body);
                        foreach (var e in json)
                        {
                            var estab = e.Value.ToObject<Estabelecimento>();
                            if (gerente.CodigoEstabelecimento == estab.CodigoEstabelecimento)
                            {
                                HttpContext.Session.SetObjectAsJson("EstabelecimentoSessao", estab);
                                HttpContext.Session.SetObjectAsJson("GerenteSessao", gerente);
                                HttpContext.Session.SetString("NomeEstabelecimento", estab.NomeFantasia);
                                return RedirectToAction("Index", "ItemCardapio");
                            }
                        }
                    }
                }
            }

            TempData["Erro"] = "Login inválido! Verifique se o e-mail e senha estão corretos.";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
