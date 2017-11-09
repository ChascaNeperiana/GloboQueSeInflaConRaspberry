using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Dispositivo : EntityObject
    {
        public int ID { get; set; }
        public int Tipo { get; set; }
        public bool Estado { get; set; }
        public string Adress { get; set; }

        public override string ToString()
        {
            string answer = String.Format("ID = {0}\nTipo = {1}\nEstado = {2}\nAdress = {3}",
                ID, Tipo, Estado, Adress);
            return answer;
        }
    }
}
