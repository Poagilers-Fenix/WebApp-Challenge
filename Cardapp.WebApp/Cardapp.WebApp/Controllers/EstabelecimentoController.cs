using FireSharp.Interfaces;
using FireSharp.Config;
using Microsoft.AspNetCore.Mvc;
using System;
using Cardapp.WebApp.Models;
using FireSharp.Response;

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
        public IActionResult CadastroGerente(Estabelecimento estab)
        {
            if(estab != null)
            {
                Gerente gerente = new Gerente()
                {
                    CodigoEstabelecimento = estab.CodigoEstabelecimento,
                };

                return View(gerente);
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
                    var data = gerente;
                    PushResponse response = client.Push("gerente/", data);
                    data.id_Gerente_Firebase = response.Result.name;
                    SetResponse setResponse = client.Set("gerente/" + data.id_Gerente_Firebase, data);
                    ModelState.AddModelError(string.Empty, "Salvo com sucesso");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                return RedirectToAction("CadastroGerente");
            }
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
                return RedirectToAction("CadastroGerente", estab);
            }
            TempData["Erro"] = "Erro ao cadastrar o estabelecimento, cheque se as informações estão corretas e tente novamente.";
            return View();
        }
        
    }
}
