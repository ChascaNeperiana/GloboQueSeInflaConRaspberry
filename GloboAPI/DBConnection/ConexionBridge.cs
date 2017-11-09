using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnection
{
    public class ConexionBridge
    {
        public static Conexion_MySql MySql()
        {
            return Conexion_MySql.Instancia;
        }
    }
}
