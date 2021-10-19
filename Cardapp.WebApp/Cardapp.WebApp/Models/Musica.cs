using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cardapp.WebApp.Models
{
    public class Musica
    {
        public string MusicName { get; set; }
        public string ArtistName { get; set; }
        public string SuggestMusicId { get; set; }
        public string UserEmail { get; set; }
        public string EstabId { get; set; }
        public bool Approval { get; set; }
    }
}
