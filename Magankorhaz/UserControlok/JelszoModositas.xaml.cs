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
        public JelszoModositas(string usernev, string szerepkor)
        {
            InitializeComponent();
            userLabel.Content = usernev;
           

            if (szerepkor == "Admin")
            {
                var x = from akt in Adatbazis.AdatBazis.DataBase.Adminok
                        where akt.Felhasznalonev == usernev
                        select akt.Jelszo;
            }
            else if (szerepkor == "Orvos")
	        {
		        var x = from akt in Adatbazis.AdatBazis.DataBase.Orvosok
                        where akt.Felhasznalonev == usernev
                        select akt.Jelszo;
	        }
            else if (szerepkor == "Páciens")
            {
                var x = from akt in Adatbazis.AdatBazis.DataBase.Paciensek
                        where akt.Felhasznalonev == usernev
                        select akt.Jelszo;
            }
            else if (szerepkor == "Ügyintéző")
	        {
		        var x = from akt in Adatbazis.AdatBazis.DataBase.Ugyintezok
                        where akt.Felhasznalonev == usernev
                        select akt.Jelszo;
	        }   
            else if (szerepkor == "Vezető")
        	{
		        var x = from akt in Adatbazis.AdatBazis.DataBase.VezetosegiTagok
                        where akt.Felhasznalonev == usernev
                        select akt.Jelszo;
	        }

            oldPassword.Text = user;
	
		 
	
        }

              
            
        }
    
}
