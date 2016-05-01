using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magankorhaz.Adatbazis
{
    public class Paciens
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public string Email { get; set; }
        public string Felhasznalonev { get; set; }
        public string Jelszo { get; set; }
        public DateTime LegutolsoBejelentkezes { get; set; }
        public string SzemelyiSzam { get; set; }
        public int TAJ { get; set; }
        public string Cim { get; set; }
        public string Telefon { get; set; }
        public DateTime SzuletesiDatum { get; set; }
        public string Neme { get; set; }
        public int OrvosID { get; set; }
        public int OsztalyID { get; set; }
        public int Szobaszam { get; set; }
        public int UgyvezetoID { get; set; }
        public DateTime FelvetelDatuma { get; set; }
        public DateTime TavozasDatuma { get; set; }

        public override string ToString()
        {
            return Nev + " \n" + Cim;
        }
    }
}
