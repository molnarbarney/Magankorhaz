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


namespace Magankorhaz.UserControlok
{
    /// <summary>
    /// Interaction logic for JelszoModositas.xaml
    /// </summary>
    public partial class JelszoModositas : Window
    {
        public string user { get; set; }
        public string name { get; set; }
        public string role { get; set; }
        public string usrnm { get; set; }
        public JelszoModositas(string usernev, string szerepkor)
        {
            InitializeComponent();
            userLabel.Content = usernev;
            role = szerepkor;
            usrnm = usernev;
           

            if (szerepkor == "Admin")
            {
                var x = from akt in Adatbazis.AdatBazis.DataBase.Adminok
                        where akt.Felhasznalonev == usernev
                        select akt;
                user = x.First().Jelszo;
                name = x.First().Nev;
            }
            else if (szerepkor == "Orvos")
	        {
		        var x = from akt in Adatbazis.AdatBazis.DataBase.Orvosok
                        where akt.Felhasznalonev == usernev
                        select akt;
                user = x.First().Jelszo;
                name = x.First().Nev;
	        }
            else if (szerepkor == "Páciens")
            {
                var x = from akt in Adatbazis.AdatBazis.DataBase.Paciensek
                        where akt.Felhasznalonev == usernev
                        select akt;
                user = x.First().Jelszo;
                name = x.First().Nev;
            }
            else if (szerepkor == "Ügyintéző")
	        {
		        var x = from akt in Adatbazis.AdatBazis.DataBase.Ugyintezok
                        where akt.Felhasznalonev == usernev
                        select akt;
                user = x.First().Jelszo;
                name = x.First().Nev;
	        }   
            else if (szerepkor == "Vezető")
        	{
		        var x = from akt in Adatbazis.AdatBazis.DataBase.VezetosegiTagok
                        where akt.Felhasznalonev == usernev
                        select akt;
                user = x.First().Jelszo;
                name = x.First().Nev;
	        }

            oldPassword.Text = user;
            userLabel.Content = name;
	
		 
	
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (role == "Admin")
            {
                var x = from akt in Adatbazis.AdatBazis.DataBase.Adminok
                        where akt.Felhasznalonev == usrnm
                        select akt;
                x.First().Jelszo = newPassword.Text;
            }
            else if (role == "Orvos")
            {
                var x = from akt in Adatbazis.AdatBazis.DataBase.Orvosok
                        where akt.Felhasznalonev == usrnm
                        select akt;
                x.First().Jelszo = newPassword.Text;
            }
            else if (role == "Páciens")
            {
                var x = from akt in Adatbazis.AdatBazis.DataBase.Paciensek
                        where akt.Felhasznalonev == usrnm
                        select akt;
                x.First().Jelszo = newPassword.Text;
            }
            else if (role == "Ügyintéző")
            {
                var x = from akt in Adatbazis.AdatBazis.DataBase.Ugyintezok
                        where akt.Felhasznalonev == usrnm
                        select akt;
                x.First().Jelszo = newPassword.Text;
            }
            else if (role == "Vezető")
            {
                var x = from akt in Adatbazis.AdatBazis.DataBase.VezetosegiTagok
                        where akt.Felhasznalonev == usrnm
                        select akt;
                x.First().Jelszo = newPassword.Text;
            }

            Adatbazis.AdatBazis.DataBase.SaveChanges();
            this.DialogResult = true;
            this.Close();
        }

        private void newPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (newPassword.Text != null)
            {
                valtoztatGomb.IsEnabled = true;
            }
        }

              
            
        }
    
}