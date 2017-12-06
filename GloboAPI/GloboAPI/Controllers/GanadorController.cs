using Common;
using DBConnection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace GloboAPI.Controllers
{
    public class GanadorController : ApiController
    {
        public string Get()
        {
            string ganador = null;
            Conexion_MySql conexion = ConexionBuilder.MySql();

            string query = "SELECT * FROM Publicacion WHERE Estado = 1";
            MySqlDataReader sdr = conexion.Query(query);
            while (sdr.Read())
            {
                ganador = sdr["Ganador"].ToString();
            }

            return ganador;
        }
        
    }
}
