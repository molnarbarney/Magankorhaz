using Magankorhaz.FeldolgozoOsztalyok;
using Magankorhaz.ViewModellek;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for OrvosKezelesModositasa.xaml
    /// </summary>
    public partial class OrvosKezelesModositasa : UserControl
    {
        OrvosKezelesekFeldolgozo KezelesFeldolgozo;
        OrvosKezelesekViewModel ValasztottKezeles;
        Adatbazis.Orvos Orvos;
        public OrvosKezelesModositasa(OrvosKezelesekViewModel valasztottkezeles, Adatbazis.Orvos orvos)
        {
            InitializeComponent();
            ValasztottKezeles = valasztottkezeles;
            Orvos = orvos;
            KezelesFeldolgozo = new OrvosKezelesekFeldolgozo(Adatbazis.AdatBazis.DataBase, orvos);

            sikeressegComboBox.SelectedIndex = 0;

            for (int i = 9; i < 17; i++)
            {
                if (DateTime.Now.Hour < 17 && DateTime.Now.Hour > 8)
                    if (DateTime.Now.Hour > i)
                        continue;
                idopontOra.Items.Add(Convert.ToString(i));
            }

            idopontPerc.Items.Add("00");
            idopontPerc.Items.Add("30");

            datumDatePicker.SelectedDate = valasztottkezeles.KezelesDatuma.Date;
            paciensListBox.ItemsSource = KezelesFeldolgozo.Paciensek;
            paciensListBox.SelectedItem = valasztottkezeles.Paciens;
            switch (ValasztottKezeles.KezelesDatuma.Hour)
            {
                case 9: idopontOra.SelectedIndex = 0; break;
                case 10: idopontOra.SelectedIndex = 1; break;
                case 11: idopontOra.SelectedIndex = 2; break;
                case 12: idopontOra.SelectedIndex = 3; break;
                case 13: idopontOra.SelectedIndex = 4; break;
                case 14: idopontOra.SelectedIndex = 5; break;
                case 15: idopontOra.SelectedIndex = 6; break;
                case 16: idopontOra.SelectedIndex = 7; break;
                default: idopontOra.SelectedIndex = 0; break;
            }
            if (ValasztottKezeles.KezelesDatuma.Minute < 30)
                idopontPerc.SelectedIndex = 0;
            else
                idopontPerc.SelectedIndex = 1;
            kezelesreszleteiTextBox.Text = valasztottkezeles.KezelesReszletei;
            receptekTextBox.Text = valasztottkezeles.Receptek;
            koltsegTextBox.Text = valasztottkezeles.KezelesKoltsege.ToString();
            if (valasztottkezeles.KezelesSikeressege)
                sikeressegComboBox.SelectedIndex = 0;
            ObservableCollection<OrvosKezelesekViewModel> idopontok = KezelesFeldolgozo.Kezelesek;
            foreach (OrvosKezelesekViewModel akt in idopontok)
            {
                foglaltidopontokListBox.Items.Add(akt);
            }

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

        private void ujkezelesfelveteleButton_Click(object sender, RoutedEventArgs e)
        {
            if (paciensListBox.SelectedItem != null && datumDatePicker.Text != "" && koltsegTextBox.Text != "")
            {
                try
                {
                    KezelesFeldolgozo.KezelesTorlese(ValasztottKezeles);
                }
                catch { }

                DateTime ujidopont = DateTime.Parse(datumDatePicker.Text);
                ujidopont = ujidopont.AddHours(int.Parse(idopontOra.SelectedItem.ToString()));
                ujidopont = ujidopont.AddMinutes(int.Parse(idopontPerc.SelectedItem.ToString()));
                KezelesFeldolgozo.KezelesFelvetele(ujidopont, (Adatbazis.Paciens)paciensListBox.SelectedItem, Orvos, receptekTextBox.Text, int.Parse(koltsegTextBox.Text), kezelesreszleteiTextBox.Text, SikeresE());
                MessageBox.Show("Kezelés sikeresen módosítva!", "Sikeres módosítás", MessageBoxButton.OK, MessageBoxImage.Information);

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
    }
}
