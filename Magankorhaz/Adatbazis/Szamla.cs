using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magankorhaz.Adatbazis
{
    class Szamla
    {
        public int Id { get; set; }
        public Paciens PaciensID { get; set; }
        public Karton KartonID { get; set; }
        public int Fizetendo { get; set; }
        public bool Befizetve { get; set; }
        public DateTime BefizetesDatuma { get; set; }
    }
}
