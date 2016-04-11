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
        public List<Recept> Receptek { get; set; }
        public DateTime KezelesDatuma { get; set; }
        public string KezelesReszletei { get; set; }
        public bool KezelesSikeressege { get; set; }
        public int KezelesKoltsege { get; set; }
    }
}
