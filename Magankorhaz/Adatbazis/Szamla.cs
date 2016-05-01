using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magankorhaz.Adatbazis
{
    public class Szamla
    {
        public int Id { get; set; }
        public int PaciensID { get; set; }
        public int KartonID { get; set; }
        public int Fizetendo { get; set; }
        public bool Befizetve { get; set; }
        public DateTime BefizetesDatuma { get; set; }

        public override string ToString()
        {
            return PaciensID + " " + KartonID + " " + Fizetendo + " " + Befizetve;
        }
    }
}
