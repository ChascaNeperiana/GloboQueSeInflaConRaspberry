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
    public class PendienteController : ApiController
    {
        public string Get()
        {
            string publicacion = null;
            Conexion_MySql conexion = ConexionBridge.MySql();

            string query = "SELECT * FROM Publicacion WHERE Pendiente = 1";
            MySqlDataReader sdr = conexion.Query(query);
            while (sdr.Read())
            {
                publicacion = sdr["Id"].ToString();
            }
            query = "UPDATE publicacion SET Pendiente = 0 WHERE Id = '" + publicacion + "'";
            conexion.Query(query);
            conexion.Close();

            return publicacion;
        }
    }
}
