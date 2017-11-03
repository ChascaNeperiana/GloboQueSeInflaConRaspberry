using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GloboAPI.Models
{
    public class Dispositivo
    {
        public int ID { get; set; }
        public int Tipo { get; set; }
        public bool Estado { get; set; }
        public string Adress { get; set; }

    }
}