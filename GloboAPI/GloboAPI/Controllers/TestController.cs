using Common;
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
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

             using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT * FROM Dispositivo";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
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
                    }
                    con.Close();
                }
            }
            return customers;
        }
    }
}
