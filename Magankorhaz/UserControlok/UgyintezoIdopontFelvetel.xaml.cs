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
    /// Interaction logic for UgyintezoIdopontFelvetel.xaml
    /// </summary>
    public partial class UgyintezoIdopontFelvetel : Window
    {
        Magankorhaz.FeldolgozoOsztalyok.RendelesiIdopontFeldolgozo idopontFeldolgozo = new FeldolgozoOsztalyok.RendelesiIdopontFeldolgozo();
        public int paciensID { get; set; }
        public UgyintezoIdopontFelvetel()
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            idopontDatum.BlackoutDates.Add(new CalendarDateRange(new DateTime(1990, 1, 1),
            DateTime.Now.AddDays(-1)));
        }

        private void UjIdopontMentesGomb_Click(object sender, RoutedEventArgs e)
        {
            if (idopontDatum.SelectedDate != null && idopontOra.SelectedItem != null && idopontPerc.SelectedItem != null && idopontReszletek.Text.Length >= 10)
            {
                int mentes = idopontFeldolgozo.UjIdopont(idopontDatum.SelectedDate.ToString(), idopontOra.SelectedItem.ToString(), idopontPerc.SelectedItem.ToString(), idopontReszletek.Text, paciensID);

                if (mentes > 0)
                {
                    System.Windows.MessageBox.Show("Sikeres időpont felvétel!");
                    idopontFeldolgozo.paciensOrvosFrissitese(paciensID);
                    this.Close();
                }
                else System.Windows.MessageBox.Show("Hiba történt!");
            }
            else
            {
                System.Windows.MessageBox.Show("Az időpont nincs megfelelően kitöltve!");
            }
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
    }
}
