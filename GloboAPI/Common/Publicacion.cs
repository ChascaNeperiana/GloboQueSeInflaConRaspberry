using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Publicacion : EntityObject
    {
        public string ID { get; set; }
        public int Tipo { get; set; }
        public int NLikes { get; set; }
        public int DispositivoID { get; set; }
        public bool Estado { get; set; }
        public string Ganador { get; set; }

        public override string ToString()
        {
            string answer = String.Format("ID = {0}\nGanador = {1}", ID, Ganador);
            return answer;
        }
    }
}
