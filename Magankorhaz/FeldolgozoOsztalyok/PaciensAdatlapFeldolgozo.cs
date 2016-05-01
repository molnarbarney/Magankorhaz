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
        public string orvosNev { get; set; }
        public string paciensOsztaly { get; set; }
        public List<Adatbazis.Osztaly> osszesOsztaly { get; set; }

        public PaciensAdatlapFeldolgozo(string paciensEmail)
        {
            // Páciens megkeresése
            var paciens = from akt in Adatbazis.AdatBazis.DataBase.Paciensek
                          where akt.Email == paciensEmail
                          select akt;

            paciensAdatok = paciens.First();

            // Pácienst felvevő ügyintéző megkeresése
            var ugyintezo = from akt in Adatbazis.AdatBazis.DataBase.Ugyintezok
                            where akt.Id == paciensAdatok.UgyvezetoID
                            select akt.Nev;

            ugyintezoNev = ugyintezo.First();

            // Pácienst kezelő orvos megkeresése
            var orvos = from akt in Adatbazis.AdatBazis.DataBase.Orvosok
                        where akt.Id == paciensAdatok.OrvosID
                        select akt.Nev;

            orvosNev = orvos.First();

            // Páciens osztályának és (ha van) szobájának megkeresése
            var osztály = from akt in Adatbazis.AdatBazis.DataBase.Osztalyok
                          where akt.Id == paciensAdatok.OsztalyID
                          select akt.Megnevezes;

            if (osztály.Count() > 0)
            {
                paciensOsztaly = osztály.First();
            }

            // Összes osztály megkeresése és ComboBox feltöltése, hogyha majd változtatni szeretne
            var osztalyok = from akt in Adatbazis.AdatBazis.DataBase.Osztalyok
                            select akt;

            osszesOsztaly = osztalyok.ToList();
        }

        public bool PaciensModositasa(int modositandoPaciensID, Adatbazis.Paciens modositottPaciens)
        {
            var paciensek = from akt in Adatbazis.AdatBazis.DataBase.Paciensek
                            where akt.Id == modositandoPaciensID
                            select akt;

            foreach (var paciens in paciensek)
            {
                paciens.Nev = modositottPaciens.Nev;
                paciens.Cim = modositottPaciens.Cim;
                paciens.Email = modositottPaciens.Email;
                paciens.Felhasznalonev = modositottPaciens.Felhasznalonev;
                paciens.FelvetelDatuma = modositottPaciens.FelvetelDatuma;
                paciens.Jelszo = modositottPaciens.Jelszo;
                paciens.Neme = modositottPaciens.Neme;
                paciens.SzemelyiSzam = modositottPaciens.SzemelyiSzam;
                paciens.SzuletesiDatum = modositottPaciens.SzuletesiDatum;
                paciens.TAJ = modositottPaciens.TAJ;
                paciens.Telefon = modositottPaciens.Telefon;

                if (modositottPaciens.TavozasDatuma.Year <= 1900)
                {
                    paciens.TavozasDatuma = paciens.TavozasDatuma;
                }
                else
                {
                    // Ha már távozott, akkor nincs elhelyezve
                    paciens.TavozasDatuma = modositottPaciens.TavozasDatuma;
                    paciens.OsztalyID = 0;
                    paciens.Szobaszam = 0;

                    paciensOsztaly = "Nincs elhelyezve";
                }
            }

            int mentes = Adatbazis.AdatBazis.DataBase.SaveChanges();

            if (mentes > 0)
            {
                return true;
            }
            else return false;
        }

        public bool paciensElhelyezesEllenorzes(string osztalyNev, int szobaszam)
        {
            // OsztalyID megkeresése
            var osztalyIDs = from akt in Adatbazis.AdatBazis.DataBase.Osztalyok
                             where akt.Megnevezes == osztalyNev
                             select akt.Id;

            int osztalyID = osztalyIDs.First();

            // Megnézi, hogy üres-e a szoba -> ha talál a "where" feltételben szereplő adatot, akkor az már foglalt...
            var uresSzobak = from akt in Adatbazis.AdatBazis.DataBase.Paciensek
                             where akt.OsztalyID == osztalyID && akt.Szobaszam == szobaszam
                             select akt;

            if (uresSzobak.Count() > 0)
            {
                return false;
            }
            else return true;
        }

        public bool paciensElhelyezesMentes(int paciensID, string osztalyNev, int szobaszam)
        {
            // OsztalyID megkeresése
            var osztalyIDs = from akt in Adatbazis.AdatBazis.DataBase.Osztalyok
                             where akt.Megnevezes == osztalyNev
                             select akt.Id;

            int osztalyID = osztalyIDs.First();

            var elhelyezendoPaciensek = from akt in Adatbazis.AdatBazis.DataBase.Paciensek
                                        where akt.Id == paciensID
                                        select akt;

            foreach (var elhelyezendoPaciens in elhelyezendoPaciensek)
            {
                elhelyezendoPaciens.OsztalyID = osztalyID;
                elhelyezendoPaciens.Szobaszam = szobaszam;
                elhelyezendoPaciens.TavozasDatuma = new DateTime(1900, 1, 1);
            }

            int mentes = Adatbazis.AdatBazis.DataBase.SaveChanges();

            if (mentes > 0)
            {
                return true;
            }
            else return false;
        }

    }
}
