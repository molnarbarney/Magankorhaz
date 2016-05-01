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
using Magankorhaz.Adatbazis;
using Magankorhaz.FeldolgozoOsztalyok;
using System.Collections.ObjectModel;
using Magankorhaz.ViewModellek;

namespace Magankorhaz.UserControlok
{
    /// <summary>
    /// Interaction logic for OrvosSajatAdatok.xaml
    /// </summary>
    public partial class OrvosSajatAdatok : UserControl
    {
        OrvosRendelesFeldolgozo RendelesFeldolgozo;
        Adatbazis.Orvos Orvos;
        public OrvosSajatAdatok(Orvos orvos)
        {
            InitializeComponent();
            SajatAdatokKiirasa(orvos);
            Orvos = orvos;
        }

        void SajatAdatokKiirasa(Magankorhaz.Adatbazis.Orvos orvos)
        {
            RendelesFeldolgozo = new OrvosRendelesFeldolgozo(AdatBazis.DataBase);
            orvosAdatNev.Text = orvos.Nev;
            orvosAdatEmail.Text = orvos.Email;
            orvosAdatFelhasznalonev.Text = orvos.Felhasznalonev;
            orvosAdatSzemelyiSzam.Text = orvos.SzemelyiSzam;
            orvosAdatTAJ.Text = Convert.ToString(orvos.TAJ);
            orvosAdatKepesites.Text = orvos.Kepesites;

            orvosAdatSzuletesiDatum.SelectedDate = orvos.SzuletesiDatum;

            orvosAdatLakcim.Text = orvos.Cim;
            orvosAdatTelefonszam.Text = orvos.Telefon;

            if (orvos.LegutolsoBejelentkezes < DateTime.Now.AddYears(-100))
            {
                orvosAdatUtolsoBejelentkezes.Text = "";
            }
            else orvosAdatUtolsoBejelentkezes.Text = Convert.ToString(orvos.LegutolsoBejelentkezes);


            // Elhelyezéshez feltöltés
            ObservableCollection<Adatbazis.Osztaly> osztalyok = RendelesFeldolgozo.Osztalyok;
            foreach (var osztaly in osztalyok)
            {
                orvosAdatOsztalyComboBox.Items.Add(osztaly.Megnevezes);
            }

            orvosAdatOsztalyText.Content = RendelesFeldolgozo.OsztalyMegnevezesIdAlapjan(orvos.OsztalyID);

            // Időpontok frissítése/feltöltése
            orvosIdopontokDataGrid.ItemsSource = RendelesFeldolgozo.Idopontok;          
        }

        private void orvosAdatUjIdopontGomb_Click(object sender, RoutedEventArgs e)
        {
            OrvosUjIdopontFelvetele ujIdopontUserControl = new OrvosUjIdopontFelvetele(Orvos);
            Window ujIdopontWindow = new Window();
            ujIdopontWindow.Title = "Új időpont felvétele";
            ujIdopontWindow.Content = ujIdopontUserControl;
            ujIdopontWindow.Width = 626;
            ujIdopontWindow.Height = 323;
            ujIdopontWindow.ResizeMode = ResizeMode.NoResize;
            ujIdopontWindow.ShowDialog();
        }

        private void IdopontokRefreshGomb_Click(object sender, RoutedEventArgs e)
        {
            RendelesFeldolgozo.IdopontLekeres();
            orvosIdopontokDataGrid.ItemsSource = RendelesFeldolgozo.Idopontok;
            orvosAdatIdopontModositasaGomb.Visibility = Visibility.Hidden;
            orvosAdatIdopontTorleseGomb.Visibility = Visibility.Hidden;
        }

        private void orvosIdopontokDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            orvosAdatIdopontModositasaGomb.Visibility = System.Windows.Visibility.Visible;
            orvosAdatIdopontTorleseGomb.Visibility = System.Windows.Visibility.Visible;
        }

        private void orvosAdatIdopontTorleseGomb_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Biztosan törli az időpontot?", "Törlés", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                try
                {
                    RendelesFeldolgozo.IdopontTorlese(((OrvosRendelesekViewModel)orvosIdopontokDataGrid.SelectedItem).FoglaltIdopont);
                    orvosIdopontokDataGrid.ItemsSource = null;

                    RendelesFeldolgozo.IdopontLekeres();
                    orvosIdopontokDataGrid.ItemsSource = RendelesFeldolgozo.Idopontok;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            orvosAdatIdopontModositasaGomb.Visibility = System.Windows.Visibility.Hidden;
            orvosAdatIdopontTorleseGomb.Visibility = System.Windows.Visibility.Hidden;
        }

        private void orvosAdatIdopontModositasaGomb_Click(object sender, RoutedEventArgs e)
        {
            OrvosIdopontModositasa modositandoIdopont = new OrvosIdopontModositasa((OrvosRendelesekViewModel)orvosIdopontokDataGrid.SelectedItem, Orvos, RendelesFeldolgozo.ElsoPaciensNevAlapjan(((OrvosRendelesekViewModel)orvosIdopontokDataGrid.SelectedItem).Paciens));
            Window idopontmodositasWindow = new Window();
            idopontmodositasWindow.Title = "Időpont módosítása";
            idopontmodositasWindow.Content = modositandoIdopont;
            idopontmodositasWindow.Width = 626;
            idopontmodositasWindow.Height = 323;
            idopontmodositasWindow.ResizeMode = ResizeMode.NoResize;
            idopontmodositasWindow.ShowDialog();
        }
    }
}
