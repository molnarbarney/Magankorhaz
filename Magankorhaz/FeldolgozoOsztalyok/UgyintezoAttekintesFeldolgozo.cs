using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magankorhaz.FeldolgozoOsztalyok
{
    class UgyintezoAttekintesFeldolgozo
    {
        public int szabadFerohelyek()
        {
            var osszesHely = from akt in Magankorhaz.Adatbazis.AdatBazis.DataBase.Osztalyok
                             select akt.OsszesFerohely;

            int osszesFerohely = osszesHely.Count() * osszesHely.First();

            var hanyPaciensVanElhelyezve = from akt in Magankorhaz.Adatbazis.AdatBazis.DataBase.Paciensek
                                           where akt.OsztalyID != null
                                           select akt;

            return osszesFerohely - hanyPaciensVanElhelyezve.Count();
        }

        public string ferfiakNokAranya()
        {
            var paciensek = from akt in Magankorhaz.Adatbazis.AdatBazis.DataBase.Paciensek
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

        public List<Adatbazis.Paciens> legregebbiLegujabbPaciens()
        {
            List<Adatbazis.Paciens> legregebbLegujabb = new List<Adatbazis.Paciens>();

            var legregebbiPaciens = (from akt in Magankorhaz.Adatbazis.AdatBazis.DataBase.Paciensek
                            orderby akt.FelvetelDatuma ascending
                            select akt).FirstOrDefault();

            var legujabbPaciens = (from akt in Magankorhaz.Adatbazis.AdatBazis.DataBase.Paciensek
                                     orderby akt.FelvetelDatuma descending
                                     select akt).FirstOrDefault();

            legregebbLegujabb.Add(legregebbiPaciens);
            legregebbLegujabb.Add(legujabbPaciens);

            return legregebbLegujabb;
        }

        /*
        public List<Adatbazis.Paciens> paciensek(Adatbazis.MagankorhazDB adatbazis)
        {
            List<Adatbazis.Paciens> paciensek = new List<Adatbazis.Paciens>();

            var paciensekSQL = from paciens in adatbazis.Paciensek
                               orderby paciens.Nev descending
                               select paciens;

            foreach (var paciens in paciensekSQL)
            {
                paciensek.Add(paciens);
            }

            return paciensek;
        }
        */

        public List<object> paciensek()
        {
            List<object> paciensek = new List<object>();

            var paciensekSQL = from paciens in Magankorhaz.Adatbazis.AdatBazis.DataBase.Paciensek
                               join osztaly in Magankorhaz.Adatbazis.AdatBazis.DataBase.Osztalyok on paciens.OsztalyID equals osztaly.Id
                               select new { Név = paciens.Nev, Email = paciens.Email, Osztály = osztaly.Megnevezes, SzületésiDátum = paciens.SzuletesiDatum, FelvételiDátum = paciens.FelvetelDatuma };

            //System.Windows.MessageBox.Show(lekerdezes.First().Nev + " " + lekerdezes.First().osztály);

            foreach (var paciens in paciensekSQL)
            {
                paciensek.Add(paciens);
            }

            return paciensek;
        }
    }
}
