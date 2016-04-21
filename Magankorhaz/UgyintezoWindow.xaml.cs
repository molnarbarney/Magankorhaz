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
            int errors = 0;

            if (paciensNev.Text.Length < 5)
            {
                System.Windows.MessageBox.Show("A páciens neve nem lehet üres és rövidebb mint 5 karakter!");
                errors++;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(paciensNev.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("A páciens nevében csakis betűk szerepelhetnek!");
                errors++;
            }
            if (paciensEmail.Text.Length < 10)
            {
                System.Windows.MessageBox.Show("A páciens email címe nem lehet üres és rövidebb mint 10 karakter!");
                errors++;
            }
            if (paciensFelhasznalonev.Text.Length < 5)
            {
                System.Windows.MessageBox.Show("A páciens felhasználóneve nem lehet üres és rövidebb mint 10 karakter!");
                errors++;
            }
            if (paciensSzemelyiszam.Text.Length != 12)
            {
                System.Windows.MessageBox.Show("A páciens személyi száma 12 számjegy!");
                errors++;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(paciensSzemelyiszam.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("A páciens személyi számában csakis számok szerepelhetnek!");
                errors++;
            }
            if (paciensJelszo.Password.Length < 5)
            {
                System.Windows.MessageBox.Show("A páciens megadott jelszava nem lehet üres és rövidebb mint 5 karakter!");
                errors++;
            }
            if (paciensJelszo.Password != paciensJelszoUjra.Password)
            {
                System.Windows.MessageBox.Show("A páciens megadott jelszavai nem egyeznek!");
                errors++;
            }
            if (paciensTAJ.Text.Length != 8)
            {
                System.Windows.MessageBox.Show("A páciens TAJ száma 8 számjegy!");
                errors++;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(paciensTAJ.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("A páciens TAJ számában csakis számok szerepelhetnek!");
                errors++;
            }
            if (paciensCim.Text.Length < 10)
            {
                System.Windows.MessageBox.Show("A páciens címe nem lehet rövidebb mint 10 karakter!");
                errors++;
            }
            if (paciensTelefon.Text.Length < 12)
            {
                System.Windows.MessageBox.Show("A páciens telefonszáma nem lehet rövidebb mint 12 karakter!");
                errors++;
            }
            if (paciensNeme.Text.Length < 1)
            {
                System.Windows.MessageBox.Show("A páciens születési dátuma nem üres!");
                errors++;
            }

            if (errors == 0)
            {
                FeldolgozoOsztalyok.UjPacinesFelvetelFeldolgozo ujPaciensFeldolgozo = new FeldolgozoOsztalyok.UjPacinesFelvetelFeldolgozo();
                bool ujPaciensFelveteleSikeres = ujPaciensFeldolgozo.ujPaciensFelvetele(
                    paciensNev.Text,
                    paciensEmail.Text,
                    paciensFelhasznalonev.Text,
                    paciensSzemelyiszam.Text,
                    paciensJelszo.Password,
                    paciensTAJ.Text,
                    paciensCim.Text,
                    paciensTelefon.Text,
                    paciensSzuletesiDatum.SelectedDate.Value,
                    paciensNeme.Text,
                    paciensFelvetelDatum.SelectedDate.Value,
                    paciensKezeloorvos.Text,
                    paciensOsztaly.Text,
                    paciensUgyintezo.Text,
                    MagankorhazDB);

                if (ujPaciensFelveteleSikeres)
                {
                    attekintesMenuGomb_Click(sender, e);
                }
            }
        }
    }
}
