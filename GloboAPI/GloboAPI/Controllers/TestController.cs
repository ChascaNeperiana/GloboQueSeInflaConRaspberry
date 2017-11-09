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
    public class TestController : ApiController
    {
        public List<Dispositivo> Get()
        { 
            List<Dispositivo> customers = new List<Dispositivo>();
            Conexion_MySql conexion = ConexionBridge.MySql();

            string query = "SELECT * FROM Dispositivo";
            MySqlDataReader sdr = conexion.Query(query);
            while (sdr.Read())
            {
                customers.Add(new Dispositivo
                {
                    ID = Convert.ToInt32(sdr["Id"]),
                    Adress = sdr["Adress"].ToString(),
                    Estado = Convert.ToBoolean(sdr["Estado"]),
                    Tipo = Convert.ToInt32(sdr["Tipo"]),
                });
            }
            conexion.Close();

            return customers;
        }
    }
}
