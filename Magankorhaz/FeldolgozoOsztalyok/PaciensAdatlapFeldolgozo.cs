using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magankorhaz.FeldolgozoOsztalyok
{
    class PaciensAdatlapFeldolgozo
    {
        public Adatbazis.Paciens paciensAdatok { get; set; }
        public string ugyintezoNev { get; set; }
        public string paciensOsztaly { get; set; }
        public List<Adatbazis.Osztaly> osszesOsztaly { get; set; }

        public PaciensAdatlapFeldolgozo(Adatbazis.MagankorhazDB adatbazis, string paciensEmail)
        {
            // Páciens megkeresése
            var paciens = from akt in adatbazis.Paciensek
                          where akt.Email == paciensEmail
                          select akt;

            paciensAdatok = paciens.First();

            // Pácienst felvevő ügyintéző megkeresése
            var ugyintezo = from akt in adatbazis.Ugyintezok
                            where akt.Id == paciensAdatok.UgyvezetoID
                            select akt.Nev;

            ugyintezoNev = ugyintezo.First();

            // Páciens osztályának és (ha van) szobájának megkeresése
            var osztály = from akt in adatbazis.Osztalyok
                            where akt.Id == paciensAdatok.OsztalyID
                            select akt.Megnevezes;

            paciensOsztaly = osztály.First();

            // Összes osztály megkeresése és ComboBox feltöltése, hogyha majd változtatni szeretne
            var osztalyok = from akt in adatbazis.Osztalyok
                          select akt;

            osszesOsztaly = osztalyok.ToList();
        }

    }
}
