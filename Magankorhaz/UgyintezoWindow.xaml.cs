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

            // Attekintés frissítés
            AttekintesFrissites();        
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

            AttekintesFrissites();
        }

        private void AttekintesFrissites()
        {
            // Adatok betöltése
            FeldolgozoOsztalyok.UgyintezoAttekintesFeldolgozo ugyintezoAttekintesFeldolgozo = new FeldolgozoOsztalyok.UgyintezoAttekintesFeldolgozo();

            // Szabad helyek
            szabadFerohelyekSzam.Content = ugyintezoAttekintesFeldolgozo.szabadFerohelyek(MagankorhazDB);

            // Férfiak - nők aránya
            paciensAranyokSzam.Content = ugyintezoAttekintesFeldolgozo.ferfiakNokAranya(MagankorhazDB);

            // Legrégebbi páciens
            List<Adatbazis.Paciens> paciensek = new List<Adatbazis.Paciens>();
            paciensek = ugyintezoAttekintesFeldolgozo.legregebbiLegujabbPaciens(MagankorhazDB);

            legregebbiPaciensNeve.Content = paciensek.First().Nev;
            legregebbiPaciensDatum.Content = paciensek.First().FelvetelDatuma.ToString("yyyy. MM. dd.");
            legujabbPaciensNeve.Content = paciensek.Last().Nev;
            legujabbPaciensDatum.Content = paciensek.Last().FelvetelDatuma.ToString("yyyy. MM. dd.");

            // Dátum
            maiDatum.Content = DateTime.Now.Year + ". " + DateTime.Now.Month + ". " + DateTime.Now.Day + ".";

            // DataGrid feltöltése
            // DataGridFrissítése(ugyintezoAttekintesFeldolgozo.paciensek(MagankorhazDB));
            DataGridFrissítése(ugyintezoAttekintesFeldolgozo.paciensek(MagankorhazDB));
        }

        /*
        void DataGridFrissítéseRégi(List<Adatbazis.Paciens> paciensek)
        {
            // Szálbiztos
            Dispatcher.Invoke(() =>
            {
                paciensekAttekintesDataGrid.ItemsSource = null;
                paciensekAttekintesDataGrid.ItemsSource = paciensek.Select(x => new { Név = x.Nev, Email = x.Email, Felhasználónév = x.Felhasznalonev, SzületésiDátum = x.SzuletesiDatum.ToString("yyyy. MM. dd."), FelvételDátuma = x.FelvetelDatuma.ToString("yyyy. MM. dd.") }).ToList();
            });
        }
        */

        void DataGridFrissítése(List<object> paciensek)
        {
            // Szálbiztos
            Dispatcher.Invoke(() =>
            {
                paciensekAttekintesDataGrid.ItemsSource = null;
                paciensekAttekintesDataGrid.ItemsSource = paciensek.ToList();
            });
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

        private void paciensMegtekintesGomb_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show(paciensekAttekintesDataGrid.SelectedCells.First().Item.ToString());
        }
    }
}
