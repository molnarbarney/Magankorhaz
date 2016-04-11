using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magankorhaz.Adatbazis
{
    class Idopont
    {
        public int Id { get; set; }
        public Paciens PaciensID { get; set; }
        public Orvos OrvosID { get; set; }
        public DateTime FoglaltIdopont { get; set; }
        public string Megnevezes { get; set; }
    }
}
