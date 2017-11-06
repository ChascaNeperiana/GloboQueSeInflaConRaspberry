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
        private string constr;
        private MySqlConnection con;
        public Conexion(string constr)
        {
            this.constr = constr;
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
