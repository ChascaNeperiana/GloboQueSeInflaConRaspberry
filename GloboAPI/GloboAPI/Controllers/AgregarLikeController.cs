
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
using DBConnection;

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

            Conexion conexion = new Conexion(constr);
            string query = "SELECT * FROM voto WHERE Id = '" + id + "'";
            MySqlDataReader sdr = conexion.Query(query);
            while (sdr.Read())
            {
                flag = false;
            }
            conexion.Close();
            if (flag)
            {
                query = "INSERT INTO voto (Id, PublicacionID, PerfilID, Nombre) VALUES ('" + id + "','" + followed + "','" + follower + "','" + follower + "')";
                sdr = conexion.Query(query);
                int n = 0;

                query = "SELECT Count(Id) FROM voto WHERE PublicacionID = '" + followed + "'";
                sdr = conexion.Query(query);
                while (sdr.Read())
                {
                    n = Convert.ToInt32(sdr["Count(Id)"]);
                }

                if ( n == 5)
                {
                    query = "UPDATE Publicacion SET Ganador = '"+follower+"' WHERE Id = '"+followed+"'";
                    sdr = conexion.Query(query);
                    while (sdr.Read())
                    {
                        n = Convert.ToInt32(sdr["Count(Id)"]);
                    }
                }
                conexion.Close();
                return 1;
            }
            else
            {
                conexion.Close();
                return 0;
            }
            
        }
    }
}
