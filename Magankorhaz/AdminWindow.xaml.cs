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
            ferohelyValt.Visibility = Visibility.Hidden;
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
            felhasznaloVaszon.Visibility = Visibility.Visible;
            jelszoValt.Visibility = Visibility.Hidden;
            adatMod.Visibility = Visibility.Hidden;
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
            }
        }

        private void felhasznaloLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            jelszoValt.Visibility = Visibility.Visible;
            adatMod.Visibility = Visibility.Visible;
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
        }

        private void ferohelyValt_Click(object sender, RoutedEventArgs e)
        {
            Osztaly selectedDept = (Osztaly)osztalyLista.SelectedItems[0];
            UserControlok.OsztalyModositas osztalyMod = new UserControlok.OsztalyModositas(selectedDept.id, true);
            if (osztalyMod.ShowDialog() == true)
            {
                OsztalyokFrissitese();
                ferohelyValt.Visibility = Visibility.Hidden;
            }
        }

        private void ujOsztaly_Click(object sender, RoutedEventArgs e)
        {
            UserControlok.OsztalyModositas ujOsztaly = new UserControlok.OsztalyModositas(1, false);
            if (ujOsztaly.ShowDialog() == true)
            {
                OsztalyokFrissitese();
                ferohelyValt.Visibility = Visibility.Hidden;
            }
        }

        private void adatMod_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ujUser_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
