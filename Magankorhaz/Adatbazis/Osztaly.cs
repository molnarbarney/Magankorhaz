using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magankorhaz.Adatbazis
{
    class Osztaly
    {
        public int Id { get; set; }
        public string Megnevezes { get; set; }
        public int OsszesFerohely { get; set; }
        /**
         * <summary>
         * Egy osztályon hány db szoba van
         * </summary>
         */
        public int SzobakSzama { get; set; }
        
        // Egy osztályhoz több orvos is tartozhat
        public List<Orvos> Orvosok { get; set; }
    }
}
