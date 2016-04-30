using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magankorhaz.FeldolgozoOsztalyok
{
    public class RendelesiIdopontFeldolgozo
    {
        //public List<Adatbazis.Idopont> paciensIdopontok { get; set; }
        public int OrvosIDMenteshez { get; set; }
        public void IdopontokFeltoltese()
        {
            var osszesIdopont = from akt in Magankorhaz.Adatbazis.AdatBazis.DataBase.Idopontok
                                select akt;
        }

        public List<Adatbazis.Orvos> OrvosokFeltoltese()
        {
            List<Adatbazis.Orvos> orvosok = new List<Adatbazis.Orvos>();

            var osszesOrvos = from akt in Magankorhaz.Adatbazis.AdatBazis.DataBase.Orvosok
                              select akt;

            foreach (var orvos in osszesOrvos)
            {
                orvosok.Add(orvos);
            }
            return orvosok;
        }

        public List<string> foglaltIdopontok(string orvosNev)
        {
            List<string> foglaltIdopontok = new List<string>();

            var orvosIDs = from akt in Magankorhaz.Adatbazis.AdatBazis.DataBase.Orvosok
                          where akt.Nev == orvosNev
                          select akt;

            int orvosID = orvosIDs.First().Id;

            this.OrvosIDMenteshez = orvosID;

            var foglaltIdopontokSQL = from akt in Magankorhaz.Adatbazis.AdatBazis.DataBase.Idopontok
                                      where akt.OrvosID == orvosID
                                      orderby akt.FoglaltIdopont ascending
                                      select akt;

            foreach (var idopont in foglaltIdopontokSQL)
            {
                foglaltIdopontok.Add(idopont.FoglaltIdopont.ToString());
            }

            return foglaltIdopontok;
        }
        public List<object> RendelesiIdopontokLekerdezese(int paciensID)
        {
            List<object> idopontok = new List<object>();

            var paciensIdopontok = from idopont in Adatbazis.AdatBazis.DataBase.Idopontok
                                   join orvos in Adatbazis.AdatBazis.DataBase.Orvosok on idopont.OrvosID equals orvos.Id
                                   where idopont.PaciensID == paciensID
                                   orderby idopont.FoglaltIdopont ascending
                                   select new { Időpont = idopont.FoglaltIdopont, Orvos = orvos.Nev, Részletek = idopont.Megnevezes };

            foreach (var idopont in paciensIdopontok)
            {
                idopontok.Add(idopont);
            }

            return idopontok;
        }

        public int UjIdopont(string datum, string ora, string perc, string reszletek, int paciensID)
        {
            Adatbazis.MagankorhazDB adatbazis = new Adatbazis.MagankorhazDB();

            DateTime idopont = Convert.ToDateTime(datum);
            if (idopont.Hour == 0 && idopont.Minute == 0)
            {
                idopont = idopont.AddHours(int.Parse(ora));
                idopont = idopont.AddMinutes(int.Parse(perc));
            }
            else
            {
                idopont = idopont.AddHours(-idopont.Hour);
                idopont = idopont.AddHours(int.Parse(ora));
                idopont = idopont.AddMinutes(-idopont.Minute);
                idopont = idopont.AddMinutes(int.Parse(perc));
            }            

            // Ellenőrzés, hogy van-e ilyen dátum az orvosnak

            var foglaltOrvos = from akt in adatbazis.Idopontok
                               where akt.OrvosID == OrvosIDMenteshez && akt.FoglaltIdopont == idopont
                               select akt;

            int mentes = 0;

            if (foglaltOrvos.Count() > 0)
            {
                System.Windows.MessageBox.Show("A kiválasztott orvos foglalt ebben az időpontban! (Segítség: jobb oldali listában láthatók a már foglalt időpontjai.)");
            }
            else
            {
                adatbazis.Idopontok.Add(new Adatbazis.Idopont
                {
                    FoglaltIdopont = idopont,
                    Megnevezes = reszletek,
                    PaciensID = paciensID,
                    OrvosID = this.OrvosIDMenteshez
                });

                mentes = adatbazis.SaveChanges();
            }

            return mentes;
        }

        public void paciensOrvosFrissitese(int paciensID)
        {
            var legkozelebbiIdopont = from akt in Magankorhaz.Adatbazis.AdatBazis.DataBase.Idopontok
                                      where akt.PaciensID == paciensID
                                      orderby akt.FoglaltIdopont ascending
                                      select akt;

            int orvosID = legkozelebbiIdopont.First().OrvosID;

            var paciensek = from akt in Magankorhaz.Adatbazis.AdatBazis.DataBase.Paciensek
                          where akt.Id == paciensID
                          select akt;

            foreach (var paciens in paciensek)
            {
                paciens.OrvosID = orvosID;
            }

            Magankorhaz.Adatbazis.AdatBazis.DataBase.SaveChanges();
        }

        public int IdopontTorlese(DateTime datum, string reszletek)
        {
            var idopontok = from akt in Adatbazis.AdatBazis.DataBase.Idopontok
                            where akt.FoglaltIdopont == datum && akt.Megnevezes == reszletek
                            select akt;

            foreach (var idopont in idopontok)
            {
                Adatbazis.AdatBazis.DataBase.Idopontok.Remove(idopont);
            }

            int torles = Adatbazis.AdatBazis.DataBase.SaveChanges();

            return torles;
        }

    }
}
