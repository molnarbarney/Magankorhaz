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

namespace Magankorhaz
{
    /// <summary>
    /// Interaction logic for UgyintezoWindow.xaml
    /// </summary>
    public partial class UgyintezoWindow : Window
    {
        Magankorhaz.Adatbazis.MagankorhazDB MagankorhazDB = new Adatbazis.MagankorhazDB();

        public UgyintezoWindow()
        {
            InitializeComponent();
        }

        private void kijelentkezesButton_Click(object sender, RoutedEventArgs e)
        {
            ugyintezoWindow.Close();
            Application.Current.MainWindow.Visibility = Visibility.Visible;
        }

        private void ugyintezoWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.MainWindow.Visibility = Visibility.Visible;
        }

        private void attekintesMenuGomb_Click(object sender, RoutedEventArgs e)
        {
            ujPaciensFelveteleGrid.Visibility = Visibility.Hidden;
            szamlakezelesGrid.Visibility = Visibility.Hidden;
            paciensekAttekintesGrid.Visibility = Visibility.Visible;
        }

        private void ujPaciensMenuGomb_Click(object sender, RoutedEventArgs e)
        {
            szamlakezelesGrid.Visibility = Visibility.Hidden;
            paciensekAttekintesGrid.Visibility = Visibility.Hidden;
            ujPaciensFelveteleGrid.Visibility = Visibility.Visible;

            // Adatok betöltése
            FeldolgozoOsztalyok.UjPacinesFelvetelFeldolgozo ujPaciensFeldolgozo = new FeldolgozoOsztalyok.UjPacinesFelvetelFeldolgozo();

            // Orvosok betöltése
            List<string> orvosok = ujPaciensFeldolgozo.orvosokBetoltese(MagankorhazDB);
            foreach (var orvos in orvosok)
            {
                paciensKezeloorvos.Items.Add(orvos);
            }

            // Osztályok betöltése
            List<string> osztalyok = ujPaciensFeldolgozo.osztalyokBetoltese(MagankorhazDB);
            foreach (var osztaly in osztalyok)
            {
                paciensOsztaly.Items.Add(osztaly);
            }

            // Ügyintézők betöltése
            List<string> ugyintezok = ujPaciensFeldolgozo.ugyintezokBetoltese(MagankorhazDB);
            foreach (var ugyintezo in ugyintezok)
            {
                paciensUgyintezo.Items.Add(ugyintezo);
            }
        }
        private void szamlakMenuGomb_Click(object sender, RoutedEventArgs e)
        {
            paciensekAttekintesGrid.Visibility = Visibility.Hidden;
            ujPaciensFelveteleGrid.Visibility = Visibility.Hidden;
            szamlakezelesGrid.Visibility = Visibility.Visible;
        }
        
        private void HozzaadButton_Click(object sender, RoutedEventArgs e)
        {
            SzamlahozTetelHozzaadWindow szth = new SzamlahozTetelHozzaadWindow();
            szth.ShowDialog();
        }
        
        private void TorlesButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SzamlaKiallitasaButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void paciensFelveteleGomb_Click(object sender, RoutedEventArgs e)
        {
            FeldolgozoOsztalyok.UjPacinesFelvetelFeldolgozo ujPaciensFeldolgozo = new FeldolgozoOsztalyok.UjPacinesFelvetelFeldolgozo();
            ujPaciensFeldolgozo.ujPaciensFelvetele(
                paciensNev.Text, 
                paciensEmail.Text, 
                paciensFelhasznalonev.Text, 
                paciensSzemelyiszam.Text, 
                paciensJelszo.Password, 
                paciensJelszoUjra.Password, 
                paciensTAJ.Text, 
                paciensCim.Text, 
                paciensTelefon.Text, 
                paciensSzuletesiDatum, 
                paciensNeme.Text,
                paciensFelvetelDatum,
                paciensTavozasDatum, 
                paciensKezeloorvos.Text, 
                paciensOsztaly.Text, 
                paciensUgyintezo.Text);
        }
    }
}
