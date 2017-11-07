using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnection
{
    public class Conexion
    {
        private MySqlConnection con;
        private static Conexion instance = null;
        
        public static Conexion Instancia
        {
            get
            {
                if (instance == null)
                {
                    instance = new Conexion();
                }
                return instance;
            }
        }
        public Conexion()
        {
            string constr = "Data Source=localhost;port=3306;Initial Catalog=globodb;User Id=root;password=A01261357";
            con = new MySqlConnection(constr);
            
        }
        public MySqlDataReader Query(string query)
        {
            if (con.State == ConnectionState.Open)
            { 
                con.Close();
            }
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Connection = con;
            con.Open();
            return cmd.ExecuteReader();
            
        }
        public void Close()
        {
            con.Close();
        }
    }
}
