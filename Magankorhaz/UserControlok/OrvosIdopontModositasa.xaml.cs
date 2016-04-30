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

        public OrvosIdopontModositasa(OrvosRendelesekViewModel kivalasztottIdopont, Adatbazis.Orvos orvos, Adatbazis.Paciens paciens)
        {
            InitializeComponent();
            Orvos = orvos;
            Idopont = kivalasztottIdopont;
            IdopontFeldolgozo = new OrvosRendelesFeldolgozo(Adatbazis.AdatBazis.DataBase);
            idopontOrvos.ItemsSource = IdopontFeldolgozo.Orvosok;
            idopontPaciens.ItemsSource = IdopontFeldolgozo.Paciensek;

            for (int i = 9; i < 17; i++)
            {
                if (kivalasztottIdopont.FoglaltIdopont <= DateTime.Now)
                {
                    if(DateTime.Now.Hour < 17 && DateTime.Now.Hour > 8)
                        if (DateTime.Now.Hour > i)
                            continue;
                }
                idopontOra.Items.Add(i.ToString());
            }

            idopontPerc.Items.Add("00");
            idopontPerc.Items.Add("30");

            idopontOrvos.SelectedItem = Orvos;
            idopontOra.SelectedIndex = 0;
            idopontPerc.SelectedIndex = 0;

            foglaltIdopontokListBox.ItemsSource = IdopontFeldolgozo.Idopontok;

            idopontDatum.BlackoutDates.Add(new CalendarDateRange(new DateTime(1990, 1, 1), DateTime.Now.AddDays(-1)));
            idopontDatum.SelectedDate = kivalasztottIdopont.FoglaltIdopont.Date;
            if (DateTime.Now.Hour > 16)
            {
                idopontDatum.BlackoutDates.Add(new CalendarDateRange(new DateTime(1990, 1, 1), DateTime.Now));
            }
            else
            {
                idopontDatum.BlackoutDates.Add(new CalendarDateRange(new DateTime(1990, 1, 1), DateTime.Now.AddDays(-1)));
            }
            if (kivalasztottIdopont.FoglaltIdopont > DateTime.Now)
            {
                switch (kivalasztottIdopont.FoglaltIdopont.Hour)
                {
                    case 9: idopontOra.SelectedIndex = 0; break;
                    case 10: idopontOra.SelectedIndex = 1; break;
                    case 11: idopontOra.SelectedIndex = 2; break;
                    case 12: idopontOra.SelectedIndex = 3; break;
                    case 13: idopontOra.SelectedIndex = 4; break;
                    case 14: idopontOra.SelectedIndex = 5; break;
                    case 15: idopontOra.SelectedIndex = 6; break;
                    case 16: idopontOra.SelectedIndex = 7; break;
                }
                if (kivalasztottIdopont.FoglaltIdopont.Minute < 30)
                    idopontPerc.SelectedIndex = 0;
                else
                    idopontPerc.SelectedIndex = 1;
            }
            idopontReszletek.Text = kivalasztottIdopont.Megnevezes;

            idopontPaciens.SelectedItem = paciens;

        }

        private void UjIdopontMentesGomb_Click(object sender, RoutedEventArgs e)
        {
            if (idopontOra.Text == "" || idopontPerc.Text == "")
            {
                MessageBox.Show("Szükséges adat hiányzik!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                DateTime ujIdopont = DateTime.Parse(idopontDatum.Text);
                ujIdopont = ujIdopont.AddHours(int.Parse(idopontOra.Text));
                ujIdopont = ujIdopont.AddMinutes(int.Parse(idopontPerc.Text));
                if (!IdopontFeldolgozo.UjIdopontFelvetele(ujIdopont, (Adatbazis.Orvos)idopontOrvos.SelectedItem, (Adatbazis.Paciens)idopontPaciens.SelectedItem, idopontReszletek.Text))
                {
                    MessageBox.Show("A megadott időpont foglalt!", "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                foglaltIdopontokListBox.ItemsSource = IdopontFeldolgozo.IdopontLekeres(Orvos);
            }
        }

        
    }
}
