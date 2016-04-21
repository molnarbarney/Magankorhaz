using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magankorhaz.FeldolgozoOsztalyok
{
    class UgyintezoAttekintesFeldolgozo
    {
        public int szabadFerohelyek(Adatbazis.MagankorhazDB adatbazis)
        {
            var osszesHely = from akt in adatbazis.Osztalyok
                             select akt.OsszesFerohely;

            int osszesFerohely = osszesHely.Count() * osszesHely.First();

            var hanyPaciensVanElhelyezve = from akt in adatbazis.Paciensek
                                           where akt.OsztalyID != null
                                           select akt;

            return osszesFerohely - hanyPaciensVanElhelyezve.Count();
        }

        public string ferfiakNokAranya(Adatbazis.MagankorhazDB adatbazis)
        {
            var paciensek = from akt in adatbazis.Paciensek
                            select akt;

            int ferfiak = 0;
            int nok = 0;
            foreach (var paciens in paciensek)
            {
                if (paciens.Neme == "Férfi")
                {
                    ferfiak++;
                }
                else nok++;
            }
            
            return ferfiak + " - " + nok;
        }

        public List<Adatbazis.Paciens> legregebbiLegujabbPaciens(Adatbazis.MagankorhazDB adatbazis)
        {
            List<Adatbazis.Paciens> legregebbLegujabb = new List<Adatbazis.Paciens>();

            var legregebbiPaciens = (from akt in adatbazis.Paciensek
                            orderby akt.FelvetelDatuma ascending
                            select akt).FirstOrDefault();

            var legujabbPaciens = (from akt in adatbazis.Paciensek
                                     orderby akt.FelvetelDatuma descending
                                     select akt).FirstOrDefault();

            legregebbLegujabb.Add(legregebbiPaciens);
            legregebbLegujabb.Add(legujabbPaciens);

            return legregebbLegujabb;
        }

        public List<Adatbazis.Paciens> paciensek(Adatbazis.MagankorhazDB adatbazis)
        {
            List<Adatbazis.Paciens> paciensek = new List<Adatbazis.Paciens>();

            var paciensekSQL = from akt in adatbazis.Paciensek
                            orderby akt.Nev descending
                            select akt;

            foreach (var paciens in paciensekSQL)
            {
                paciensek.Add(paciens);
            }

            return paciensek;
        }
    }
}
