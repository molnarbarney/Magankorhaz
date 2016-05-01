using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magankorhaz.FeldolgozoOsztalyok
{
    public class Beleptetes
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
                                Adatbazis.VezetosegiTag vezetosegiTag = egyezesekVezetosegiTagok.First();
                                vezetosegiTag.LegutolsoBejelentkezes = DateTime.Now;
                                adatok[1] = vezetosegiTag.Nev;
                                Adatbazis.AdatBazis.DataBase.SaveChanges();
                                return adatok;
                            }
                        }
                        else
                        {
                            adatok[0] = "ugyintezo";
                            Adatbazis.Ugyvezeto ugyvezeto = egyezesekUgyintezok.First();
                            ugyvezeto.LegutolsoBejelentkezes = DateTime.Now;
                            adatok[1] = ugyvezeto.Nev;
                            Adatbazis.AdatBazis.DataBase.SaveChanges();
                            return adatok;
                        }
                    }
                    else
                    {
                        adatok[0] = "paciens";
                        Adatbazis.Paciens paciens = egyezesekPaciensek.First();
                        paciens.LegutolsoBejelentkezes = DateTime.Now;
                        adatok[1] = paciens.Nev;
                        Adatbazis.AdatBazis.DataBase.SaveChanges();
                        return adatok;
                    }
                }
                else
                {
                    adatok[0] = "orvos";
                    Adatbazis.Orvos orvos = egyezesekOrvosok.First();
                    orvos.LegutolsoBejelentkezes = DateTime.Now;
                    adatok[1] = orvos.Nev;
                    Adatbazis.AdatBazis.DataBase.SaveChanges();
                    return adatok;
                }
            }
            else
            {
                adatok[0] = "admin";
                Adatbazis.Admin admin = egyezesekAdminok.First();
                admin.LegutolsoBejelentkezes = DateTime.Now;
                adatok[1] = admin.Nev;
                Adatbazis.AdatBazis.DataBase.SaveChanges();
                return adatok;
            }
        }
    }
}
