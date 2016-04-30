using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magankorhaz.Adatbazis
{
    public class Idopont
    {
        public int Id { get; set; }
        public int PaciensID { get; set; }
        public int OrvosID { get; set; }
        public DateTime FoglaltIdopont { get; set; }
        public string Megnevezes { get; set; }
    }
}
