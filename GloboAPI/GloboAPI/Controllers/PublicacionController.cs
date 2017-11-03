using GloboAPI.Models;
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
    public class PublicacionController : ApiController
    {
        [System.Web.Http.HttpGet]
        public int Agregar(string id)
        {
            
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "UPDATE publicacion SET Estado = 0 WHERE DipositivoID = 1 ";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                    }
                    con.Close();
                }
            }
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "INSERT INTO publicacion (Id, Tipo, NLikes, DipositivoID, Estado) VALUES ('" + id + "',1,0,1,1)";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                    }
                    con.Close();
                }
            }
            return 1;
            
        }
    }
}
