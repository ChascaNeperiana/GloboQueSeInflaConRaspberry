using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnection
{
    public interface BuilderFacade
    {
        Conexion_MySql MySql();
    }
}
