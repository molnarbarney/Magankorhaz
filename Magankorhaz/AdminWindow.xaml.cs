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

        }

        public class User
        {
            public int id { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public string role { get; set; }
        }

        private void felhasznalokMenuGomb_Click(object sender, RoutedEventArgs e)
        {
            felhasznaloVaszon.Visibility = Visibility.Visible;
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
                felhasznaloLista.Items.Add(new User() { id = uj.Id, username = uj.Felhasznalonev, password = uj.Jelszo, role = "Admin" });
            }
            foreach (var uj in orvosok)
            {
                felhasznaloLista.Items.Add(new User() { id = uj.Id, username = uj.Felhasznalonev, password = uj.Jelszo, role = "Orvos" });
            }
            foreach (var uj in paciensek)
            {
                felhasznaloLista.Items.Add(new User() { id = uj.Id, username = uj.Felhasznalonev, password = uj.Jelszo, role = "Páciens" });
            }
            foreach (var uj in ugyintezok)
            {
                felhasznaloLista.Items.Add(new User() { id = uj.Id, username = uj.Felhasznalonev, password = uj.Jelszo, role = "Ügyintéző" });
            }
            foreach (var uj in vezetoseg)
            {
                felhasznaloLista.Items.Add(new User() { id = uj.Id, username = uj.Felhasznalonev, password = uj.Jelszo, role = "Vezető" });
            }

        }

        private void jelszoValt_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = (User)felhasznaloLista.SelectedItems[0];
      //      ChosenOne.Content = selectedUser.username;
            UserControlok.JelszoModositas ujJelszo = new UserControlok.JelszoModositas(selectedUser.username, selectedUser.role);
            ujJelszo.ShowDialog();
            
        }

        private void felhasznaloLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            jelszoValt.Visibility = Visibility.Visible;

        }
    }
}
