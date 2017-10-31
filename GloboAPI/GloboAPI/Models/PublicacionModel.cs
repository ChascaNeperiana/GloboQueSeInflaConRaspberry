using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GloboAPI.Models
{
    public class PublicacionModel
    {
        public string ID { get; set; }
        public string Ganador { get; set; }
        public int Likes { get; set; }
        public int Tipo { get; set; }

    }
}