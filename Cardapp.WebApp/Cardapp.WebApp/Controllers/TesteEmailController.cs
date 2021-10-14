using Cardapp.WebApp.Models;
using Cardapp.WebApp.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Cardapp.WebApp.Controllers
{
    public class TesteEmailController : Controller
    {
        private readonly IEmailSender _emailSender;

        [Obsolete]
        public TesteEmailController(IEmailSender emailSender, IHostingEnvironment env)
        {
            _emailSender = emailSender;
        }
        public IActionResult EnviaEmail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EnviaEmail(Email email)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TesteEnvioEmail(email.EmailResposta, email.Nome, email.Assunto, email.Mensagem).GetAwaiter();
                    TempData["Sucesso"] = "E-mail enviado com sucesso!";
                }
                catch (Exception)
                {
                    TempData["Erro"] = "Algo deu errado... Tente novamente mais tarde!";
                }
            }
            return RedirectToAction("Contato", "home");
        }
        public async Task TesteEnvioEmail(string remetente, string nome, string assunto, string mensagem)
        {
            try
            {
                await _emailSender.SendEmailAsync(remetente, nome, assunto, mensagem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
