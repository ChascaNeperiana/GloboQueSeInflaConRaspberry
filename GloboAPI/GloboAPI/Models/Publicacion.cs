using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GloboAPI.Models
{
    public class Publicacion
    {
        public string ID { get; set; }
        public int Tipo { get; set; }
        public int NLikes { get; set; }
        public int DispositivoID { get; set; }
        public bool Estado { get; set; }
        public string Ganador { get; set; }

    }
}