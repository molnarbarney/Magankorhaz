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
using System.Windows.Shapes;

namespace Magankorhaz
{
    /// <summary>
    /// Interaction logic for UgyintezoWindow.xaml
    /// </summary>
    public partial class UgyintezoWindow : Window
    {
        //Magankorhaz.Adatbazis.MagankorhazDB MagankorhazDB;
        ObservableCollection<Magankorhaz.Adatbazis.Paciens> pacienskek;

        // Adatok betöltéséhez
        FeldolgozoOsztalyok.UgyintezoAttekintesFeldolgozo ugyintezoAttekintesFeldolgozo = new FeldolgozoOsztalyok.UgyintezoAttekintesFeldolgozo();

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

        //Barni része
        #region Barni
        private void attekintesMenuGomb_Click(object sender, RoutedEventArgs e)
        {
            AttekintesFrissites();

            ujPaciensFelveteleGrid.Visibility = Visibility.Hidden;
            szamlakezelesGrid.Visibility = Visibility.Hidden;
            paciensMegtekinteseGrid.Visibility = Visibility.Hidden;
            paciensekAttekintesGrid.Visibility = Visibility.Visible;
        }

        private void AttekintesFrissites()
        {
            // Szabad helyek
            szabadFerohelyekSzam.Content = ugyintezoAttekintesFeldolgozo.szabadFerohelyek();

            // Férfiak - nők aránya
            paciensAranyokSzam.Content = ugyintezoAttekintesFeldolgozo.ferfiakNokAranya();

            // Legrégebbi páciens
            List<Adatbazis.Paciens> paciensek = new List<Adatbazis.Paciens>();
            paciensek = ugyintezoAttekintesFeldolgozo.legregebbiLegujabbPaciens();

            legregebbiPaciensNeve.Content = paciensek.First().Nev;
            legregebbiPaciensDatum.Content = paciensek.First().FelvetelDatuma.ToString("yyyy. MM. dd.");
            legujabbPaciensNeve.Content = paciensek.Last().Nev;
            legujabbPaciensDatum.Content = paciensek.Last().FelvetelDatuma.ToString("yyyy. MM. dd.");

            // Dátum
            maiDatum.Content = DateTime.Now.Year + ". " + DateTime.Now.Month + ". " + DateTime.Now.Day + ".";

            // DataGrid feltöltése
            // DataGridFrissítése(ugyintezoAttekintesFeldolgozo.paciensek(MagankorhazDB));
            DataGridFrissítése(ugyintezoAttekintesFeldolgozo.paciensek());

            paciensMegtekintesGomb.Visibility = Visibility.Hidden;

            // Szűrők lenullázása
            paciensKeresesNev.Text = "";
            paciensKeresesSzuletesiDatum.SelectedDate = null;
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
            paciensMegtekinteseGrid.Visibility = Visibility.Hidden;
            ujPaciensFelveteleGrid.Visibility = Visibility.Visible;

            // Adatok betöltéséhez
            FeldolgozoOsztalyok.UjPacinesFelvetelFeldolgozo ujPaciensFeldolgozo = new FeldolgozoOsztalyok.UjPacinesFelvetelFeldolgozo();

            // Orvosok betöltése
            paciensKezeloorvos.Items.Clear();
            List<string> orvosok = ujPaciensFeldolgozo.orvosokBetoltese(Magankorhaz.Adatbazis.AdatBazis.DataBase);
            foreach (var orvos in orvosok)
            {
                paciensKezeloorvos.Items.Add(orvos);
            }

            // Osztályok betöltése
            paciensOsztaly.Items.Clear();
            List<string> osztalyok = ujPaciensFeldolgozo.osztalyokBetoltese(Magankorhaz.Adatbazis.AdatBazis.DataBase);
            foreach (var osztaly in osztalyok)
            {
                paciensOsztaly.Items.Add(osztaly);
            }

            // Ügyintézők betöltése
            paciensUgyintezo.Items.Clear();
            List<string> ugyintezok = ujPaciensFeldolgozo.ugyintezokBetoltese(Magankorhaz.Adatbazis.AdatBazis.DataBase);
            foreach (var ugyintezo in ugyintezok)
            {
                paciensUgyintezo.Items.Add(ugyintezo);
            }
        }
        private void szamlakMenuGomb_Click(object sender, RoutedEventArgs e)
        {
            paciensekAttekintesGrid.Visibility = Visibility.Hidden;
            ujPaciensFelveteleGrid.Visibility = Visibility.Hidden;
            paciensMegtekinteseGrid.Visibility = Visibility.Hidden;
            szamlakezelesGrid.Visibility = Visibility.Visible;
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
            if (paciensSzuletesiDatum.SelectedDate == null)
            {
                System.Windows.MessageBox.Show("A páciens születési dátuma nem lehet üres!");
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
                    Magankorhaz.Adatbazis.AdatBazis.DataBase);

                if (ujPaciensFelveteleSikeres)
                {
                    attekintesMenuGomb_Click(sender, e);
                }
            }
        }

        private void paciensMegtekintesGomb_Click(object sender, RoutedEventArgs e)
        {
            szamlakezelesGrid.Visibility = Visibility.Hidden;
            paciensekAttekintesGrid.Visibility = Visibility.Hidden;
            ujPaciensFelveteleGrid.Visibility = Visibility.Hidden;
            paciensMegtekinteseGrid.Visibility = Visibility.Visible;

            string DataGridRow = paciensekAttekintesDataGrid.SelectedItem.ToString();
            string[] stringSeparators = new string[] { "Email = " };
            string[] rowData = DataGridRow.Split(stringSeparators, StringSplitOptions.None);

            string[] rowData2 = rowData[1].Split(',');
            string paciensEmail = rowData2[0];

            // Adatok betöltéséhez
            FeldolgozoOsztalyok.PaciensAdatlapFeldolgozo paciensAdatlapFeldolgozo = new FeldolgozoOsztalyok.PaciensAdatlapFeldolgozo(Magankorhaz.Adatbazis.AdatBazis.DataBase, paciensEmail);

            Adatbazis.Paciens paciensAdatok = paciensAdatlapFeldolgozo.paciensAdatok;

            paciensAdatNev.Text = paciensAdatok.Nev;
            paciensAdatEmail.Text = paciensAdatok.Email;
            paciensAdatFelhasznalonev.Text = paciensAdatok.Felhasznalonev;
            paciensAdatSzemelyiSzam.Text = paciensAdatok.SzemelyiSzam;
            paciensAdatTAJ.Text = Convert.ToString(paciensAdatok.TAJ);

            paciensAdatSzuletesiDatum.SelectedDate = paciensAdatok.SzuletesiDatum; // szerkesztéshez
            paciensAdatSzuletesiDatumText.Text = paciensAdatok.SzuletesiDatum.ToString("yyyy. MM. dd."); // megjelenítéshez

            paciensAdatLakcim.Text = paciensAdatok.Cim;
            paciensAdatTelefonszam.Text = paciensAdatok.Telefon;
            paciensAdatNeme.Text = paciensAdatok.Neme;

            if (paciensAdatok.LegutolsoBejelentkezes < DateTime.Now.AddYears(-100))
            {
                paciensAdatUtolsoBejelentkezes.Text = "";
            }
            else paciensAdatUtolsoBejelentkezes.Text = Convert.ToString(paciensAdatok.LegutolsoBejelentkezes);

            paciensAdatFelvetel.Text = paciensAdatok.FelvetelDatuma.ToString("yyyy. MM. dd.");

            if (paciensAdatok.TavozasDatuma < DateTime.Now.AddYears(-100))
            {
                paciensAdatTavozasText.Text = "";
            }
            else
            {
                paciensAdatTavozasText.Text = Convert.ToString(paciensAdatok.TavozasDatuma); // megjelenítéshez
                paciensAdatTavozasDatum.SelectedDate = paciensAdatok.TavozasDatuma; // szerkesztéshez
            }

            paciensAdatOrvos.Text = "Ezt akkor kell beállítani, ha épp valakihez van időpontja";
            paciensAdatUgyvezeto.Text = paciensAdatlapFeldolgozo.ugyintezoNev;

            List<Adatbazis.Osztaly> osztalyok = paciensAdatlapFeldolgozo.osszesOsztaly;
            foreach (var osztaly in osztalyok)
            {
                paciensAdatOsztalyComboBox.Items.Add(osztaly.Megnevezes);
            }

            paciensAdatOsztalyText.Content = paciensAdatlapFeldolgozo.paciensOsztaly;

            for (int i = 1; i <= 20; i++)
            {
                paciensAdatSzobaComboBox.Items.Add(i);
            }

            if (paciensAdatok.Szobaszam == 0)
            {
                paciensAdatSzobaText.Content = "Nincs elhelyezve";
            }
            else paciensAdatSzobaText.Content = Convert.ToString(paciensAdatok.Szobaszam);
        }

        private void paciensOsztalyElhelyezesGomb_Click(object sender, RoutedEventArgs e)
        {
            paciensOsztalyElhelyezesGomb.Visibility = Visibility.Hidden;
            paciensOsztalyElhelyezesMentesGomb.Visibility = Visibility.Visible;
            paciensOsztalyElhelyezesMegseGomb.Visibility = Visibility.Visible;

            paciensOsztalyAdatokFeloldasa();
        }

        private void paciensOsztalyElhelyezesMentesGomb_Click(object sender, RoutedEventArgs e)
        {
            paciensOsztalyElhelyezesGomb.Visibility = Visibility.Visible;
            paciensOsztalyElhelyezesMentesGomb.Visibility = Visibility.Hidden;
            paciensOsztalyElhelyezesMegseGomb.Visibility = Visibility.Hidden;

            // TODO: ELLENŐRZÉS !!!
            // TODO: MENTÉS !!!
            // TODO: HA SIKERES A MENTÉS, AKKOR LEZÁRÁS !!!
            // TODO: ÚJRATÖLTÉS !!! -> vagy üresen hagyni

            paciensOsztalyAdatokLezarasa();
        }


        private void paciensOsztalyElhelyezesMegseGomb_Click(object sender, RoutedEventArgs e)
        {
            paciensOsztalyElhelyezesGomb.Visibility = Visibility.Visible;
            paciensOsztalyElhelyezesMentesGomb.Visibility = Visibility.Hidden;
            paciensOsztalyElhelyezesMegseGomb.Visibility = Visibility.Hidden;

            paciensOsztalyAdatokLezarasa();
        }

        private void paciensOsztalyAdatokFeloldasa()
        {
            paciensAdatOsztalyComboBox.Visibility = Visibility.Visible;
            paciensAdatOsztalyText.Visibility = Visibility.Hidden;

            paciensAdatSzobaText.Visibility = Visibility.Hidden;
            paciensAdatSzobaComboBox.Visibility = Visibility.Visible;
        }

        private void paciensOsztalyAdatokLezarasa()
        {
            paciensAdatOsztalyComboBox.Visibility = Visibility.Hidden;
            paciensAdatOsztalyText.Visibility = Visibility.Visible;

            paciensAdatSzobaText.Visibility = Visibility.Visible;
            paciensAdatSzobaComboBox.Visibility = Visibility.Hidden;
        }
        private void paciensAdatokModositasGomb_Click(object sender, RoutedEventArgs e)
        {
            paciensAdatokModositasGomb.IsEnabled = false;
            paciensAdatokMentesGomb.Visibility = Visibility.Visible;
            paciensAdatokMegseGomb.Visibility = Visibility.Visible;

            // UgyintezoAttekintesFeldolgozo - osztályba kellenek temporary tulajdonságok
            // ezeket a tulajdonságokat feltölteni, azzal ami jelenleg van a páciens adataiban
            // ha nem jó valamelyik az ellenőrzéskor, akkor a temp-el felülírni

            paciensAdatokFeloldasa();
        }

        private void paciensAdatokMentesGomb_Click(object sender, RoutedEventArgs e)
        {
            // TODO: ELLENŐRZÉS !!!
            bool mindenoké = false;
            /*while (mindenoké)
            {
                mindenoké = paciensAdatokEllenorzese();
            }
            
            if (mindenoké)
            {
                paciensAdatokModositasGomb.IsEnabled = true;
                paciensAdatokMentesGomb.Visibility = Visibility.Hidden;
                paciensAdatokMegseGomb.Visibility = Visibility.Hidden;

                // TODO: MENTÉS !!! -> paciensAdatTavozasDatum.SelectedDate = new DateTime(1900, 1, 1);

                // TODO: HA SIKERES A MENTÉS, AKKOR LEZÁRÁS !!!

                // TODO: ÚJRATÖLTÉS !!! -> vagy üresen hagyni

                paciensAdatokLezarasa();
            }*/
        }

        private void paciensAdatokMegseGomb_Click(object sender, RoutedEventArgs e)
        {
            paciensAdatokModositasGomb.IsEnabled = true;
            paciensAdatokMentesGomb.Visibility = Visibility.Hidden;
            paciensAdatokMegseGomb.Visibility = Visibility.Hidden;
            paciensAdatokLezarasa();
        }

        private void paciensAdatokFeloldasa()
        {
            var bc = new BrushConverter();

            paciensAdatNev.IsReadOnly = false;
            paciensAdatNev.Foreground = (Brush)bc.ConvertFrom("#FFF75E24");
            paciensAdatEmail.IsReadOnly = false;
            paciensAdatEmail.Foreground = (Brush)bc.ConvertFrom("#FFF75E24");
            paciensAdatFelhasznalonev.IsReadOnly = false;
            paciensAdatFelhasznalonev.Foreground = (Brush)bc.ConvertFrom("#FFF75E24");
            paciensAdatSzemelyiSzam.IsReadOnly = false;
            paciensAdatSzemelyiSzam.Foreground = (Brush)bc.ConvertFrom("#FFF75E24");
            paciensAdatTAJ.IsReadOnly = false;
            paciensAdatTAJ.Foreground = (Brush)bc.ConvertFrom("#FFF75E24");

            paciensAdatSzuletesiDatum.Visibility = Visibility.Visible;
            paciensAdatSzuletesiDatumText.Visibility = Visibility.Hidden;
            paciensAdatSzuletesiDatum.Foreground = (Brush)bc.ConvertFrom("#FFF75E24");

            paciensAdatLakcim.IsReadOnly = false;
            paciensAdatLakcim.Foreground = (Brush)bc.ConvertFrom("#FFF75E24");
            paciensAdatTelefonszam.IsReadOnly = false;
            paciensAdatTelefonszam.Foreground = (Brush)bc.ConvertFrom("#FFF75E24");

            paciensAdatNeme.Visibility = Visibility.Hidden;
            paciensAdatNemeComboBox.Visibility = Visibility.Visible;

            paciensAdatTavozasDatum.Visibility = Visibility.Visible;
            paciensAdatTavozasText.Visibility = Visibility.Hidden;
            paciensAdatTavozasDatum.Foreground = (Brush)bc.ConvertFrom("#FFF75E24");
        }

        private bool paciensAdatokEllenorzese()
        {
            // JELSZÓ MÓDOSÍTÁS ???

            int errors = 0;

            if (paciensAdatNev.Text.Length < 5)
            {
                System.Windows.MessageBox.Show("A páciens neve nem lehet üres és rövidebb mint 5 karakter!");
                errors++;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(paciensAdatNev.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("A páciens nevében csakis betűk szerepelhetnek!");
                errors++;
            }
            if (paciensAdatEmail.Text.Length < 10)
            {
                System.Windows.MessageBox.Show("A páciens email címe nem lehet üres és rövidebb mint 10 karakter!");
                errors++;
            }
            if (paciensAdatFelhasznalonev.Text.Length < 5)
            {
                System.Windows.MessageBox.Show("A páciens felhasználóneve nem lehet üres és rövidebb mint 10 karakter!");
                errors++;
            }
            if (paciensAdatSzemelyiSzam.Text.Length != 12)
            {
                System.Windows.MessageBox.Show("A páciens személyi száma 12 számjegy!");
                errors++;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(paciensAdatSzemelyiSzam.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("A páciens személyi számában csakis számok szerepelhetnek!");
                errors++;
            }
            /*if (paciensJelszo.Password.Length < 5)
            {
                System.Windows.MessageBox.Show("A páciens megadott jelszava nem lehet üres és rövidebb mint 5 karakter!");
                errors++;
            }
            if (paciensJelszo.Password != paciensJelszoUjra.Password)
            {
                System.Windows.MessageBox.Show("A páciens megadott jelszavai nem egyeznek!");
                errors++;
            }*/
            if (paciensAdatTAJ.Text.Length != 8)
            {
                System.Windows.MessageBox.Show("A páciens TAJ száma 8 számjegy!");
                errors++;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(paciensAdatTAJ.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("A páciens TAJ számában csakis számok szerepelhetnek!");
                errors++;
            }
            if (paciensAdatLakcim.Text.Length < 10)
            {
                System.Windows.MessageBox.Show("A páciens címe nem lehet rövidebb mint 10 karakter!");
                errors++;
            }
            if (paciensAdatTelefonszam.Text.Length < 12)
            {
                System.Windows.MessageBox.Show("A páciens telefonszáma nem lehet rövidebb mint 12 karakter!");
                errors++;
            }

            if (errors > 0)
            {
                return true;
            }
            else return false;
        }

        private void paciensAdatokLezarasa()
        {
            var bc = new BrushConverter();

            paciensAdatNev.IsReadOnly = true;
            paciensAdatNev.Foreground = (Brush)bc.ConvertFrom("#FF1C9BB8");
            paciensAdatEmail.IsReadOnly = true;
            paciensAdatEmail.Foreground = (Brush)bc.ConvertFrom("#FF1C9BB8");
            paciensAdatFelhasznalonev.IsReadOnly = true;
            paciensAdatFelhasznalonev.Foreground = (Brush)bc.ConvertFrom("#FF1C9BB8");
            paciensAdatSzemelyiSzam.IsReadOnly = true;
            paciensAdatSzemelyiSzam.Foreground = (Brush)bc.ConvertFrom("#FF1C9BB8");
            paciensAdatTAJ.IsReadOnly = true;
            paciensAdatTAJ.Foreground = (Brush)bc.ConvertFrom("#FF1C9BB8");

            paciensAdatSzuletesiDatum.Visibility = Visibility.Hidden;
            paciensAdatSzuletesiDatumText.Visibility = Visibility.Visible;
            paciensAdatSzuletesiDatum.Foreground = (Brush)bc.ConvertFrom("#FF1C9BB8");

            paciensAdatLakcim.IsReadOnly = true;
            paciensAdatLakcim.Foreground = (Brush)bc.ConvertFrom("#FF1C9BB8");
            paciensAdatTelefonszam.IsReadOnly = true;
            paciensAdatTelefonszam.Foreground = (Brush)bc.ConvertFrom("#FF1C9BB8");

            paciensAdatNeme.Visibility = Visibility.Visible;
            paciensAdatNemeComboBox.Visibility = Visibility.Hidden;

            paciensAdatTavozasDatum.Visibility = Visibility.Hidden;
            paciensAdatTavozasText.Visibility = Visibility.Visible;
            paciensAdatTavozasDatum.Foreground = (Brush)bc.ConvertFrom("#FF1C9BB8");
        }

        private void paciensekAttekintesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            paciensMegtekintesGomb.Visibility = Visibility.Visible;
        }

        private void paciensKeresesGomb_Click(object sender, RoutedEventArgs e)
        {
            if (paciensKeresesNev.Text.Length < 1 && paciensKeresesSzuletesiDatum.SelectedDate == null)
            {
                System.Windows.MessageBox.Show("Előbb adjon meg egy nevet vagy születési dátumot!");
            }

            List<object> szurtPaciensek = new List<object>();

            // ha üresen hagyja, akkor a mai dátummal fog dolgozni és figyelmen kívül hagyja
            if (paciensKeresesSzuletesiDatum.SelectedDate == null)
            {
                szurtPaciensek = ugyintezoAttekintesFeldolgozo.Szures(paciensKeresesNev.Text, DateTime.Today);
            }
            else szurtPaciensek = ugyintezoAttekintesFeldolgozo.Szures(paciensKeresesNev.Text, paciensKeresesSzuletesiDatum.SelectedDate.Value);

            // frissíteni a gridet
            DataGridFrissítése(szurtPaciensek);
        }

        #endregion
        //Barni rész vége



        //Kitti része
        #region Kitti
        private void szamlaatekintesClick(object sender, RoutedEventArgs e)
        {
            ujPaciensFelveteleGrid.Visibility = Visibility.Hidden;
            //szamlakezelesGrid.Visibility = Visibility.Hidden;
            paciensMegtekinteseGrid.Visibility = Visibility.Hidden;
            paciensekAttekintesGrid.Visibility = Visibility.Hidden;
            ujszamlaGrid.Visibility = Visibility.Hidden;
            szamlaattekintesGrid.Visibility = Visibility.Visible;
        }

        private void HozzaadButton_Click(object sender, RoutedEventArgs e)
        {
            SzamlahozTetelHozzaadWindow szth = new SzamlahozTetelHozzaadWindow(pacienskivalasztasaComboBox.SelectedItem as Magankorhaz.Adatbazis.Paciens);
            szth.ShowDialog();
            if (szth.DialogResult == true)
            {
                Adatbazis.Orvos orvos = (Adatbazis.Orvos)szth.kezeloorvosComboBox.SelectedItem;
                string diagnozis = (string)szth.szolgaltatasneveComboBox.SelectedItem;
                int ar = (int)szth.SzolgaltatasAraLabel.Content;
            }
        }

        private void TorlesButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SzamlaKiallitasaButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ujszamlakiallitasaClick(object sender, RoutedEventArgs e)
        {
            ujPaciensFelveteleGrid.Visibility = Visibility.Hidden;
            //szamlakezelesGrid.Visibility = Visibility.Hidden;
            paciensMegtekinteseGrid.Visibility = Visibility.Hidden;
            paciensekAttekintesGrid.Visibility = Visibility.Hidden;
            szamlaattekintesGrid.Visibility = Visibility.Hidden;
            ujszamlaGrid.Visibility = Visibility.Visible;


            var paciensek = from akt in Magankorhaz.Adatbazis.AdatBazis.DataBase.Paciensek
                            select akt;
            pacienskek = new ObservableCollection<Magankorhaz.Adatbazis.Paciens>(paciensek);
            pacienskivalasztasaComboBox.ItemsSource = pacienskek;
            pacienskivalasztasaComboBox.SelectedItem = pacienskek.FirstOrDefault();

            if (pacienskivalasztasaComboBox.SelectedItem != null)
            {
                //ugyfeladatai.Content = pacienskivalasztasaComboBox.ItemsSource.ToString();
            }
        }
        
        #endregion
        // Kitti rész vége
    }
}