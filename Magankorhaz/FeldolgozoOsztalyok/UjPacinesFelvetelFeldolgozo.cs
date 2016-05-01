using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magankorhaz.FeldolgozoOsztalyok
{
    public class UjPacinesFelvetelFeldolgozo
    {
        // ComboBox-ok feltöltése adatokkal

        public List<string> osztalyokBetoltese(Adatbazis.MagankorhazDB adatbazis)
        {
            List<string> osztalyokLista = new List<string>();

            var osztalyok = from akt in adatbazis.Osztalyok
                     select akt;

            foreach (var osztaly in osztalyok)
            {
                osztalyokLista.Add(osztaly.Megnevezes);
            }

            return osztalyokLista;
        }

        public List<string> orvosokBetoltese(Adatbazis.MagankorhazDB adatbazis)
        {
            List<string> orvosokLista = new List<string>();

            var orvosok = from akt in adatbazis.Orvosok
                            select akt;

            foreach (var orvos in orvosok)
            {
                orvosokLista.Add(orvos.Nev);
            }

            return orvosokLista;
        }

        public List<string> ugyintezokBetoltese(Adatbazis.MagankorhazDB adatbazis)
        {
            List<string> ugyintezokLista = new List<string>();

            var ugyintezok = from akt in adatbazis.Ugyintezok
                             select akt;

            foreach (var ugyintezo in ugyintezok)
            {
                ugyintezokLista.Add(ugyintezo.Nev);
            }

            return ugyintezokLista;
        }

        // Adatfeldolgozás
        public bool ujPaciensFelvetele(
                string paciensNev, 
                string paciensEmail, 
                string paciensFelhasznalonev, 
                string paciensSzemelyiszam, 
                string paciensJelszo,
                string paciensTAJ, 
                string paciensCim, 
                string paciensTelefon,
                DateTime paciensSzuletesiDatum, 
                string paciensNeme,
                DateTime paciensFelvetelDatum,
                string paciensKezeloorvos, 
                string paciensOsztaly, 
                string paciensUgyintezo,
                Adatbazis.MagankorhazDB adatbazis)
        {
            int errors = 0;

            // Van-e már ilyen felhasználónév
            var felhasznalonevek = from akt in adatbazis.Paciensek
                                   where akt.Felhasznalonev == paciensFelhasznalonev
                                   select akt;

            if (felhasznalonevek.Count() > 0)
            {
                System.Windows.MessageBox.Show("Ilyen felhasználónévvel már létezik egy páciens. Válasszon másik felhasználónevet)!");
                errors++;
            }

            // Van-e már hasonló személyi számmal bent páciens
            var szemelyiSzamok = from akt in adatbazis.Paciensek
                     where akt.SzemelyiSzam == paciensSzemelyiszam
                     select akt;

            if (szemelyiSzamok.Count() > 0)
            {
                System.Windows.MessageBox.Show("Ezt a pácienst már felvettük (személyi szám egyezés)!");
                errors++;
            }

            // Orvos ID keresése
            var orvosok = from akt in adatbazis.Orvosok
                        where akt.Nev == paciensKezeloorvos
                        select akt;

            int orvosID = 0;
            foreach (var orvos_akt in orvosok)
            {
                orvosID = orvos_akt.Id;
            }

            // Osztály ID keresése
            var osztalyok = from akt in adatbazis.Osztalyok
                            where akt.Megnevezes == paciensOsztaly
                            select akt;

            int osztalyID = 0;
            foreach (var osztaly_akt in osztalyok)
            {
                osztalyID = osztaly_akt.Id;
            }

            // Ügyintéző ID keresése
            var ugyintezok = from akt in adatbazis.Ugyintezok
                             where akt.Nev == paciensUgyintezo
                             select akt;

            int ugyintezoID = 0;
            foreach (var ugyintezok_akt in ugyintezok)
            {
                ugyintezoID = ugyintezok_akt.Id;
            }

            if (errors == 0)
            {
                adatbazis.Paciensek.Add(new Adatbazis.Paciens
                {
                    Nev = paciensNev,
                    Email = paciensEmail,
                    Felhasznalonev = paciensFelhasznalonev,
                    Jelszo = paciensJelszo,
                    SzemelyiSzam = paciensSzemelyiszam,
                    TAJ = Convert.ToInt32(paciensTAJ),
                    Cim = paciensCim,
                    Telefon = paciensTelefon,
                    SzuletesiDatum = paciensSzuletesiDatum,
                    Neme = paciensNeme,
                    FelvetelDatuma = paciensFelvetelDatum,
                    OrvosID = orvosID,
                    OsztalyID = osztalyID,
                    UgyvezetoID = ugyintezoID
                });

                adatbazis.SaveChanges();
                System.Windows.MessageBox.Show("Sikeres felvétel!");
                return true;
            }
            return false;
        }



      
    }
}
