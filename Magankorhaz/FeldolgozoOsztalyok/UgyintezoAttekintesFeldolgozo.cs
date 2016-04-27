using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magankorhaz.FeldolgozoOsztalyok
{
    class UgyintezoAttekintesFeldolgozo
    {
        // Ezeket akkor használom, amikor módosítom a páciens adatait (ideiglenes tároló)
        public string paciensTempNev { get; set; }
        public string paciensTempFelhasznalonev { get; set; }
        public string paciensTempJelszo { get; set; }
        public string paciensTempEmail { get; set; }
        public string paciensTempSzemelyiSzam { get; set; }
        public string paciensTempTAJ { get; set; }
        public DateTime paciensTempSzuletesiDatum { get; set; }
        public string paciensTempLakcim { get; set; }
        public string paciensTempTelefonszam { get; set; }
        public string paciensTempNeme { get; set; }
        public DateTime paciensTempTavozasDatuma { get; set; }

        // Ezeket akkor használom, amikor módosítom a páciens adatait (ideiglenes tároló)
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

        public List<object> paciensek()
        {
            List<object> paciensek = new List<object>();

            var paciensekSQLOsztalyonElhelyezve = from paciens in Magankorhaz.Adatbazis.AdatBazis.DataBase.Paciensek
                                                  join osztaly in Magankorhaz.Adatbazis.AdatBazis.DataBase.Osztalyok on paciens.OsztalyID equals osztaly.Id
                                                  select new { Név = paciens.Nev, Email = paciens.Email, Osztály = osztaly.Megnevezes, SzületésiDátum = paciens.SzuletesiDatum, FelvételiDátum = paciens.FelvetelDatuma };
            
            var paciensekSQLOsztalyNelkul = from paciens in Magankorhaz.Adatbazis.AdatBazis.DataBase.Paciensek
                                            where paciens.OsztalyID == 0 && paciens.Szobaszam == 0
                                            select new { Név = paciens.Nev, Email = paciens.Email, Osztály = "Nincs elhelyezve", SzületésiDátum = paciens.SzuletesiDatum, FelvételiDátum = paciens.FelvetelDatuma };

            foreach (var paciens in paciensekSQLOsztalyonElhelyezve)
            {
                paciensek.Add(paciens);
            }

            foreach (var paciens in paciensekSQLOsztalyNelkul)
            {
                paciensek.Add(paciens);
            }

            return paciensek;
        }

        public List<object> Szures(string keresesNev, DateTime keresesSzuletesiDatum)
        {
            List<object> szurtPaciensek = new List<object>();

            // Név és születési dátum
            if (keresesNev.Length > 0 && keresesSzuletesiDatum != DateTime.Today)
            {
                var paciensekNevEsSzuletesiDatumAlapjan = from paciens in Magankorhaz.Adatbazis.AdatBazis.DataBase.Paciensek
                                                          join osztaly in Magankorhaz.Adatbazis.AdatBazis.DataBase.Osztalyok on paciens.OsztalyID equals osztaly.Id
                                                          where paciens.Nev == keresesNev && paciens.SzuletesiDatum == keresesSzuletesiDatum
                                                          select new { Név = paciens.Nev, Email = paciens.Email, Osztály = osztaly.Megnevezes, SzületésiDátum = paciens.SzuletesiDatum, FelvételiDátum = paciens.FelvetelDatuma };

                foreach (var paciens in paciensekNevEsSzuletesiDatumAlapjan)
                {
                    szurtPaciensek.Add(paciens);
                }
            }

            // Csak szültési dátum
            if (keresesNev.Length < 1 && keresesSzuletesiDatum != DateTime.Today)
            {
                var paciensekSzuletesiDatumAlapjan = from paciens in Magankorhaz.Adatbazis.AdatBazis.DataBase.Paciensek
                                                     join osztaly in Magankorhaz.Adatbazis.AdatBazis.DataBase.Osztalyok on paciens.OsztalyID equals osztaly.Id
                                                     where paciens.SzuletesiDatum == keresesSzuletesiDatum
                                                     select new { Név = paciens.Nev, Email = paciens.Email, Osztály = osztaly.Megnevezes, SzületésiDátum = paciens.SzuletesiDatum, FelvételiDátum = paciens.FelvetelDatuma };

                foreach (var paciens in paciensekSzuletesiDatumAlapjan)
                {
                    szurtPaciensek.Add(paciens);
                }
            }

            // Csak név
            if (keresesNev.Length > 0 && keresesSzuletesiDatum == DateTime.Today)
            {
                var paciensekNevAlapjan = from paciens in Magankorhaz.Adatbazis.AdatBazis.DataBase.Paciensek
                                          join osztaly in Magankorhaz.Adatbazis.AdatBazis.DataBase.Osztalyok on paciens.OsztalyID equals osztaly.Id
                                          where paciens.Nev == keresesNev
                                          select new { Név = paciens.Nev, Email = paciens.Email, Osztály = osztaly.Megnevezes, SzületésiDátum = paciens.SzuletesiDatum, FelvételiDátum = paciens.FelvetelDatuma };

                foreach (var paciens in paciensekNevAlapjan)
                {
                    szurtPaciensek.Add(paciens);   
                }
            }

            return szurtPaciensek;
        }
    }
}
