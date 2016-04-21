using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magankorhaz.Adatbazis
{
    class Ugyvezeto
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public string Email { get; set; }
        public string Felhasznalonev { get; set; }
        public string Jelszo { get; set; }
        public DateTime LegutolsoBejelentkezes { get; set; }
        public bool Inaktiv { get; set; }
        public int MunkabeosztasID { get; set; }
        public string SzemelyiSzam { get; set; }
        public int TAJ { get; set; }
        public int Adoazonosito { get; set; }
        public string Cim { get; set; }
        public string Telefon { get; set; }
        public DateTime SzuletesiDatum { get; set; }
        public DateTime MunkabaAllasDatuma { get; set; }
        public int OraberBrutto { get; set; }
        public int SzabadsagNapok { get; set; }
    }
}
