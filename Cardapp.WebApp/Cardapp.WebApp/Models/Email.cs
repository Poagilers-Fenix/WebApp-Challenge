using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cardapp.WebApp.Models
{
    public class Email
    {
        [Required, Display(Name = "Email para resposta"), EmailAddress]
        public string EmailResposta { get; set; }
        [Required, Display(Name = "Seu nome")]
        public string Nome { get; set; }
        [Required, Display(Name = "Assunto")]
        public string Assunto { get; set; }
        [Required, Display(Name = "Mensagem")]
        public string Mensagem { get; set; }
    }
}
