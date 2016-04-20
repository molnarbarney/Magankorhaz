using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magankorhaz.Adatbazis
{
    class Karton
    {
        public int Id { get; set; }
        public Paciens PaciensID { get; set; }
        public Orvos OrvosID { get; set; }
        public string Receptek { get; set; } // stringként összefűzve a repect ID-k
        public DateTime KezelesDatuma { get; set; }
        public string KezelesReszletei { get; set; }
        public bool KezelesSikeressege { get; set; }
        public int KezelesKoltsege { get; set; }
    }
}
