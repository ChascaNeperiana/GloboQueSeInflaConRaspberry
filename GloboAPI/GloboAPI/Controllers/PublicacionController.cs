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
    public class PublicacionController : ApiController
    {
        [System.Web.Http.HttpGet]
        public int Agregar(string id)
        {

            BuilderFacade builder = new ConexionBuilder();
            Conexion_MySql conexion = builder.MySql();

            bool flag = true;
            string query = "SELECT * FROM publicacion WHERE ID = '" + id + "'";
            MySqlDataReader sdr = conexion.Query(query);

            while (sdr.Read())
            {
                flag = false;
            }

            if (flag)
            {
                query = "UPDATE publicacion SET Estado = 0 WHERE DipositivoID = 1 ";
                conexion.Query(query);
                
                query = "INSERT INTO publicacion (Id, Tipo, NLikes, DipositivoID, Estado, Pendiente) VALUES ('" + id + "',1,0,1,1,1)";
                conexion.Query(query);

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
