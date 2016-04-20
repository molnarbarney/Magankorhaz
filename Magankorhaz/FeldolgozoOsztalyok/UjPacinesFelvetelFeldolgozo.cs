using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magankorhaz.FeldolgozoOsztalyok
{
    class UjPacinesFelvetelFeldolgozo
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
                orvosokLista.Add(orvos.Nev + " (" + orvos.Kepesites + ")");
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

        public void ujPaciensFelvetele(
                string paciensNev, 
                string paciensEmail, 
                string paciensFelhasznalonev, 
                string paciensSzemelyiszam, 
                string paciensJelszo, 
                string paciensJelszoUjra, 
                string paciensTAJ, 
                string paciensCim, 
                string paciensTelefon,
                System.Windows.Controls.DatePicker paciensSzuletesiDatum, 
                string paciensNeme,
                System.Windows.Controls.DatePicker paciensFelvetelDatum,
                System.Windows.Controls.DatePicker paciensTavozasDatum, 
                string paciensKezeloorvos, 
                string paciensOsztaly, 
                string paciensUgyintezo)
        {
            System.Windows.MessageBox.Show(
                paciensNev + " " +
                paciensEmail + " " +
                paciensFelhasznalonev + " " +
                paciensSzemelyiszam + " " +
                paciensJelszo + " " +
                paciensJelszoUjra + " " +
                paciensTAJ + " " +
                paciensCim + " " +
                paciensTelefon + " " +
                paciensSzuletesiDatum + " " +
                paciensNeme + " " +
                paciensFelvetelDatum + " " +
                paciensTavozasDatum + " " +
                paciensKezeloorvos + " " +
                paciensOsztaly + " " + 
                paciensUgyintezo);
        }
    }
}
