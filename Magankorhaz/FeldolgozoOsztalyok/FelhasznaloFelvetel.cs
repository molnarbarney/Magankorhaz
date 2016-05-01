using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magankorhaz.FeldolgozoOsztalyok
{
    class FelhasznaloFelvetel
    {
        public bool ujOrvosFelvetele(
             string orvosNev,
             string orvosEmail,
             string orvosFelhasznalonev,
             string orvosSzemelyiszam,
             string orvosJelszo,
             string orvosTAJ,
             string orvosCim,
             string orvosTelefon,
             DateTime orvosSzuletesiDatum,
             DateTime orvosBelepesDatum,
             string orvosOraber,
             string orvosSzabadsag,
             string orvosOsztaly,
             string orvosAdoszam,
             string orvosKepesites,
             Adatbazis.MagankorhazDB adatbazis)
        {
            int errors = 0;

            // Van-e már ilyen felhasználónév
            var felhasznalonevek = from akt in adatbazis.Orvosok
                                   where akt.Felhasznalonev == orvosFelhasznalonev
                                   select akt;

            if (felhasznalonevek.Count() > 0)
            {
                System.Windows.MessageBox.Show("Ilyen felhasználónévvel már létezik egy orvos. Válasszon másik felhasználónevet)!");
                errors++;
            }

            // Van-e már hasonló személyi számmal bent orvos
            var szemelyiSzamok = from akt in adatbazis.Orvosok
                                 where akt.SzemelyiSzam == orvosSzemelyiszam
                                 select akt;

            if (szemelyiSzamok.Count() > 0)
            {
                System.Windows.MessageBox.Show("Ezt az orvost már felvettük (személyi szám egyezés)!");
                errors++;
            }

            // Osztály ID keresése
            var osztalyok = from akt in adatbazis.Osztalyok
                            where akt.Megnevezes == orvosOsztaly
                            select akt;

            int osztalyID = 0;
            foreach (var osztaly_akt in osztalyok)
            {
                osztalyID = osztaly_akt.Id;
            }

            int legnagyobbOrvosID = 0;
            var dokik = from akt in adatbazis.Orvosok
                        select akt;
            foreach (var id in dokik)
            {
                if (id.Id > legnagyobbOrvosID)
                {
                    legnagyobbOrvosID = id.Id;
                }
            }

            if (errors == 0)
            {
                adatbazis.Orvosok.Add(new Adatbazis.Orvos
                {
                    Id = legnagyobbOrvosID+1,
                    Nev = orvosNev,
                    Email = orvosEmail,
                    Felhasznalonev = orvosFelhasznalonev,
                    Jelszo = orvosJelszo,
                    SzemelyiSzam = orvosSzemelyiszam,
                    TAJ = Convert.ToInt32(orvosTAJ),
                    Cim = orvosCim,
                    Telefon = orvosTelefon,
                    SzuletesiDatum = orvosSzuletesiDatum,
                    MunkabaAllasDatuma = orvosBelepesDatum,
                    OsztalyID = osztalyID,
                    Kepesites = orvosKepesites,
                    Adoazonosito = Int32.Parse(orvosAdoszam),
                    OraberBrutto = Int32.Parse(orvosOraber),

                });

                adatbazis.SaveChanges();
                System.Windows.MessageBox.Show("Sikeres felvétel!");
                return true;
            }
            return false;
        }


        public bool ujUgyintezoFelvetele(
             string orvosNev,
             string orvosEmail,
             string orvosFelhasznalonev,
             string orvosSzemelyiszam,
             string orvosJelszo,
             string orvosTAJ,
             string orvosCim,
             string orvosTelefon,
             DateTime orvosSzuletesiDatum,
             DateTime orvosBelepesDatum,
             string orvosOraber,
             string orvosSzabadsag,           
             string orvosAdoszam,            
             Adatbazis.MagankorhazDB adatbazis)
        {
            int errors = 0;

            // Van-e már ilyen felhasználónév
            var felhasznalonevek = from akt in adatbazis.Ugyintezok
                                   where akt.Felhasznalonev == orvosFelhasznalonev
                                   select akt;

            if (felhasznalonevek.Count() > 0)
            {
                System.Windows.MessageBox.Show("Ilyen felhasználónévvel már létezik egy ügyintéző. Válasszon másik felhasználónevet)!");
                errors++;
            }

            // Van-e már hasonló személyi számmal bent ügyintéző
            var szemelyiSzamok = from akt in adatbazis.Ugyintezok
                                 where akt.SzemelyiSzam == orvosSzemelyiszam
                                 select akt;

            if (szemelyiSzamok.Count() > 0)
            {
                System.Windows.MessageBox.Show("Ezt az ügyintézőt már felvettük (személyi szám egyezés)!");
                errors++;
            }


            int legnagyobbOrvosID = 0;
            var dokik = from akt in adatbazis.Ugyintezok
                        select akt;
            foreach (var id in dokik)
            {
                if (id.Id > legnagyobbOrvosID)
                {
                    legnagyobbOrvosID = id.Id;
                }
            }

            if (errors == 0)
            {
                adatbazis.Ugyintezok.Add(new Adatbazis.Ugyvezeto
                {
                    Id = legnagyobbOrvosID + 1,
                    Nev = orvosNev,
                    Email = orvosEmail,
                    Felhasznalonev = orvosFelhasznalonev,
                    Jelszo = orvosJelszo,
                    SzemelyiSzam = orvosSzemelyiszam,
                    TAJ = Convert.ToInt32(orvosTAJ),
                    Cim = orvosCim,
                    Telefon = orvosTelefon,
                    SzuletesiDatum = orvosSzuletesiDatum,
                    MunkabaAllasDatuma = orvosBelepesDatum,
                    Adoazonosito = Int32.Parse(orvosAdoszam),
                    OraberBrutto = Int32.Parse(orvosOraber),

                });

                adatbazis.SaveChanges();
                System.Windows.MessageBox.Show("Sikeres felvétel!");
                return true;
            }
            return false;
        }

        public bool ujVezetoFelvetele(
         string orvosNev,
         string orvosEmail,
         string orvosFelhasznalonev,
         string orvosSzemelyiszam,
         string orvosJelszo,
         string orvosTAJ,
         string orvosCim,
         string orvosTelefon,
         DateTime orvosSzuletesiDatum,
         DateTime orvosBelepesDatum,
         string orvosOraber,
         string orvosSzabadsag,
         string orvosAdoszam,
         string orvosStatusz,
         Adatbazis.MagankorhazDB adatbazis)
        {
            int errors = 0;

            // Van-e már ilyen felhasználónév
            var felhasznalonevek = from akt in adatbazis.VezetosegiTagok
                                   where akt.Felhasznalonev == orvosFelhasznalonev
                                   select akt;

            if (felhasznalonevek.Count() > 0)
            {
                System.Windows.MessageBox.Show("Ilyen felhasználónévvel már létezik egy vezetőségi tag. Válasszon másik felhasználónevet)!");
                errors++;
            }

            // Van-e már hasonló személyi számmal bent vez.tag
            var szemelyiSzamok = from akt in adatbazis.VezetosegiTagok
                                 where akt.SzemelyiSzam == orvosSzemelyiszam
                                 select akt;

            if (szemelyiSzamok.Count() > 0)
            {
                System.Windows.MessageBox.Show("Ezt a vezetőt már felvettük (személyi szám egyezés)!");
                errors++;
            }

            int legnagyobbOrvosID = 0;
            var dokik = from akt in adatbazis.VezetosegiTagok
                        select akt;
            foreach (var id in dokik)
            {
                if (id.Id > legnagyobbOrvosID)
                {
                    legnagyobbOrvosID = id.Id;
                }
            }

            if (errors == 0)
            {
                adatbazis.VezetosegiTagok.Add(new Adatbazis.VezetosegiTag
                {
                    Id = legnagyobbOrvosID + 1,
                    Nev = orvosNev,
                    Email = orvosEmail,
                    Felhasznalonev = orvosFelhasznalonev,
                    Jelszo = orvosJelszo,
                    SzemelyiSzam = orvosSzemelyiszam,
                    TAJ = Convert.ToInt32(orvosTAJ),
                    Cim = orvosCim,
                    Telefon = orvosTelefon,
                    SzuletesiDatum = orvosSzuletesiDatum,
                    MunkabaAllasDatuma = orvosBelepesDatum,
                    Statusz = orvosStatusz,
                    Adoazonosito = Int32.Parse(orvosAdoszam),
                    OraberBrutto = Int32.Parse(orvosOraber),

                });

                adatbazis.SaveChanges();
                System.Windows.MessageBox.Show("Sikeres felvétel!");
                return true;
            }
            return false;
        }

        public bool ujAdminFelvetele(
            string orvosNev,
            string orvosEmail,
            string orvosFelhasznalonev,
            string orvosSzemelyiszam,
            string orvosJelszo,
            string orvosTAJ,
            string orvosCim,
            string orvosTelefon,
            DateTime orvosSzuletesiDatum,
            DateTime orvosBelepesDatum,
            string orvosOraber,
            string orvosSzabadsag,
            string orvosAdoszam,
            Adatbazis.MagankorhazDB adatbazis)
        {
            int errors = 0;

            // Van-e már ilyen felhasználónév
            var felhasznalonevek = from akt in adatbazis.Adminok
                                   where akt.Felhasznalonev == orvosFelhasznalonev
                                   select akt;

            if (felhasznalonevek.Count() > 0)
            {
                System.Windows.MessageBox.Show("Ilyen felhasználónévvel már létezik egy admin tag. Válasszon másik felhasználónevet)!");
                errors++;
            }

            // Van-e már hasonló személyi számmal bent vez.tag
            var szemelyiSzamok = from akt in adatbazis.Adminok
                                 where akt.SzemelyiSzam == orvosSzemelyiszam
                                 select akt;

            if (szemelyiSzamok.Count() > 0)
            {
                System.Windows.MessageBox.Show("Ezt az admint már felvettük (személyi szám egyezés)!");
                errors++;
            }

            int legnagyobbOrvosID = 0;
            var dokik = from akt in adatbazis.Adminok
                        select akt;
            foreach (var id in dokik)
            {
                if (id.Id > legnagyobbOrvosID)
                {
                    legnagyobbOrvosID = id.Id;
                }
            }

            if (errors == 0)
            {
                adatbazis.Adminok.Add(new Adatbazis.Admin
                {
                    Id = legnagyobbOrvosID + 1,
                    Nev = orvosNev,
                    Email = orvosEmail,
                    Felhasznalonev = orvosFelhasznalonev,
                    Jelszo = orvosJelszo,
                    SzemelyiSzam = orvosSzemelyiszam,
                    TAJ = Convert.ToInt32(orvosTAJ),
                    Cim = orvosCim,
                    Telefon = orvosTelefon,
                    SzuletesiDatum = orvosSzuletesiDatum,
                    MunkabaAllasDatuma = orvosBelepesDatum,
                    Adoazonosito = Int32.Parse(orvosAdoszam),
                    OraberBrutto = Int32.Parse(orvosOraber),

                });

                adatbazis.SaveChanges();
                System.Windows.MessageBox.Show("Sikeres felvétel!");
                return true;
            }
            return false;
        }
    }
}
