using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
        ObservableCollection<Magankorhaz.Adatbazis.Paciens> pacienskek;

        // Adatok betöltéséhez
        FeldolgozoOsztalyok.UgyintezoAttekintesFeldolgozo ugyintezoAttekintesFeldolgozo = new FeldolgozoOsztalyok.UgyintezoAttekintesFeldolgozo();

        // Időpontok frissítése/feltöltése
        Magankorhaz.FeldolgozoOsztalyok.RendelesiIdopontFeldolgozo idopontFeldolgozo = new FeldolgozoOsztalyok.RendelesiIdopontFeldolgozo();

        // Páciens adatainak módosításához
        FeldolgozoOsztalyok.PaciensAdatlapFeldolgozo paciensAdatlapFeldolgozo;

        // PáciensID - ha kéne valamihez
        public int paciensID { get; set; }

        public UgyintezoWindow(string felhasznalonev)
        {
            InitializeComponent();

            felhasznalo.Content = felhasznalonev;
       
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

        // Barni része
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

            // Egy kis hard coded érték...
            if (Convert.ToInt32(szabadFerohelyekSzam.Content) != 540)
            {
                // Férfiak - nők aránya
                paciensAranyokSzam.Content = ugyintezoAttekintesFeldolgozo.ferfiakNokAranya();

                // Legrégebbi páciens
                List<Adatbazis.Paciens> paciensek = new List<Adatbazis.Paciens>();
                paciensek = ugyintezoAttekintesFeldolgozo.legregebbiLegujabbPaciens();

                legregebbiPaciensNeve.Content = paciensek.First().Nev;
                legregebbiPaciensDatum.Content = paciensek.First().FelvetelDatuma.ToString("yyyy. MM. dd.");
                legujabbPaciensNeve.Content = paciensek.Last().Nev;
                legujabbPaciensDatum.Content = paciensek.Last().FelvetelDatuma.ToString("yyyy. MM. dd.");

                // DataGrid feltöltése
                DataGridFrissítése(ugyintezoAttekintesFeldolgozo.paciensek());

                paciensMegtekintesGomb.Visibility = Visibility.Hidden;

                // Szűrők lenullázása
                paciensKeresesGomb.IsEnabled = true;
                paciensKeresesNev.Text = "";
                paciensKeresesSzuletesiDatum.SelectedDate = null;
            }
            else
            {
                paciensAranyokSzam.Content = "";
                legregebbiPaciensNeve.Content = "";
                legregebbiPaciensDatum.Content = "";
                legujabbPaciensNeve.Content = "";
                legujabbPaciensDatum.Content = "";

                // Szűrők letiltása
                paciensKeresesGomb.IsEnabled = false;
            }
         
            // Dátum
            maiDatum.Content = DateTime.Now.Year + ". " + DateTime.Now.Month + ". " + DateTime.Now.Day + ".";
        }

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
            paciensAdatlapFeldolgozo = new FeldolgozoOsztalyok.PaciensAdatlapFeldolgozo(paciensEmail);

            Adatbazis.Paciens paciensAdatok = paciensAdatlapFeldolgozo.paciensAdatok;

            this.paciensID = paciensAdatok.Id;

            paciensAdatNev.Text = paciensAdatok.Nev;
            paciensAdatEmail.Text = paciensAdatok.Email;
            paciensAdatFelhasznalonev.Text = paciensAdatok.Felhasznalonev;
            paciensAdatJelszo.Password = paciensAdatok.Jelszo;
            paciensAdatSzemelyiSzam.Text = paciensAdatok.SzemelyiSzam;
            paciensAdatTAJ.Text = Convert.ToString(paciensAdatok.TAJ);

            paciensAdatSzuletesiDatum.SelectedDate = paciensAdatok.SzuletesiDatum;

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
                paciensAdatTavozasDatum.Visibility = Visibility.Hidden;
            }
            else
            {
                paciensAdatTavozasDatum.IsEnabled = false;
                paciensAdatTavozasDatum.SelectedDate = paciensAdatok.TavozasDatuma;
            }

            paciensAdatOrvos.Text = paciensAdatlapFeldolgozo.orvosNev;
            paciensAdatUgyvezeto.Text = paciensAdatlapFeldolgozo.ugyintezoNev;

            // Elhelyezéshez feltöltés
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

            // Időpontok frissítése/feltöltése
            IdopontokFrissitese();            
        }

        private void IdopontokFrissitese()
        {
            paciensAdatIdopontTorleseGomb.Visibility = Visibility.Hidden;
            paciensAdatIdopontModositasaGomb.Visibility = Visibility.Hidden;

            List<object> idopontok = idopontFeldolgozo.RendelesiIdopontokLekerdezese(this.paciensID);
            if (idopontok != null)
            {
                paciensIdpontokListView.ItemsSource = null;
                paciensIdpontokListView.ItemsSource = idopontok.ToList();
            }
        }

        private void IdopontokRefreshGomb_Click(object sender, RoutedEventArgs e)
        {
            IdopontokFrissitese();   
        }

        private void paciensAdatUjIdopontGomb_Click(object sender, RoutedEventArgs e)
        {
            paciensAdatIdopontTorleseGomb.Visibility = Visibility.Hidden;
            paciensAdatIdopontModositasaGomb.Visibility = Visibility.Hidden;

            UserControlok.UgyintezoIdopontFelvetel ujIdopont = new UserControlok.UgyintezoIdopontFelvetel();
            ujIdopont.paciensID = this.paciensID;
            ujIdopont.ShowDialog();
        }

        private void paciensAdatIdopontModositasaGomb_Click(object sender, RoutedEventArgs e)
        {
            paciensAdatIdopontTorleseGomb.Visibility = Visibility.Hidden;
            paciensAdatIdopontModositasaGomb.Visibility = Visibility.Hidden;

            UserControlok.UgyintezoIdopontModositas modositottIdopont = new UserControlok.UgyintezoIdopontModositas();
            modositottIdopont.paciensID = this.paciensID;
            modositottIdopont.modositandoIdopont = paciensIdpontokListView.SelectedValue.ToString();
            modositottIdopont.ShowDialog();
        }

        private void paciensIdpontokListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            paciensAdatIdopontTorleseGomb.Visibility = Visibility.Visible;
            paciensAdatIdopontModositasaGomb.Visibility = Visibility.Visible;
        }

        private void paciensAdatIdopontTorleseGomb_Click(object sender, RoutedEventArgs e)
        {
            string idopontSor = paciensIdpontokListView.SelectedValue.ToString();

            string[] idopontSorAdatok = idopontSor.Split(new string[] { "= " }, StringSplitOptions.None);

            string datumString = idopontSorAdatok[1].Remove(idopontSorAdatok[1].Length - 8);
            string reszletek = idopontSorAdatok[3].Remove(idopontSorAdatok[3].Length - 2);

            int torles = idopontFeldolgozo.IdopontTorlese(Convert.ToDateTime(datumString), reszletek);

            if (torles > 0)
            {
                System.Windows.MessageBox.Show("Sikeres törlés!"); 
            }
            else
            {
                System.Windows.MessageBox.Show("Hiba történt!");
            }

            IdopontokFrissitese();
        }

        private void paciensOsztalyElhelyezesModositasGomb_Click(object sender, RoutedEventArgs e)
        {
            paciensElhelyezesModositasakorLetiltandoGombok();

            paciensOsztalyAdatokFeloldasa();
        }

        private void paciensOsztalyElhelyezesMentesGomb_Click(object sender, RoutedEventArgs e)
        {
            bool elhelyezheto = paciensAdatlapFeldolgozo.paciensElhelyezesEllenorzes(paciensAdatOsztalyComboBox.SelectedValue.ToString(), Convert.ToInt32(paciensAdatSzobaComboBox.SelectedItem));

            if (elhelyezheto)
            {
                bool sikeresMentes = paciensAdatlapFeldolgozo.paciensElhelyezesMentes(paciensAdatlapFeldolgozo.paciensAdatok.Id, paciensAdatOsztalyComboBox.SelectedValue.ToString(), Convert.ToInt32(paciensAdatSzobaComboBox.SelectedItem));

                if (sikeresMentes)
                {
                    paciensAdatOsztalyText.Content = paciensAdatOsztalyComboBox.SelectedValue.ToString();
                    paciensAdatSzobaText.Content = paciensAdatSzobaComboBox.SelectedItem.ToString();
                    paciensAdatTavozasDatum.SelectedDate = null;

                    paciensOsztalyElhelyezesModositasGomb.Visibility = Visibility.Visible;
                    paciensOsztalyElhelyezesMentesGomb.Visibility = Visibility.Hidden;
                    paciensOsztalyElhelyezesMegseGomb.Visibility = Visibility.Hidden;

                    paciensElhelyezesModositasakorFeloldandoGombok();

                    paciensOsztalyAdatokLezarasa();
                }
            }
            else System.Windows.MessageBox.Show("Ez a szoba már foglalt! Kérem válasszon egy másikat!");
        }

        private void paciensOsztalyElhelyezesMegseGomb_Click(object sender, RoutedEventArgs e)
        {
            paciensElhelyezesModositasakorFeloldandoGombok();

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
            paciensAdatokModositasakorLetiltandoGombok();

            ugyintezoAttekintesFeldolgozo.paciensTempNev = paciensAdatNev.Text;
            ugyintezoAttekintesFeldolgozo.paciensTempEmail = paciensAdatEmail.Text;
            ugyintezoAttekintesFeldolgozo.paciensTempFelhasznalonev = paciensAdatFelhasznalonev.Text;
            ugyintezoAttekintesFeldolgozo.paciensTempJelszo = paciensAdatJelszo.Password;
            ugyintezoAttekintesFeldolgozo.paciensTempLakcim = paciensAdatLakcim.Text;
            ugyintezoAttekintesFeldolgozo.paciensTempNeme = paciensAdatNeme.Text;
            ugyintezoAttekintesFeldolgozo.paciensTempSzemelyiSzam = paciensAdatSzemelyiSzam.Text;
            ugyintezoAttekintesFeldolgozo.paciensTempSzuletesiDatum = paciensAdatSzuletesiDatum.SelectedDate.Value;
            ugyintezoAttekintesFeldolgozo.paciensTempTAJ = paciensAdatTAJ.Text;
            ugyintezoAttekintesFeldolgozo.paciensTempTelefonszam = paciensAdatTelefonszam.Text;

            if (paciensAdatTavozasDatum.SelectedDate != null)
            {
                ugyintezoAttekintesFeldolgozo.paciensTempTavozasDatuma = paciensAdatTavozasDatum.SelectedDate.Value;
            }
            else ugyintezoAttekintesFeldolgozo.paciensTempTavozasDatuma = new DateTime(1900, 1, 1);

            paciensAdatokFeloldasa();
        }

        private void paciensAdatokMentesGomb_Click(object sender, RoutedEventArgs e)
        {
            if (paciensAdatokEllenorzese())
            {
                paciensAdatokModositasGomb.IsEnabled = true;
                paciensAdatokMentesGomb.Visibility = Visibility.Hidden;
                paciensAdatokMegseGomb.Visibility = Visibility.Hidden;

                // Mentés
                Adatbazis.Paciens modositottPaciens = new Adatbazis.Paciens();
                modositottPaciens.Nev = paciensAdatNev.Text;
                modositottPaciens.Email = paciensAdatEmail.Text;
                modositottPaciens.Felhasznalonev = paciensAdatFelhasznalonev.Text;
                modositottPaciens.Jelszo = paciensAdatJelszo.Password;
                modositottPaciens.Cim = paciensAdatLakcim.Text;
                modositottPaciens.Neme = paciensAdatNeme.Text;
                modositottPaciens.SzemelyiSzam = paciensAdatSzemelyiSzam.Text;
                modositottPaciens.SzuletesiDatum = paciensAdatSzuletesiDatum.SelectedDate.Value;
                modositottPaciens.TAJ = Convert.ToInt32(paciensAdatTAJ.Text);
                modositottPaciens.Telefon = paciensAdatTelefonszam.Text;
                modositottPaciens.FelvetelDatuma = Convert.ToDateTime(paciensAdatFelvetel.Text);
                
                if (paciensAdatTavozasDatum.SelectedDate == null)
                {
                    modositottPaciens.TavozasDatuma = new DateTime(1900, 1, 1);
                }
                else modositottPaciens.TavozasDatuma = paciensAdatTavozasDatum.SelectedDate.Value;

                bool sikeresMentes = paciensAdatlapFeldolgozo.PaciensModositasa(paciensAdatlapFeldolgozo.paciensAdatok.Id, modositottPaciens);

                if (sikeresMentes)
                {
                    System.Windows.MessageBox.Show("Sikeres mentés!");

                    paciensAdatNev.Text = modositottPaciens.Nev;
                    paciensAdatEmail.Text = modositottPaciens.Email;
                    paciensAdatFelhasznalonev.Text = modositottPaciens.Felhasznalonev;
                    paciensAdatJelszo.Password = modositottPaciens.Jelszo;
                    paciensAdatLakcim.Text = modositottPaciens.Cim;
                    paciensAdatNeme.Text = modositottPaciens.Neme;
                    paciensAdatSzemelyiSzam.Text = modositottPaciens.SzemelyiSzam;
                    paciensAdatSzuletesiDatum.SelectedDate = modositottPaciens.SzuletesiDatum;
                    paciensAdatTAJ.Text = Convert.ToString(modositottPaciens.TAJ);
                    paciensAdatTelefonszam.Text = modositottPaciens.Telefon;
                    paciensAdatTavozasDatum.SelectedDate = modositottPaciens.TavozasDatuma;

                    if (paciensAdatlapFeldolgozo.paciensOsztaly == "Nincs elhelyezve")
                    {
                        paciensAdatOsztalyText.Content = paciensAdatlapFeldolgozo.paciensOsztaly;
                        paciensAdatSzobaText.Content = "";
                    }
                }

                paciensAdatokLezarasa();
                paciensAdatokModositasaUtalFloldandoGombok();
            }
        }

        private void paciensAdatokMegseGomb_Click(object sender, RoutedEventArgs e)
        {
            paciensAdatokModositasaUtalFloldandoGombok();

            paciensAdatNev.Text = ugyintezoAttekintesFeldolgozo.paciensTempNev;
            paciensAdatEmail.Text = ugyintezoAttekintesFeldolgozo.paciensTempEmail;
            paciensAdatFelhasznalonev.Text = ugyintezoAttekintesFeldolgozo.paciensTempFelhasznalonev;
            paciensAdatJelszo.Password = ugyintezoAttekintesFeldolgozo.paciensTempJelszo;
            paciensAdatLakcim.Text = ugyintezoAttekintesFeldolgozo.paciensTempLakcim;
            paciensAdatNeme.Text = ugyintezoAttekintesFeldolgozo.paciensTempNeme;
            paciensAdatSzemelyiSzam.Text = ugyintezoAttekintesFeldolgozo.paciensTempSzemelyiSzam;
            paciensAdatSzuletesiDatum.SelectedDate = ugyintezoAttekintesFeldolgozo.paciensTempSzuletesiDatum;
            paciensAdatTAJ.Text = ugyintezoAttekintesFeldolgozo.paciensTempTAJ;
            paciensAdatTelefonszam.Text = ugyintezoAttekintesFeldolgozo.paciensTempTelefonszam;

            if (ugyintezoAttekintesFeldolgozo.paciensTempTavozasDatuma == new DateTime(1900, 1, 1))
            {
                paciensAdatTavozasDatum.SelectedDate = null;
            }
            else paciensAdatTavozasDatum.SelectedDate = ugyintezoAttekintesFeldolgozo.paciensTempTavozasDatuma;
            
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
            paciensAdatJelszo.IsEnabled = true;
            paciensAdatJelszo.Foreground = (Brush)bc.ConvertFrom("#FFF75E24");

            paciensAdatSzemelyiSzam.IsReadOnly = false;
            paciensAdatSzemelyiSzam.Foreground = (Brush)bc.ConvertFrom("#FFF75E24");
            paciensAdatTAJ.IsReadOnly = false;
            paciensAdatTAJ.Foreground = (Brush)bc.ConvertFrom("#FFF75E24");

            paciensAdatSzuletesiDatum.IsEnabled = true;
            paciensAdatSzuletesiDatum.Foreground = (Brush)bc.ConvertFrom("#FFF75E24");

            paciensAdatLakcim.IsReadOnly = false;
            paciensAdatLakcim.Foreground = (Brush)bc.ConvertFrom("#FFF75E24");
            paciensAdatTelefonszam.IsReadOnly = false;
            paciensAdatTelefonszam.Foreground = (Brush)bc.ConvertFrom("#FFF75E24");

            paciensAdatNeme.Visibility = Visibility.Hidden;
            paciensAdatNemeComboBox.Visibility = Visibility.Visible;

            paciensAdatTavozasDatum.IsEnabled = true;
            paciensAdatTavozasDatum.Visibility = Visibility.Visible;
            paciensAdatTavozasDatum.Foreground = (Brush)bc.ConvertFrom("#FFF75E24");
        }

        private bool paciensAdatokEllenorzese()
        {
            int errors = 0;

            if (paciensAdatNev.Text.Length < 5)
            {
                System.Windows.MessageBox.Show("A páciens neve nem lehet üres és rövidebb mint 5 karakter!");
                paciensAdatNev.Text = ugyintezoAttekintesFeldolgozo.paciensTempNev;
                errors++;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(paciensAdatNev.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("A páciens nevében csakis betűk szerepelhetnek!");
                paciensAdatNev.Text = ugyintezoAttekintesFeldolgozo.paciensTempNev;
                errors++;
            }
            if (paciensAdatEmail.Text.Length < 10)
            {
                System.Windows.MessageBox.Show("A páciens email címe nem lehet üres és rövidebb mint 10 karakter!");
                paciensAdatEmail.Text = ugyintezoAttekintesFeldolgozo.paciensTempEmail;
                errors++;
            }
            if (paciensAdatFelhasznalonev.Text.Length < 5)
            {
                System.Windows.MessageBox.Show("A páciens felhasználóneve nem lehet üres és rövidebb mint 10 karakter!");
                paciensAdatFelhasznalonev.Text = ugyintezoAttekintesFeldolgozo.paciensTempFelhasznalonev;
                errors++;
            }
            if (paciensAdatSzemelyiSzam.Text.Length != 12)
            {
                System.Windows.MessageBox.Show("A páciens személyi száma 12 számjegy!");
                paciensAdatSzemelyiSzam.Text = ugyintezoAttekintesFeldolgozo.paciensTempSzemelyiSzam;
                errors++;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(paciensAdatSzemelyiSzam.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("A páciens személyi számában csakis számok szerepelhetnek!");
                paciensAdatSzemelyiSzam.Text = ugyintezoAttekintesFeldolgozo.paciensTempSzemelyiSzam;
                errors++;
            }
            if (paciensAdatJelszo.Password.Length < 5)
            {
                System.Windows.MessageBox.Show("A páciens megadott jelszava nem lehet üres és rövidebb mint 5 karakter!");
                paciensAdatJelszo.Password = ugyintezoAttekintesFeldolgozo.paciensTempJelszo;
                errors++;
            }
            if (paciensAdatTAJ.Text.Length != 8)
            {
                System.Windows.MessageBox.Show("A páciens TAJ száma 8 számjegy!");
                paciensAdatTAJ.Text = ugyintezoAttekintesFeldolgozo.paciensTempTAJ;
                errors++;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(paciensAdatTAJ.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("A páciens TAJ számában csakis számok szerepelhetnek!");
                paciensAdatTAJ.Text = ugyintezoAttekintesFeldolgozo.paciensTempTAJ;
                errors++;
            }
            if (paciensAdatLakcim.Text.Length < 10)
            {
                System.Windows.MessageBox.Show("A páciens címe nem lehet rövidebb mint 10 karakter!");
                paciensAdatLakcim.Text = ugyintezoAttekintesFeldolgozo.paciensTempLakcim;
                errors++;
            }
            if (paciensAdatTelefonszam.Text.Length < 12)
            {
                System.Windows.MessageBox.Show("A páciens telefonszáma nem lehet rövidebb mint 12 karakter!");
                paciensAdatTelefonszam.Text = ugyintezoAttekintesFeldolgozo.paciensTempTelefonszam;
                errors++;
            }

            if (errors > 0)
            {
                return false;
            }
            else return true;
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
            paciensAdatJelszo.IsEnabled = false;
            paciensAdatJelszo.Foreground = (Brush)bc.ConvertFrom("#FF1C9BB8");

            paciensAdatSzemelyiSzam.IsReadOnly = true;
            paciensAdatSzemelyiSzam.Foreground = (Brush)bc.ConvertFrom("#FF1C9BB8");
            paciensAdatTAJ.IsReadOnly = true;
            paciensAdatTAJ.Foreground = (Brush)bc.ConvertFrom("#FF1C9BB8");

            paciensAdatSzuletesiDatum.IsEnabled = false;
            paciensAdatSzuletesiDatum.Foreground = (Brush)bc.ConvertFrom("#FF1C9BB8");

            paciensAdatLakcim.IsReadOnly = true;
            paciensAdatLakcim.Foreground = (Brush)bc.ConvertFrom("#FF1C9BB8");
            paciensAdatTelefonszam.IsReadOnly = true;
            paciensAdatTelefonszam.Foreground = (Brush)bc.ConvertFrom("#FF1C9BB8");

            paciensAdatNeme.Visibility = Visibility.Visible;
            paciensAdatNemeComboBox.Visibility = Visibility.Hidden;

            paciensAdatTavozasDatum.IsEnabled = false;
            if (paciensAdatTavozasDatum.SelectedDate == null)
            {
                paciensAdatTavozasDatum.Visibility = Visibility.Hidden;
            }
            paciensAdatTavozasDatum.Foreground = (Brush)bc.ConvertFrom("#FF1C9BB8");
        }

        private void paciensAdatokModositasakorLetiltandoGombok()
        {
            paciensAdatokModositasGomb.IsEnabled = false;
            paciensAdatokMentesGomb.Visibility = Visibility.Visible;
            paciensAdatokMegseGomb.Visibility = Visibility.Visible;
            paciensAdatokTorlesGomb.IsEnabled = false;

            attekintesMenuGomb.IsEnabled = false;
            ujPaciensMenuGomb.IsEnabled = false;
            szamlakMenuGomb.IsEnabled = false;
            paciensOsztalyElhelyezesModositasGomb.IsEnabled = false;
            paciensAdatUjIdopontGomb.IsEnabled = false;
            paciensAdatIdopontTorleseGomb.Visibility = Visibility.Hidden;
            paciensAdatIdopontModositasaGomb.Visibility = Visibility.Hidden;
            kijelentkezesButton.IsEnabled = false;
        }

        private void paciensAdatokModositasaUtalFloldandoGombok()
        {
            paciensAdatokModositasGomb.IsEnabled = true;
            paciensAdatokMentesGomb.Visibility = Visibility.Hidden;
            paciensAdatokMegseGomb.Visibility = Visibility.Hidden;
            paciensAdatokTorlesGomb.IsEnabled = true;

            attekintesMenuGomb.IsEnabled = true;
            ujPaciensMenuGomb.IsEnabled = true;
            szamlakMenuGomb.IsEnabled = true;
            paciensOsztalyElhelyezesModositasGomb.IsEnabled = true;
            paciensAdatUjIdopontGomb.IsEnabled = true;
            paciensAdatIdopontTorleseGomb.Visibility = Visibility.Hidden;
            paciensAdatIdopontModositasaGomb.Visibility = Visibility.Hidden;
            kijelentkezesButton.IsEnabled = true;
        }

        private void paciensElhelyezesModositasakorLetiltandoGombok()
        {
            paciensOsztalyElhelyezesModositasGomb.Visibility = Visibility.Hidden;
            paciensOsztalyElhelyezesMentesGomb.Visibility = Visibility.Visible;
            paciensOsztalyElhelyezesMegseGomb.Visibility = Visibility.Visible;

            paciensAdatokModositasGomb.IsEnabled = false;
            paciensAdatokTorlesGomb.IsEnabled = false;

            attekintesMenuGomb.IsEnabled = false;
            ujPaciensMenuGomb.IsEnabled = false;
            szamlakMenuGomb.IsEnabled = false;

            paciensAdatUjIdopontGomb.IsEnabled = false;
            paciensAdatIdopontTorleseGomb.Visibility = Visibility.Hidden;
            paciensAdatIdopontModositasaGomb.Visibility = Visibility.Hidden;
            kijelentkezesButton.IsEnabled = false;
        }

        private void paciensElhelyezesModositasakorFeloldandoGombok()
        {
            paciensOsztalyElhelyezesModositasGomb.Visibility = Visibility.Visible;
            paciensOsztalyElhelyezesMentesGomb.Visibility = Visibility.Hidden;
            paciensOsztalyElhelyezesMegseGomb.Visibility = Visibility.Hidden;

            paciensAdatokModositasGomb.IsEnabled = true;
            paciensAdatokMentesGomb.Visibility = Visibility.Hidden;
            paciensAdatokMegseGomb.Visibility = Visibility.Hidden;
            paciensAdatokTorlesGomb.IsEnabled = true;

            attekintesMenuGomb.IsEnabled = true;
            ujPaciensMenuGomb.IsEnabled = true;
            szamlakMenuGomb.IsEnabled = true;
            paciensOsztalyElhelyezesModositasGomb.IsEnabled = true;
            paciensAdatUjIdopontGomb.IsEnabled = true;
            paciensAdatIdopontTorleseGomb.Visibility = Visibility.Hidden;
            paciensAdatIdopontModositasaGomb.Visibility = Visibility.Hidden;
            kijelentkezesButton.IsEnabled = true;
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
        // Barni rész vége

        // Kitti része
        #region Kitti

        ObservableCollection<Magankorhaz.Adatbazis.Szamla> TaroltKartonok;
        private void szamlaatekintesClick(object sender, RoutedEventArgs e)
        {
            ujPaciensFelveteleGrid.Visibility = Visibility.Hidden;
            //szamlakezelesGrid.Visibility = Visibility.Hidden;
            paciensMegtekinteseGrid.Visibility = Visibility.Hidden;
            paciensekAttekintesGrid.Visibility = Visibility.Hidden;
            ujszamlaGrid.Visibility = Visibility.Hidden;
            szamlaattekintesGrid.Visibility = Visibility.Visible;


            
            TaroltSzamlaTartalom.ItemsSource = TaroltKartonok;
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

                var ídé = from akt in Magankorhaz.Adatbazis.AdatBazis.DataBase.Kartonok
                          where akt.OrvosID == orvos.Id && akt.KezelesReszletei == diagnozis && akt.KezelesKoltsege == ar
                          select akt.Id;

                var szamlaId = from akt in Adatbazis.AdatBazis.DataBase.Szamlak
                               where akt.KartonID == ídé.FirstOrDefault()
                               select akt.Id;

                vmsz.SzamlahozSzamlak.Add(new Szamlahoz() { Id = szamlaId.FirstOrDefault(), Orvos = orvos.Nev, SzolgaltatasNeve = diagnozis, SzolgaltatasAra = ar, KartonID = ídé.FirstOrDefault() });
                int összeg = 0;
                foreach (var item in vmsz.SzamlahozSzamlak)
                {
                    összeg += item.SzolgaltatasAra;
                }
                fizetendoosszeg.Content = összeg;
                if (fizetendoosszeg.Content != null && !fizetendoosszeg.Content.Equals(0))
                {
                    valutavaltoButton.IsEnabled = true;
                }
                else
                {
                    valutavaltoButton.IsEnabled = false;
                }
            }

        }

        private void TorlesButton_Click(object sender, RoutedEventArgs e)
        {
            if (SzamlaTartalom.SelectedIndex != -1)
            {
                vmsz.SzamlahozSzamlak.RemoveAt(SzamlaTartalom.SelectedIndex);
            }
            int összeg = 0;
            foreach (var item in vmsz.SzamlahozSzamlak)
            {
                összeg += item.SzolgaltatasAra;
            }
            fizetendoosszeg.Content = összeg;
            if (fizetendoosszeg.Content != null && !fizetendoosszeg.Content.Equals(0))
            {
                valutavaltoButton.IsEnabled = true;
            }
            else
            {
                valutavaltoButton.IsEnabled = false;
            }
        }

        private void SzamlaKiallitasaButton_Click(object sender, RoutedEventArgs e)
        {
            var segedQuery = vmsz.SzamlahozSzamlak.Select(x => x.KartonID).ToList();
            
            var querym = from akt in Magankorhaz.Adatbazis.AdatBazis.DataBase.Szamlak
                        where segedQuery.Contains(akt.KartonID)
                        select akt;

            foreach (var item in querym)
            {
                item.Fizetendo = vmsz.SzamlahozSzamlak.SingleOrDefault(x => x.KartonID == item.KartonID).SzolgaltatasAra;
                item.Befizetve = true;
                item.BefizetesDatuma = DateTime.UtcNow.ToLocalTime();
            }

            Magankorhaz.Adatbazis.AdatBazis.DataBase.SaveChanges();

            var q = from akt in Magankorhaz.Adatbazis.AdatBazis.DataBase.Szamlak
                    where akt.Fizetendo != null
                    select akt;

            TaroltKartonok = new ObservableCollection<Adatbazis.Szamla>(q);

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

            vmsz.SzamlahozSzamlak.Clear();
            if (FizetveCheckBox.IsChecked.Value)
            {
                FizetveCheckBox.IsChecked = false;
            }
            valutavaltoButton.IsEnabled = false;
            fizetendoosszeg.Content = 0;
        }

        ViewModelSzamlahoz vmsz;
        private void szamlakezelesGrid_Loaded(object sender, RoutedEventArgs e)
        {
            vmsz = new ViewModelSzamlahoz();
            this.DataContext = vmsz;

            var q = from akt in Magankorhaz.Adatbazis.AdatBazis.DataBase.Szamlak
                    where akt.Fizetendo != null
                    select akt;

            TaroltKartonok = new ObservableCollection<Adatbazis.Szamla>(q);
        }

        private void ValutaValto_Click(object sender, RoutedEventArgs e)
        {
            ValutaValto vv = new ValutaValto(fizetendoosszeg.Content.ToString());
            vv.ShowDialog();
        }
        #endregion            

        // Kitti rész vége
    }

    class BindableSzamlahoz : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string s = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(s));
            }
        }
    }

    class ViewModelSzamlahoz : BindableSzamlahoz
    {

        ObservableCollection<Szamlahoz> szamlahozSzamlak;

        public ObservableCollection<Szamlahoz> SzamlahozSzamlak
        {
            get { return szamlahozSzamlak; }
            set { szamlahozSzamlak = value; OnPropertyChanged(); }
        }
        
        public ViewModelSzamlahoz()
        {
            szamlahozSzamlak = new ObservableCollection<Szamlahoz>();
        }

    }

    public class Szamlahoz
    {
        public int Id { get; set; }
        public string Orvos { get; set; }
        public string SzolgaltatasNeve { get; set; }
        public int SzolgaltatasAra { get; set; }
        public int KartonID { get; set; }
    }
}