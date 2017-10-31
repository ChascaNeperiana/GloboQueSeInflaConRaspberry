using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GloboAPI.Models
{
    public class LikeModel
    {
        public string ID { get; set; }
        public int Tipo { get; set; }
        public string PublicacionID { get; set; }
        public string UsuarioID { get; set; }

    }
}