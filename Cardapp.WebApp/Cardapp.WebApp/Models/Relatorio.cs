using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cardapp.WebApp.Models
{
    public class Relatorio
    {
        public string CodigoRelatorio { get; set; }

        public string CodigoEstabelecimento { get; set; }

        public int NumeroAcessosTotal { get; set; }

        public int NumeroAcessosItemCardapio { get; set; }

        public string NomeItemMaisAcessado { get; set; }

        public int NumeroAtivacaoLuz { get; set; }

    }
}
