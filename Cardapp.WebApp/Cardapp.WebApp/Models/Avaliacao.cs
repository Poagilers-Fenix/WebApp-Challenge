using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cardapp.WebApp.Models
{
    public class Avaliacao
    {
        public string RatingId { get; set; }

        public float Rating { get; set; }

        public string Text { get; set; }

        public string UserEmail { get; set; }
        
        public string UserName { get; set; }

        public string EstabId { get; set; }

    }
}
