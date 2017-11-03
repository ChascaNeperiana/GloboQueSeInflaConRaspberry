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
    public class LikesController : ApiController
    {
        public int Get(int id)
        { 
            List<Publicacion> dispositivo = new List<Publicacion>();
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            int n = 0;
            string pub_id = "NONE";
             using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT * FROM Publicacion WHERE DipositivoID = " + id;
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            pub_id = sdr["Id"].ToString();
                        }
                    }
                    con.Close();
                }
                query = "SELECT Count(Id) FROM voto WHERE PublicacionID = '" + pub_id + "'";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            n = Convert.ToInt32(sdr["Count(Id)"]);
                        }
                    }
                    con.Close();
                }
            }
            return n;
        }
        
    }
}
