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

            // Páciens osztályának és (ha van) szobájának megkeresése
            var osztály = from akt in Adatbazis.AdatBazis.DataBase.Osztalyok
                            where akt.Id == paciensAdatok.OsztalyID
                            select akt.Megnevezes;

            paciensOsztaly = osztály.First();

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
                else paciens.TavozasDatuma = modositottPaciens.TavozasDatuma;
            }

            Adatbazis.AdatBazis.DataBase.SaveChanges();

            return true;
        }

    }
}
