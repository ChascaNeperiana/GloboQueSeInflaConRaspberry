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
    public class LikesController : ApiController
    {
        public int Get(int id)
        { 
            List<Publicacion> dispositivo = new List<Publicacion>();
            int n = 0;
            string pub_id = "NONE";
            Conexion_MySql conexion = ConexionBridge.MySql();

            string query = "SELECT * FROM Publicacion WHERE Estado = 1 AND DipositivoID = " + id;
            MySqlDataReader sdr = conexion.Query(query);
            while (sdr.Read())
            {
                pub_id = sdr["Id"].ToString();
            }

            query = "SELECT Count(Id) FROM voto WHERE PublicacionID = '" + pub_id + "'";
            sdr = conexion.Query(query);
            while (sdr.Read())
            {
                n = Convert.ToInt32(sdr["Count(Id)"]);
            }

            conexion.Close();
            return n;
        }
        
    }
}
