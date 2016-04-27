using Magankorhaz.FeldolgozoOsztalyok;
using Magankorhaz.ViewModellek;
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
    /// Interaction logic for OrvosIdopontModositasa.xaml
    /// </summary>
    public partial class OrvosIdopontModositasa : UserControl
    {
        OrvosRendelesekViewModel Idopont;
        OrvosRendelesFeldolgozo IdopontFeldolgozo;
        Adatbazis.Orvos Orvos;

        public OrvosIdopontModositasa(OrvosRendelesekViewModel kivalasztottIdopont, Adatbazis.Orvos orvos)
        {
            InitializeComponent();
            Orvos = orvos;
            IdopontFeldolgozo = new OrvosRendelesFeldolgozo(Adatbazis.AdatBazis.DataBase);
            paciensListBox.DataContext = IdopontFeldolgozo;

            Idopont = kivalasztottIdopont;
            datumDatePicker.Text = kivalasztottIdopont.FoglaltIdopont.ToShortDateString();
            idoOraTextBox.Text = kivalasztottIdopont.FoglaltIdopont.Hour.ToString();
            idoPercTextBox.Text = kivalasztottIdopont.FoglaltIdopont.Minute.ToString();
            megnevezesTextBox.Text = kivalasztottIdopont.Megnevezes;

        }

        private void idoOraTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key < Key.D0 || e.Key > Key.D9) && (e.Key < Key.NumPad0 || e.Key > Key.NumPad9) && (e.Key != Key.Back) && (e.Key != Key.Tab))
            {
                e.Handled = true;
            }
            if (idoOraTextBox.Text.Length > 1)
            {
                if (int.Parse(idoOraTextBox.Text) > 23)
                {
                    idoOraTextBox.Text = "23";
                }
            }
        }

        private void idoPercTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key <= Key.D0 || e.Key >= Key.D9) && (e.Key < Key.NumPad0 || e.Key > Key.NumPad9) && (e.Key != Key.Back) && (e.Key != Key.Tab))
            {
                e.Handled = true;
            }
            if (idoPercTextBox.Text.Length > 1)
            {
                if (int.Parse(idoPercTextBox.Text) > 59)
                {
                    idoPercTextBox.Text = "59";
                }
            }
        }

        private void idopontModositasaButton_Click(object sender, RoutedEventArgs e)
        {
            if (paciensListBox.SelectedItem == null || datumDatePicker.Text == "" || idoOraTextBox.Text == "" || idoPercTextBox.Text == "")
            {
                MessageBox.Show("Szükséges adatok hiányoznak!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                DateTime ujIdopont = DateTime.Parse(datumDatePicker.Text);
                ujIdopont = ujIdopont.AddHours(int.Parse(idoOraTextBox.Text));
                ujIdopont = ujIdopont.AddMinutes(int.Parse(idoPercTextBox.Text));
                IdopontFeldolgozo.IdopontTorlese(Idopont.FoglaltIdopont);

                if (IdopontFeldolgozo.UjIdopontFelvetele(ujIdopont, (Adatbazis.Paciens)paciensListBox.SelectedItem, megnevezesTextBox.Text))
                {
                    MessageBox.Show("Időpont sikeresen módosítva", "Időpont felvéve", MessageBoxButton.OK, MessageBoxImage.Information);
                    Grid parent = (Grid)this.Parent;
                    parent.Children.Clear();
                    parent.Children.Add(new OrvosRendelesek(Orvos));
                }

            }
        }
    }
}
