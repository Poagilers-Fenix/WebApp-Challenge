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

            if (estabelecimento != null)
            {
                Gerente gerente = new Gerente()
                {
                    CodigoEstabelecimento = estabelecimento.CodigoEstabelecimento,
                };

                return View(gerente);
            }
            return RedirectToAction("CadastroEstabelecimento");

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
                    PushResponse response = client.Push("estabelecimento/", estabelecimento);
                    estabelecimento.id_Estab_Firebase = response.Result.name;
                    SetResponse setResponse = client.Set("estabelecimento/" + estabelecimento.id_Estab_Firebase, estabelecimento);
                    ModelState.AddModelError(string.Empty, "Salvo com sucesso");

                    var data = gerente;
                    response = client.Push("gerente/", data);
                    data.id_Gerente_Firebase = response.Result.name;
                    setResponse = client.Set("gerente/" + data.id_Gerente_Firebase, data);
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
            HttpContext.Session.Clear();
            return View();
        }


        [HttpPost]
        public IActionResult CadastroEstabelecimento(Estabelecimento estab)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetObjectAsJson("EstabelecimentoSessao", estab);
                return RedirectToAction("CadastroGerente");
            }
            TempData["Erro"] = "Erro ao cadastrar o estabelecimento, cheque se as informações estão corretas e tente novamente.";
            return View();
        }

    }
}