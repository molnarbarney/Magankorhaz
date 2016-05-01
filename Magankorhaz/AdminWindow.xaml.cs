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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow(string felhasznalonev)
        {
            InitializeComponent();

            felhasznalo.Content = felhasznalonev;

        }

        private void kijelentkezesButton_Click(object sender, RoutedEventArgs e)
        {
            adminWindow.Close();
            Application.Current.MainWindow.Visibility = Visibility.Visible;
        }

        private void adminWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.MainWindow.Visibility = Visibility.Visible;
        }

        private void osztalyokMenuGomb_Click(object sender, RoutedEventArgs e)
        {
            felhasznaloVaszon.Visibility = Visibility.Hidden;
            osztalyVaszon.Visibility = Visibility.Visible;
            orvosVaszon.Visibility = Visibility.Hidden;
            ferohelyValt.Visibility = Visibility.Hidden;
            torlesOsztaly.Visibility = Visibility.Hidden;
            OsztalyokFrissitese();
            osztalyVaszon.Visibility = Visibility.Visible;
            orvosVaszon.Visibility = Visibility.Hidden;
            ferohelyValt.Visibility = Visibility.Hidden;
            torlesOsztaly.Visibility = Visibility.Hidden;
            OsztalyokFrissitese();
        }

        public class User
        {
            public string name { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public string role { get; set; }
        }

        public class Osztaly
        {
            public int id { get; set; }
            public string deptname { get; set; }
            public int rooms { get; set; }
            public int places { get; set; }
        }

        private void felhasznalokMenuGomb_Click(object sender, RoutedEventArgs e)
        {
            osztalyVaszon.Visibility = Visibility.Hidden;
            orvosVaszon.Visibility = Visibility.Hidden;
            felhasznaloVaszon.Visibility = Visibility.Visible;
            jelszoValt.Visibility = Visibility.Hidden;
            adatMod.Visibility = Visibility.Hidden;
            torlesUser.Visibility = Visibility.Hidden;
            
            FelhasznalokFrissitese();
            jelszoValt.Visibility = Visibility.Hidden;
            adatMod.Visibility = Visibility.Hidden;
            torlesUser.Visibility = Visibility.Hidden;
            FelhasznalokFrissitese();
        }

        private void jelszoValt_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = (User)felhasznaloLista.SelectedItems[0];
            UserControlok.JelszoModositas ujJelszo = new UserControlok.JelszoModositas(selectedUser.username, selectedUser.role);
            if (ujJelszo.ShowDialog() == true)
            {
                FelhasznalokFrissitese();
                jelszoValt.Visibility = Visibility.Hidden;
                adatMod.Visibility = Visibility.Hidden;
                torlesUser.Visibility = Visibility.Hidden;
            }
        }

        private void felhasznaloLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            jelszoValt.Visibility = Visibility.Visible;
            adatMod.Visibility = Visibility.Visible;
            torlesUser.Visibility = Visibility.Visible;
        }

        private void FelhasznalokFrissitese()
        {

            felhasznaloLista.Items.Clear();
            var adminok = from akt in Adatbazis.AdatBazis.DataBase.Adminok
                          select akt;
            var orvosok = from akt in Adatbazis.AdatBazis.DataBase.Orvosok
                          select akt;
            var paciensek = from akt in Adatbazis.AdatBazis.DataBase.Paciensek
                            select akt;
            var ugyintezok = from akt in Adatbazis.AdatBazis.DataBase.Ugyintezok
                             select akt;
            var vezetoseg = from akt in Adatbazis.AdatBazis.DataBase.VezetosegiTagok
                            select akt;
            foreach (var uj in adminok)
            {
                felhasznaloLista.Items.Add(new User() { name = uj.Nev, username = uj.Felhasznalonev, password = uj.Jelszo, role = "Admin" });
            }
            foreach (var uj in orvosok)
            {
                felhasznaloLista.Items.Add(new User() { name = uj.Nev, username = uj.Felhasznalonev, password = uj.Jelszo, role = "Orvos" });
            }
            foreach (var uj in paciensek)
            {
                felhasznaloLista.Items.Add(new User() { name = uj.Nev, username = uj.Felhasznalonev, password = uj.Jelszo, role = "Páciens" });
            }
            foreach (var uj in ugyintezok)
            {
                felhasznaloLista.Items.Add(new User() { name = uj.Nev, username = uj.Felhasznalonev, password = uj.Jelszo, role = "Ügyintéző" });
            }
            foreach (var uj in vezetoseg)
            {
                felhasznaloLista.Items.Add(new User() { name = uj.Nev, username = uj.Felhasznalonev, password = uj.Jelszo, role = "Vezető" });
            }
        }

        private void OsztalyokFrissitese()
        {
            osztalyLista.Items.Clear();
            var osztalyok = from akt in Adatbazis.AdatBazis.DataBase.Osztalyok
                            select akt;
            foreach (var uj in osztalyok)
            {
                osztalyLista.Items.Add(new Osztaly() { id = uj.Id, deptname = uj.Megnevezes, rooms = uj.SzobakSzama, places = uj.OsszesFerohely });
            }

        }

        private void osztalyLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ferohelyValt.Visibility = Visibility.Visible;
            torlesOsztaly.Visibility = Visibility.Visible;
        }

        private void ferohelyValt_Click(object sender, RoutedEventArgs e)
        {
            Osztaly selectedDept = (Osztaly)osztalyLista.SelectedItems[0];
            UserControlok.OsztalyModositas osztalyMod = new UserControlok.OsztalyModositas(selectedDept.id, true);
            if (osztalyMod.ShowDialog() == true)
            {
                OsztalyokFrissitese();
                ferohelyValt.Visibility = Visibility.Hidden;
                torlesOsztaly.Visibility = Visibility.Hidden;
            }
        }

        private void ujOsztaly_Click(object sender, RoutedEventArgs e)
        {
            UserControlok.OsztalyModositas ujOsztaly = new UserControlok.OsztalyModositas(1, false);
            if (ujOsztaly.ShowDialog() == true)
            {
                OsztalyokFrissitese();
                ferohelyValt.Visibility = Visibility.Hidden;
                torlesOsztaly.Visibility = Visibility.Hidden;
            }
        }

        public User szerkesztettUser;

        private void adatMod_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = (User)felhasznaloLista.SelectedItems[0];
            if (selectedUser.role == "Páciens")
            {
                MessageBox.Show("A páciensek adatait az ügyintézők kezelik.");
            }
            else
            {
                orvosVaszon.Visibility = Visibility.Visible;
                felhasznaloVaszon.Visibility = Visibility.Hidden;
                osztalyVaszon.Visibility = Visibility.Hidden;
                modositButton.Visibility = Visibility.Visible;
                felveszButton.Visibility = Visibility.Hidden;
                szerepkorLabel.Visibility = Visibility.Hidden;
                tipusCombo.Visibility = Visibility.Hidden;


                szerkesztettUser = selectedUser;

                if (selectedUser.role == "Admin")
                {
                    kepesitLabel.Visibility = Visibility.Hidden;
                    orvosKepesites.Visibility = Visibility.Hidden;
                    osztalyLabel.Visibility = Visibility.Hidden;
                    orvosOsztaly.Visibility = Visibility.Hidden;

                    var x = from akt in Adatbazis.AdatBazis.DataBase.Adminok
                            where akt.Felhasznalonev == selectedUser.username
                            select akt;

                    orvosNev.Text = x.First().Nev;
                    orvosEmail.Text = x.First().Email;
                    orvosUsernev.Text = x.First().Felhasznalonev;
                    orvosSzemszam.Text = x.First().SzemelyiSzam;
                    orvosTAJ.Text = x.First().TAJ.ToString();
                    orvosAdoszam.Text = x.First().Adoazonosito.ToString();
                    orvosCim.Text = x.First().Cim;
                    orvosTelefon.Text = x.First().Telefon;
                    orvosSzuletes.SelectedDate = x.First().SzuletesiDatum;
                    orvosBelepes.SelectedDate = x.First().MunkabaAllasDatuma;
                    orvosOraber.Text = x.First().OraberBrutto.ToString();
                    orvosPass1.Password = x.First().Jelszo;
                    orvosPass1.IsEnabled = false;
                    orvosPass2.Password = x.First().Jelszo;
                    orvosPass2.IsEnabled = false;

                }
                else if (selectedUser.role == "Orvos")
                {
                    kepesitLabel.Visibility = Visibility.Visible;
                    orvosKepesites.Visibility = Visibility.Visible;
                    osztalyLabel.Visibility = Visibility.Visible;
                    orvosOsztaly.Visibility = Visibility.Visible;
                    kepesitLabel.Content = "Képesítés:";

                    var x = from akt in Adatbazis.AdatBazis.DataBase.Orvosok
                            where akt.Felhasznalonev == selectedUser.username
                            select akt;

                    orvosNev.Text = x.First().Nev;
                    orvosEmail.Text = x.First().Email;
                    orvosUsernev.Text = x.First().Felhasznalonev;
                    orvosSzemszam.Text = x.First().SzemelyiSzam;
                    orvosTAJ.Text = x.First().TAJ.ToString();
                    orvosAdoszam.Text = x.First().Adoazonosito.ToString();
                    orvosCim.Text = x.First().Cim;
                    orvosTelefon.Text = x.First().Telefon;
                    orvosSzuletes.SelectedDate = x.First().SzuletesiDatum;
                    orvosBelepes.SelectedDate = x.First().MunkabaAllasDatuma;
                    orvosOraber.Text = x.First().OraberBrutto.ToString();
                    orvosKepesites.Text = x.First().Kepesites;
                    orvosPass1.Password = x.First().Jelszo;
                    orvosPass1.IsEnabled = false;
                    orvosPass2.Password = x.First().Jelszo;
                    orvosPass2.IsEnabled = false;


                    var osztalyok = from akt in Adatbazis.AdatBazis.DataBase.Osztalyok
                                    select akt;
                    List<string> deptlist = new List<string>();
                    foreach (var item in osztalyok)
                    {
                        deptlist.Add(item.Megnevezes);
                    }
                    orvosOsztaly.Items.Clear();
                    foreach (var osztalynev in deptlist)
                    {
                        orvosOsztaly.Items.Add(osztalynev);
                    }
                    int osztalyanakIDje = x.First().OsztalyID;
                    var oszt = from akt in Adatbazis.AdatBazis.DataBase.Osztalyok
                               where osztalyanakIDje == akt.Id
                               select akt;
                    foreach (var orvosOsztalya in oszt)
                    {
                        orvosOsztaly.Text = orvosOsztalya.Megnevezes;
                    }
                 }

                else if (selectedUser.role == "Ügyintéző")
                {
                    kepesitLabel.Visibility = Visibility.Hidden;
                    orvosKepesites.Visibility = Visibility.Hidden;
                    osztalyLabel.Visibility = Visibility.Hidden;
                    orvosOsztaly.Visibility = Visibility.Hidden;

                    var x = from akt in Adatbazis.AdatBazis.DataBase.Ugyintezok
                            where akt.Felhasznalonev == selectedUser.username
                            select akt;

                    orvosNev.Text = x.First().Nev;
                    orvosEmail.Text = x.First().Email;
                    orvosUsernev.Text = x.First().Felhasznalonev;
                    orvosSzemszam.Text = x.First().SzemelyiSzam;
                    orvosTAJ.Text = x.First().TAJ.ToString();
                    orvosAdoszam.Text = x.First().Adoazonosito.ToString();
                    orvosCim.Text = x.First().Cim;
                    orvosTelefon.Text = x.First().Telefon;
                    orvosSzuletes.SelectedDate = x.First().SzuletesiDatum;
                    orvosBelepes.SelectedDate = x.First().MunkabaAllasDatuma;
                    orvosOraber.Text = x.First().OraberBrutto.ToString();
                    orvosPass1.Password = x.First().Jelszo;
                    orvosPass1.IsEnabled = false;
                    orvosPass2.Password = x.First().Jelszo;
                    orvosPass2.IsEnabled = false;

                }
                else if (selectedUser.role == "Vezető")
                {
                    kepesitLabel.Visibility = Visibility.Visible;
                    orvosKepesites.Visibility = Visibility.Visible;
                    osztalyLabel.Visibility = Visibility.Hidden;
                    orvosOsztaly.Visibility = Visibility.Hidden;
                    kepesitLabel.Content = "Státusz:";


                    var x = from akt in Adatbazis.AdatBazis.DataBase.VezetosegiTagok
                            where akt.Felhasznalonev == selectedUser.username
                            select akt;

                    orvosNev.Text = x.First().Nev;
                    orvosEmail.Text = x.First().Email;
                    orvosUsernev.Text = x.First().Felhasznalonev;
                    orvosSzemszam.Text = x.First().SzemelyiSzam;
                    orvosTAJ.Text = x.First().TAJ.ToString();
                    orvosAdoszam.Text = x.First().Adoazonosito.ToString();
                    orvosCim.Text = x.First().Cim;
                    orvosTelefon.Text = x.First().Telefon;
                    orvosSzuletes.SelectedDate = x.First().SzuletesiDatum;
                    orvosBelepes.SelectedDate = x.First().MunkabaAllasDatuma;
                    orvosOraber.Text = x.First().OraberBrutto.ToString();
                    orvosKepesites.Text = x.First().Statusz;
                    orvosPass1.Password = x.First().Jelszo;
                    orvosPass1.IsEnabled = false;
                    orvosPass2.Password = x.First().Jelszo;
                    orvosPass2.IsEnabled = false;

                }
            }
        }

        private void ujUser_Click(object sender, RoutedEventArgs e)
        {
            orvosVaszon.Visibility = Visibility.Visible;
            felhasznaloVaszon.Visibility = Visibility.Hidden;
            osztalyVaszon.Visibility = Visibility.Hidden;
            modositButton.Visibility = Visibility.Hidden;
            felveszButton.Visibility = Visibility.Visible;
            orvosPass1.IsEnabled = true;
            orvosPass2.IsEnabled = true;
            orvosPass1.Password = "";
            orvosPass2.Password = "";
            orvosSzabadnap.Text = "";
            orvosNev.Text = "";
            orvosEmail.Text = "";
            orvosUsernev.Text = "";
            orvosSzemszam.Text = "";
            orvosTAJ.Text = "";
            orvosAdoszam.Text = "";
            orvosCim.Text = "";
            orvosTelefon.Text = "";
            orvosSzuletes.SelectedDate = null;
            orvosBelepes.SelectedDate = null;
            orvosOraber.Text = "";
            orvosKepesites.Text = "";
            var osztalyok = from akt in Adatbazis.AdatBazis.DataBase.Osztalyok
                            select akt;
            List<string> deptlist = new List<string>();
            foreach (var item in osztalyok)
            {
                deptlist.Add(item.Megnevezes);
            }
            orvosOsztaly.Items.Clear();
            foreach (var osztalynev in deptlist)
            {
                orvosOsztaly.Items.Add(osztalynev);
            }
        }

        private void tipusCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tipusCombo.SelectedIndex == 0)
            {
                kepesitLabel.Visibility = Visibility.Visible;
                osztalyLabel.Visibility = Visibility.Visible;
                orvosKepesites.Visibility = Visibility.Visible;
                orvosOsztaly.Visibility = Visibility.Visible;
                kepesitLabel.Content = "Képesítés:";
                orvosKepesites.Text = "";
            }
            else if (tipusCombo.SelectedIndex == 1)
            {
                kepesitLabel.Visibility = Visibility.Hidden;
                osztalyLabel.Visibility = Visibility.Hidden;
                orvosKepesites.Visibility = Visibility.Hidden;
                orvosOsztaly.Visibility = Visibility.Hidden;
            }
            else if (tipusCombo.SelectedIndex == 2)
            {
                kepesitLabel.Visibility = Visibility.Visible;
                osztalyLabel.Visibility = Visibility.Hidden;
                orvosKepesites.Visibility = Visibility.Visible;
                orvosOsztaly.Visibility = Visibility.Hidden;
                kepesitLabel.Content = "Státusz:";
                orvosKepesites.Text = "";
            }
        }

        private void felveszButton_Click(object sender, RoutedEventArgs e)
        {
            if (orvosNev.Text.Length < 5)
            {
                MessageBox.Show("A felhasználó neve nem lehet rövidebb mint 5 karakter!");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(orvosNev.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("A felhasználó nevében csak betűk szerepelhetnek!");
            }
            else if (orvosEmail.Text.Length < 10)
            {
                MessageBox.Show("A felhasználó email címe nem lehet rövidebb mint 10 karakter!");
            }
            else if (orvosUsernev.Text.Length < 5)
            {
                MessageBox.Show("A felhasználó felhasználóneve nem lehet rövidebb mint 5 karakter!");
            }
            else if (orvosSzemszam.Text.Length != 12)
            {
                MessageBox.Show("A felhasználó személyi száma 12 számjegy!");
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(orvosSzemszam.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("A felhasználó személyi száma csak számokból állhat!");
            }
            else if (orvosPass1.Password.Length < 5)
            {
                MessageBox.Show("A felhasználó megadott jelszava nem lehet rövidebb mint 5 karakter!");
            }
            else if (orvosPass1.Password != orvosPass2.Password)
            {
                MessageBox.Show("A felhasználó megadott jelszavai nem egyeznek!");
            }
            else if (orvosTAJ.Text.Length != 8)
            {
                MessageBox.Show("A felhasználó TAJ száma 8 számjegy!");
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(orvosTAJ.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("A felhasználó TAJ számában csak számok szerepelhetnek!");
            }
            else if (orvosAdoszam.Text.Length != 10)
            {
                MessageBox.Show("A felhasználó adószáma 10 számjegy!");
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(orvosAdoszam.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("A felhasználó adószáma csak számokból állhat!");
            }
            else if (orvosCim.Text.Length < 10)
            {
                System.Windows.MessageBox.Show("A felhasználó címe nem lehet rövidebb mint 10 karakter!");
            }
            else if (orvosTelefon.Text.Length < 12)
            {
                System.Windows.MessageBox.Show("A felhasználó telefonszáma nem lehet rövidebb mint 12 karakter!");
            }
            else if (orvosSzuletes.SelectedDate == null)
            {
                System.Windows.MessageBox.Show("A felhasználó születési dátuma nem lehet üres!");
            }
            else if (orvosBelepes.SelectedDate == null)
            {
                System.Windows.MessageBox.Show("A felhasználó belépési dátuma nem lehet üres!");
            }
            else if (orvosOraber.Text.Length == 0)
            {
                MessageBox.Show("A felhasználó órabére nem lehet üres!");
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(orvosOraber.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("Az órabér csak számokat tartalmazhat!");
            }
            else if (orvosSzabadnap.Text.Length == 0)
            {
                MessageBox.Show("A felhasználó szabadnapjainak száma nem lehet üres!");
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(orvosSzabadnap.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("A szabadnapok száma csak számokat tartalmazhat!");
            }
            else if (tipusCombo.SelectedIndex == 0 && orvosKepesites.Text.Length < 5)
            {
                MessageBox.Show("Az orvos képesítése nem lehet 5 karakternél rövidebb!");
            }
            else if (tipusCombo.SelectedIndex == 0 && orvosOsztaly.SelectedIndex == -1)
            {
                MessageBox.Show("Az orvos osztálya nem lehet üres!");
            }
            else if (tipusCombo.SelectedIndex == 2 && orvosKepesites.Text.Length < 5)
            {
                MessageBox.Show("A vezetőségi tag státusza nem lehet 5 karakternél rövidebb!");
            }
            else
            {
                //nincs hiba az adatokban, felvehetjük a usert!
                if (tipusCombo.SelectedIndex == 0)
                {
                    FeldolgozoOsztalyok.FelhasznaloFelvetel ujFelhFeldolgozo = new FeldolgozoOsztalyok.FelhasznaloFelvetel();
                    bool felhasznaloFelveve = ujFelhFeldolgozo.ujOrvosFelvetele(orvosNev.Text, orvosEmail.Text, orvosUsernev.Text, orvosSzemszam.Text, orvosPass1.Password, orvosTAJ.Text, orvosCim.Text, orvosTelefon.Text, orvosSzuletes.SelectedDate.Value, orvosBelepes.SelectedDate.Value,
                        orvosOraber.Text, orvosSzabadnap.Text, orvosOsztaly.SelectedItem.ToString(), orvosAdoszam.Text, orvosKepesites.Text, Magankorhaz.Adatbazis.AdatBazis.DataBase);
                }
                else if (tipusCombo.SelectedIndex == 1)
                {
                    FeldolgozoOsztalyok.FelhasznaloFelvetel ujFelhFeldolgozo = new FeldolgozoOsztalyok.FelhasznaloFelvetel();
                    bool felhasznaloFelveve = ujFelhFeldolgozo.ujUgyintezoFelvetele(orvosNev.Text, orvosEmail.Text, orvosUsernev.Text, orvosSzemszam.Text, orvosPass1.Password, orvosTAJ.Text, orvosCim.Text, orvosTelefon.Text, orvosSzuletes.SelectedDate.Value, orvosBelepes.SelectedDate.Value,
                        orvosOraber.Text, orvosSzabadnap.Text, orvosAdoszam.Text, Magankorhaz.Adatbazis.AdatBazis.DataBase);
                }
                else if (tipusCombo.SelectedIndex == 2)
                {
                    FeldolgozoOsztalyok.FelhasznaloFelvetel ujFelhFeldolgozo = new FeldolgozoOsztalyok.FelhasznaloFelvetel();
                    bool felhasznaloFelveve = ujFelhFeldolgozo.ujVezetoFelvetele(orvosNev.Text, orvosEmail.Text, orvosUsernev.Text, orvosSzemszam.Text, orvosPass1.Password, orvosTAJ.Text, orvosCim.Text, orvosTelefon.Text, orvosSzuletes.SelectedDate.Value, orvosBelepes.SelectedDate.Value,
                        orvosOraber.Text, orvosSzabadnap.Text, orvosAdoszam.Text, orvosKepesites.Text, Magankorhaz.Adatbazis.AdatBazis.DataBase);
                }
                felhasznalokMenuGomb_Click(sender, e);

            }
        }

        private void modositButton_Click(object sender, RoutedEventArgs e)
        {
            if (orvosNev.Text.Length < 5)
            {
                MessageBox.Show("A felhasználó neve nem lehet rövidebb mint 5 karakter!");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(orvosNev.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("A felhasználó nevében csak betűk szerepelhetnek!");
            }
            else if (orvosEmail.Text.Length < 10)
            {
                MessageBox.Show("A felhasználó email címe nem lehet rövidebb mint 10 karakter!");
            }
            else if (orvosUsernev.Text.Length < 5)
            {
                MessageBox.Show("A felhasználó felhasználóneve nem lehet rövidebb mint 5 karakter!");
            }
            else if (orvosSzemszam.Text.Length != 12)
            {
                MessageBox.Show("A felhasználó személyi száma 12 számjegy!");
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(orvosSzemszam.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("A felhasználó személyi száma csak számokból állhat!");
            }
            else if (orvosTAJ.Text.Length != 8)
            {
                MessageBox.Show("A felhasználó TAJ száma 8 számjegy!");
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(orvosTAJ.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("A felhasználó TAJ számában csak számok szerepelhetnek!");
            }
            else if (orvosAdoszam.Text.Length != 10)
            {
                MessageBox.Show("A felhasználó adószáma 10 számjegy!");
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(orvosAdoszam.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("A felhasználó adószáma csak számokból állhat!");
            }
            else if (orvosCim.Text.Length < 10)
            {
                System.Windows.MessageBox.Show("A felhasználó címe nem lehet rövidebb mint 10 karakter!");
            }
            else if (orvosTelefon.Text.Length < 12)
            {
                System.Windows.MessageBox.Show("A felhasználó telefonszáma nem lehet rövidebb mint 12 karakter!");
            }
            else if (orvosSzuletes.SelectedDate == null)
            {
                System.Windows.MessageBox.Show("A felhasználó születési dátuma nem lehet üres!");
            }
            else if (orvosBelepes.SelectedDate == null)
            {
                System.Windows.MessageBox.Show("A felhasználó belépési dátuma nem lehet üres!");
            }
            else if (orvosOraber.Text.Length == 0)
            {
                MessageBox.Show("A felhasználó órabére nem lehet üres!");
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(orvosOraber.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("Az órabér csak számokat tartalmazhat!");
            }
            else if (orvosSzabadnap.Text.Length == 0)
            {
                MessageBox.Show("A felhasználó szabadnapjainak száma nem lehet üres!");
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(orvosSzabadnap.Text, "^[a-zA-Z]"))
            {
                MessageBox.Show("A szabadnapok száma csak számokat tartalmazhat!");
            }
            else if (szerkesztettUser.role == "Orvos" && orvosKepesites.Text.Length < 5)
            {
                MessageBox.Show("Az orvos képesítése nem lehet 5 karakternél rövidebb!");
            }
            else if (szerkesztettUser.role == "Vezetőségi tag" && orvosKepesites.Text.Length < 5)
            {
                MessageBox.Show("A vezetőségi tag státusza nem lehet 5 karakternél rövidebb!");
            }
            else
            {
                //adatok helyesen kitöltve, módosíthatunk.
                if (szerkesztettUser.role == "Admin")
                {
                    var x = from akt in Adatbazis.AdatBazis.DataBase.Adminok
                            where akt.Felhasznalonev == szerkesztettUser.username
                            select akt;
                    foreach (var user in x)
                    {
                        user.Nev = orvosNev.Text;
                        user.Email = orvosEmail.Text;
                        user.Felhasznalonev = orvosUsernev.Text;
                        user.SzemelyiSzam = orvosSzemszam.Text;
                        user.TAJ = Int32.Parse(orvosTAJ.Text);
                        user.Adoazonosito = Int32.Parse(orvosAdoszam.Text);
                        user.Cim = orvosCim.Text;
                        user.Telefon = orvosTelefon.Text;
                        user.SzuletesiDatum = (DateTime)orvosSzuletes.SelectedDate;
                        user.MunkabaAllasDatuma = (DateTime)orvosBelepes.SelectedDate;
                        user.OraberBrutto = Int32.Parse(orvosOraber.Text);
                    }
                }
                if (szerkesztettUser.role == "Orvos")
                {
                    var oszt = from akt in Adatbazis.AdatBazis.DataBase.Osztalyok
                               where orvosOsztaly.SelectedItem.ToString() == akt.Megnevezes
                               select akt;
                    foreach (var osztaly in oszt)
                    {
                        orvosSzerkOsztalyID = osztaly.Id;
                    }
                    var x = from akt in Adatbazis.AdatBazis.DataBase.Orvosok
                            where akt.Felhasznalonev == szerkesztettUser.username
                            select akt;
                    foreach (var user in x)
                    {
                        user.Nev = orvosNev.Text;
                        user.Email = orvosEmail.Text;
                        user.Felhasznalonev = orvosUsernev.Text;
                        user.SzemelyiSzam = orvosSzemszam.Text;
                        user.TAJ = Int32.Parse(orvosTAJ.Text);
                        user.Adoazonosito = Int32.Parse(orvosAdoszam.Text);
                        user.Cim = orvosCim.Text;
                        user.Telefon = orvosTelefon.Text;
                        user.SzuletesiDatum = (DateTime)orvosSzuletes.SelectedDate;
                        user.MunkabaAllasDatuma = (DateTime)orvosBelepes.SelectedDate;
                        user.OraberBrutto = Int32.Parse(orvosOraber.Text);
                        user.Kepesites = orvosKepesites.Text;
                        user.OsztalyID = orvosSzerkOsztalyID;
                    }
                }
                if (szerkesztettUser.role == "Ügyintéző")
                {
                    var x = from akt in Adatbazis.AdatBazis.DataBase.Ugyintezok
                            where akt.Felhasznalonev == szerkesztettUser.username
                            select akt;
                    foreach (var user in x)
                    {
                        user.Nev = orvosNev.Text;
                        user.Email = orvosEmail.Text;
                        user.Felhasznalonev = orvosUsernev.Text;
                        user.SzemelyiSzam = orvosSzemszam.Text;
                        user.TAJ = Int32.Parse(orvosTAJ.Text);
                        user.Adoazonosito = Int32.Parse(orvosAdoszam.Text);
                        user.Cim = orvosCim.Text;
                        user.Telefon = orvosTelefon.Text;
                        user.SzuletesiDatum = (DateTime)orvosSzuletes.SelectedDate;
                        user.MunkabaAllasDatuma = (DateTime)orvosBelepes.SelectedDate;
                        user.OraberBrutto = Int32.Parse(orvosOraber.Text);
                    }
                }
                if (szerkesztettUser.role == "Vezető")
                {
                    var x = from akt in Adatbazis.AdatBazis.DataBase.VezetosegiTagok
                            where akt.Felhasznalonev == szerkesztettUser.username
                            select akt;
                    foreach (var user in x)
                    {
                        user.Nev = orvosNev.Text;
                        user.Email = orvosEmail.Text;
                        user.Felhasznalonev = orvosUsernev.Text;
                        user.SzemelyiSzam = orvosSzemszam.Text;
                        user.TAJ = Int32.Parse(orvosTAJ.Text);
                        user.Adoazonosito = Int32.Parse(orvosAdoszam.Text);
                        user.Cim = orvosCim.Text;
                        user.Telefon = orvosTelefon.Text;
                        user.SzuletesiDatum = (DateTime)orvosSzuletes.SelectedDate;
                        user.MunkabaAllasDatuma = (DateTime)orvosBelepes.SelectedDate;
                        user.OraberBrutto = Int32.Parse(orvosOraber.Text);
                        user.Statusz = orvosKepesites.Text;
                    }
                }
                Adatbazis.AdatBazis.DataBase.SaveChanges();
                MessageBox.Show("Módosítás megtörtént!");
                felhasznalokMenuGomb_Click(sender, e);
            }
        }

        public int orvosSzerkOsztalyID { get; set; }

        private void torlesUser_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = (User)felhasznaloLista.SelectedItems[0];

            MessageBoxResult valasz = System.Windows.MessageBox.Show("Biztosan törlöd?", "", System.Windows.MessageBoxButton.OKCancel);
            if (valasz == MessageBoxResult.OK)
            {



                if (selectedUser.role == "Admin")
                {
                    var x = from akt in Adatbazis.AdatBazis.DataBase.Adminok
                            where akt.Felhasznalonev == selectedUser.username
                            select akt;
                    foreach (var torlendo in x)
                    {
                        Adatbazis.AdatBazis.DataBase.Adminok.Remove(torlendo);
                    }
                    Adatbazis.AdatBazis.DataBase.SaveChanges();
                }
                else if (selectedUser.role == "Orvos")
                {
                    var x = from akt in Adatbazis.AdatBazis.DataBase.Orvosok
                            where akt.Felhasznalonev == selectedUser.username
                            select akt;
                    foreach (var torlendo in x)
                    {
                        Adatbazis.AdatBazis.DataBase.Orvosok.Remove(torlendo);
                    }
                    Adatbazis.AdatBazis.DataBase.SaveChanges();
                }
                else if (selectedUser.role == "Páciens")
                {
                    var x = from akt in Adatbazis.AdatBazis.DataBase.Paciensek
                            where akt.Felhasznalonev == selectedUser.username
                            select akt;
                    foreach (var torlendo in x)
                    {
                        Adatbazis.AdatBazis.DataBase.Paciensek.Remove(torlendo);
                    }
                    Adatbazis.AdatBazis.DataBase.SaveChanges();
                }
                else if (selectedUser.role == "Ügyintéző")
                {
                    var x = from akt in Adatbazis.AdatBazis.DataBase.Ugyintezok
                            where akt.Felhasznalonev == selectedUser.username
                            select akt;
                    foreach (var torlendo in x)
                    {
                        Adatbazis.AdatBazis.DataBase.Ugyintezok.Remove(torlendo);
                    }
                    Adatbazis.AdatBazis.DataBase.SaveChanges();
                }
                else if (selectedUser.role == "Vezető")
                {
                    var x = from akt in Adatbazis.AdatBazis.DataBase.VezetosegiTagok
                            where akt.Felhasznalonev == selectedUser.username
                            select akt;
                    foreach (var torlendo in x)
                    {
                        Adatbazis.AdatBazis.DataBase.VezetosegiTagok.Remove(torlendo);
                    }
                    Adatbazis.AdatBazis.DataBase.SaveChanges();
                }

                MessageBox.Show("A kiválasztott felhasználót töröltük.");
                FelhasznalokFrissitese();
                felhasznalokMenuGomb_Click(sender, e);
            }
        }

        private void torlesOsztaly_Click(object sender, RoutedEventArgs e)
        {
            Osztaly selectedDept = (Osztaly)osztalyLista.SelectedItems[0];

            MessageBoxResult valasz = System.Windows.MessageBox.Show("Biztosan törlöd?", "", System.Windows.MessageBoxButton.OKCancel);
            if (valasz == MessageBoxResult.OK)
            {
                var x = from akt in Adatbazis.AdatBazis.DataBase.Osztalyok
                        where selectedDept.id == akt.Id
                        select akt;

                foreach (var item in x)
                {
                    Adatbazis.AdatBazis.DataBase.Osztalyok.Remove(item);
                }
                MessageBox.Show("Osztály törölve.");
                Adatbazis.AdatBazis.DataBase.SaveChanges();
                OsztalyokFrissitese();
                osztalyokMenuGomb_Click(sender, e);
            }
        }
    }
}
