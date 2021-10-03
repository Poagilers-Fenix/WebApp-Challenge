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

        public IActionResult CadastroGerente()
        {
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
                try
                {
                    client = new FireSharp.FirebaseClient(config);
                    var data = estab;
                    PushResponse response = client.Push("estab/", data);
                    data.id_Estab_Firebase = response.Result.name;
                    SetResponse setResponse = client.Set("estab/" + data.id_Estab_Firebase, data);
                    ModelState.AddModelError(string.Empty, "Salvo com sucesso");
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                return RedirectToAction("CadastroGerente");
            }
            return View();
        }
        
    }
}
