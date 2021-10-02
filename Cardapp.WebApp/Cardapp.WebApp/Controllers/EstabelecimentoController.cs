using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cardapp.WebApp.Controllers
{
    public class EstabelecimentoController : Controller
    {

        public IActionResult CadastroGerente()
        {
            return View();
        }

        public IActionResult CadastroEstabelecimento()
        {
            return View();
        }

    }
}
