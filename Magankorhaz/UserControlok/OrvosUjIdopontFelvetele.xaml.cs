using Magankorhaz.FeldolgozoOsztalyok;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Magankorhaz.UserControlok
{
    /// <summary>
    /// Interaction logic for OrvosUjIdopontFelvetele.xaml
    /// </summary>
    public partial class OrvosUjIdopontFelvetele : UserControl
    {
        OrvosRendelesFeldolgozo IdopontFeldolgozo;
        Adatbazis.Orvos Orvos;

        public OrvosUjIdopontFelvetele(Adatbazis.Orvos orvos)
        {
            InitializeComponent();
            Orvos = orvos;
            IdopontFeldolgozo = new OrvosRendelesFeldolgozo(Adatbazis.AdatBazis.DataBase, orvos);
            idopontOrvos.ItemsSource = IdopontFeldolgozo.Orvosok;
            idopontOra.Items.Add("");

            for (int i = 9; i < 17; i++)
            {
                if (DateTime.Now.Hour < 17 && DateTime.Now.Hour > 8)
                    if (DateTime.Now.Hour > i)
                        continue;
                idopontOra.Items.Add(Convert.ToString(i));
            }
            idopontPerc.Items.Add("");
            idopontPerc.Items.Add("00");
            idopontPerc.Items.Add("30");

            idopontOrvos.SelectedItem = Orvos;
            idopontOra.SelectedIndex = 0;
            idopontPerc.SelectedIndex = 0;

            foglaltIdopontokListBox.ItemsSource = IdopontFeldolgozo.IdopontLekeres(orvos);
            idopontPaciens.ItemsSource = IdopontFeldolgozo.Paciensek;
            idopontPaciens.SelectedIndex = 0;
            if (DateTime.Now.Hour > 16)
            {
                idopontDatum.BlackoutDates.Add(new CalendarDateRange(new DateTime(1990, 1, 1), DateTime.Now));
            }
            else
            {
                idopontDatum.BlackoutDates.Add(new CalendarDateRange(new DateTime(1990, 1, 1), DateTime.Now.AddDays(-1)));
            }
        }

        private void UjIdopontMentesGomb_Click(object sender, RoutedEventArgs e)
        {
            if (idopontOra.SelectedItem == "" || idopontPerc.SelectedItem == "" || idopontDatum.SelectedDate == null)
            {
                MessageBox.Show("Szükséges adat hiányzik!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (idopontReszletek.Text.Length < 10)
                {
                    MessageBox.Show("Az Időpont részletei paraméternek legalább 10 karakter hosszúnak kell lennie!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                DateTime ujIdopont = DateTime.Parse(idopontDatum.Text);
                ujIdopont = ujIdopont.AddHours(int.Parse(idopontOra.Text));
                ujIdopont = ujIdopont.AddMinutes(int.Parse(idopontPerc.Text));
                if (!IdopontFeldolgozo.UjIdopontFelvetele(ujIdopont, (Adatbazis.Orvos)idopontOrvos.SelectedItem, (Adatbazis.Paciens)idopontPaciens.SelectedItem, idopontReszletek.Text))
                {
                    MessageBox.Show("A megadott időpont foglalt!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    foglaltIdopontokListBox.ItemsSource = IdopontFeldolgozo.IdopontLekeres(Orvos);
                    MessageBox.Show("Időpont sikeresen felvéve!", "Időpont felvéve", MessageBoxButton.OK, MessageBoxImage.Information);
                    ((Window)Parent).Close();
                }
            }

        }

        private void idopontDatum_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
            if (idopontDatum.Text == DateTime.Today.ToString())
            {
                idopontOra.Items.Clear();
                for (int i = 9; i < 17; i++)
                {
                    if (DateTime.Now.Hour > i)
                        continue;
                    idopontOra.Items.Add(Convert.ToString(i));
                }
            }
            else
            {
                idopontOra.Items.Clear();
                for (int i = 9; i < 17; i++)
                {
                    idopontOra.Items.Add(Convert.ToString(i));
                }
                idopontOra.SelectedIndex = 0;
            }
             */
        }

        private void idopontOrvos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Orvos = (Adatbazis.Orvos) idopontOrvos.SelectedItem;
            foglaltIdopontokListBox.ItemsSource = IdopontFeldolgozo.IdopontLekeres(Orvos);
        }

        
    }
}
