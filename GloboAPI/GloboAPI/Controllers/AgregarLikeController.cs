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
    public class AgregarLikeController : ApiController
    {
        public int Get(string id)
        {
            string[] strs = id.Split(',');
            string followed = strs[0];
            string follower = strs[1];
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            bool flag = true;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT * FROM voto WHERE Id = '" + id + "'";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            flag = false;
                        }
                    }
                    con.Close();
                }
            }
            if (flag)
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = "INSERT INTO voto (Id, PublicacionID, PerfilID, Nombre) VALUES ('" + id + "','" + followed + "','" + follower + "','" + follower + "')";
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
            else
            {
                return 0;
            }
            
        }
    }
}
