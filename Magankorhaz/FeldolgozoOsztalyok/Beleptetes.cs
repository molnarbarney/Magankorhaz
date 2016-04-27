using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magankorhaz.FeldolgozoOsztalyok
{
    class Beleptetes
    {
        public string[] BeleptetesEllenorzes(string felhasznalonev, string jelszo)
        {
            string[] adatok = new string[2];

            var egyezesekAdminok = from akt in Adatbazis.AdatBazis.DataBase.Adminok
                                 where akt.Felhasznalonev == felhasznalonev && akt.Jelszo == jelszo
                                 select akt;

            if (egyezesekAdminok.Count() == 0)
            {
                var egyezesekOrvosok = from akt in Adatbazis.AdatBazis.DataBase.Orvosok
                                     where akt.Felhasznalonev == felhasznalonev && akt.Jelszo == jelszo
                                     select akt;

                if (egyezesekOrvosok.Count() == 0)
                {
                    var egyezesekPaciensek = from akt in Adatbazis.AdatBazis.DataBase.Paciensek
                                           where akt.Felhasznalonev == felhasznalonev && akt.Jelszo == jelszo
                                           select akt;

                    if (egyezesekPaciensek.Count() == 0)
                    {
                        var egyezesekUgyintezok = from akt in Adatbazis.AdatBazis.DataBase.Ugyintezok
                                                  where akt.Felhasznalonev == felhasznalonev && akt.Jelszo == jelszo
                                                  select akt;

                        if (egyezesekUgyintezok.Count() == 0)
                        {
                            var egyezesekVezetosegiTagok = from akt in Adatbazis.AdatBazis.DataBase.VezetosegiTagok
                                                           where akt.Felhasznalonev == felhasznalonev && akt.Jelszo == jelszo
                                                           select akt;

                            if (egyezesekVezetosegiTagok.Count() == 0)
                            {
                                adatok[0] = "Sikertelen belépés!";
                                adatok[1] = "Sikertelen belépés!";
                                return adatok;
                            }
                            else
                            {
                                adatok[0] = "vezetoseg";
                                adatok[1] = egyezesekVezetosegiTagok.First().Nev;
                                return adatok;
                            }
                        }
                        else
                        {
                            adatok[0] = "ugyintezo";
                            adatok[1] = egyezesekUgyintezok.First().Nev;
                            return adatok;
                        }
                    }
                    else
                    {
                        adatok[0] = "paciens";
                        adatok[1] = egyezesekPaciensek.First().Nev;
                        return adatok;
                    }
                }
                else
                {
                    adatok[0] = "orvos";
                    adatok[1] = egyezesekOrvosok.First().Nev;
                    return adatok;
                }
            }
            else
            {
                adatok[0] = "admin";
                adatok[1] = egyezesekAdminok.First().Nev;
                return adatok;
            }
        }
    }
}
