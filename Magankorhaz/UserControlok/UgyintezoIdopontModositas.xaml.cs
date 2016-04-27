using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Magankorhaz.UserControlok
{
    /// <summary>
    /// Interaction logic for UgyintezoIdopontModositas.xaml
    /// </summary>
    public partial class UgyintezoIdopontModositas : Window
    {
        Magankorhaz.FeldolgozoOsztalyok.RendelesiIdopontFeldolgozo idopontFeldolgozo = new FeldolgozoOsztalyok.RendelesiIdopontFeldolgozo();
        public string modositandoIdopont { get; set; }
        public string regiReszletek { get; set; }
        public string regiDatum { get; set; }
        public int paciensID { get; set; }
        public UgyintezoIdopontModositas()
        {
            InitializeComponent();

            List<Adatbazis.Orvos> orvosok = new List<Adatbazis.Orvos>();
            orvosok = idopontFeldolgozo.OrvosokFeltoltese();
            foreach (var orvos in orvosok)
            {
                idopontOrvos.Items.Add(orvos.Nev);
            }

            for (int i = 9; i < 17; i++)
            {
                idopontOra.Items.Add(Convert.ToString(i));
            }

            idopontPerc.Items.Add("00");
            idopontPerc.Items.Add("30");
        }

        private void ModositottIdopontMentesGomb_Click(object sender, RoutedEventArgs e)
        {
            if (idopontDatum.SelectedDate > DateTime.Now)
            {
                if (idopontOra.SelectedItem != null && idopontPerc.SelectedItem != null && idopontReszletek.Text.Length >= 10)
                {
                    // Előbb töröljük a régit
                    int torles = idopontFeldolgozo.IdopontTorlese(Convert.ToDateTime(regiDatum), regiReszletek);

                    // Aztán felvesszük a legújabbat
                    int mentes = idopontFeldolgozo.UjIdopont(idopontDatum.SelectedDate.ToString(), idopontOra.SelectedItem.ToString(), idopontPerc.SelectedItem.ToString(), idopontReszletek.Text, paciensID);

                    if (mentes > 0)
                    {
                        System.Windows.MessageBox.Show("Sikeres időpont felvétel!");
                        idopontFeldolgozo.paciensOrvosFrissitese(paciensID);
                        this.Close();
                    }
                    else System.Windows.MessageBox.Show("Hiba történt!");
                }
                else System.Windows.MessageBox.Show("Hiányos adatok!");
            }
            else System.Windows.MessageBox.Show("A mai napnál nem lehet régebbi időpontot felvenni!");
        }

        private void idopontOrvos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<string> foglaltIdopontok = idopontFeldolgozo.foglaltIdopontok(idopontOrvos.SelectedItem.ToString());

            foglaltIdopontokListBox.Items.Clear();
            foreach (var idopont in foglaltIdopontok)
            {
                foglaltIdopontokListBox.Items.Add(idopont);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] idopontSorAdatok = modositandoIdopont.Split(new string[] { "= " }, StringSplitOptions.None);

            string datumString = idopontSorAdatok[1].Remove(idopontSorAdatok[1].Length - 8);
            string orvos = idopontSorAdatok[2].Remove(idopontSorAdatok[2].Length - 12);
            string reszletek = idopontSorAdatok[3].Remove(idopontSorAdatok[3].Length - 2);

            idopontDatum.SelectedDate = Convert.ToDateTime(datumString);
            idopontOrvos.SelectedValue = orvos;
            idopontReszletek.Text = reszletek;

            regiDatum = datumString;
            regiReszletek = reszletek;
        }
    }
}
