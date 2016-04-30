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
using Magankorhaz.ViewModellek;
using System.Collections.ObjectModel;

namespace Magankorhaz.UserControlok
{
    /// <summary>
    /// Interaction logic for OrvosUjKezelesFelvetele.xaml
    /// </summary>
    public partial class OrvosUjKezelesFelvetele : UserControl
    {
        OrvosKezelesekFeldolgozo KezelesFeldolgozo;
        OrvosRendelesFeldolgozo IdopontFeldolgozo;
        Adatbazis.Paciens kivalasztottPaciens;
        Adatbazis.Orvos Orvos;
        
        public OrvosUjKezelesFelvetele(Adatbazis.Orvos orvos)
        {
            InitializeComponent();
            Orvos = orvos;
            KezelesFeldolgozo = new OrvosKezelesekFeldolgozo(Adatbazis.AdatBazis.DataBase, orvos);
            IdopontFeldolgozo = new OrvosRendelesFeldolgozo(Adatbazis.AdatBazis.DataBase, orvos);
            paciensListBox.ItemsSource = KezelesFeldolgozo.Paciensek;

            ObservableCollection<OrvosKezelesekViewModel> idopontok = KezelesFeldolgozo.Kezelesek;
            foreach (OrvosKezelesekViewModel akt in idopontok)
            {
                foglaltidopontokListBox.Items.Add(akt);
            }

            sikeressegComboBox.SelectedIndex = 0;

            if (DateTime.Now.Hour > 16)
            {

                datumDatePicker.BlackoutDates.Add(new CalendarDateRange(new DateTime(1990, 1, 1), DateTime.Now));
            }
            else
            {
                datumDatePicker.BlackoutDates.Add(new CalendarDateRange(new DateTime(1990, 1, 1), DateTime.Now.AddDays(-1)));
            }

            for (int i = 9; i < 17; i++)
            {
                if (DateTime.Now.Hour < 17 && DateTime.Now.Hour > 8)
                    if (DateTime.Now.Hour > i)
                        continue;
                idopontOra.Items.Add(Convert.ToString(i));
            }

            idopontPerc.Items.Add("00");
            idopontPerc.Items.Add("30");

            idopontOra.SelectedIndex = 0;
            idopontPerc.SelectedIndex = 0;
        }

        private void datumDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            idopontOra.Items.Clear();
            idopontPerc.Items.Clear();
            for (int i = 9; i < 17; i++)
            {
                if (DateTime.Now.Hour < 17 && DateTime.Now.Hour > 8)
                    if (DateTime.Now.Hour > i)
                        continue;
                idopontOra.Items.Add(Convert.ToString(i));
            }

            idopontPerc.Items.Add("00");
            idopontPerc.Items.Add("30");

            idopontOra.SelectedIndex = 0;
            idopontPerc.SelectedIndex = 0;
        }

        private void ujkezelesfelveteleButton_Click(object sender, RoutedEventArgs e)
        {
            if (paciensListBox.SelectedItem != null && datumDatePicker.Text != "" && koltsegTextBox.Text != "")
            {
                DateTime ujidopont = DateTime.Parse(datumDatePicker.Text);
                ujidopont = ujidopont.AddHours(int.Parse(idopontOra.SelectedItem.ToString()));
                ujidopont = ujidopont.AddMinutes(int.Parse(idopontPerc.SelectedItem.ToString()));
                KezelesFeldolgozo.KezelesFelvetele(ujidopont, (Adatbazis.Paciens)paciensListBox.SelectedItem, Orvos, receptekTextBox.Text, int.Parse(koltsegTextBox.Text), kezelesreszleteiTextBox.Text, SikeresE());
                MessageBox.Show("Kezelés sikeresen felvéve!", "Sikeres felvétel", MessageBoxButton.OK, MessageBoxImage.Information);

                Grid parent = (Grid)this.Parent;
                parent.Children.Clear();
                parent.Children.Add(new OrvosKezelesek(Orvos));
            }
            else
                MessageBox.Show("Szükséges adat hiányzik!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private bool SikeresE()
        {
            return sikeressegComboBox.SelectionBoxItem.ToString() == "Igen";
        }

        private void koltsegTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key <= Key.D0 || e.Key >= Key.D9) && (e.Key < Key.NumPad0 || e.Key > Key.NumPad9) && (e.Key != Key.Back) && (e.Key != Key.Tab))
            {
                e.Handled = true;
            }
        }

        private void paciensListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            KezelesFeldolgozo.KezelesekLekerdezese((Adatbazis.Paciens)paciensListBox.SelectedItem);
            foglaltidopontokListBox.Items.Clear();
            foreach (OrvosKezelesekViewModel akt in KezelesFeldolgozo.Kezelesek)
            {
                foglaltidopontokListBox.Items.Add(akt);
            }
        }

    }
}
