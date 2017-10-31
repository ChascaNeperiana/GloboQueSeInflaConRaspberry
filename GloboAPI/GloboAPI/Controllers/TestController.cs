using GloboAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GloboAPI.Controllers
{
    public class TestController : ApiController
    {
        public LikeModel Get()
        {
            return new LikeModel
            {
                ID = "21YIWLHDYU21HBK", 
                PublicacionID = "PUI1H21JN2",
                Tipo = 1,
                UsuarioID = "I21O3K123K"
            };
        }
    }
}
