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
    /// Interaction logic for KezelesReszletei.xaml
    /// </summary>
    public partial class KezelesReszletei : Window
    {
        public KezelesReszletei(int id)
        {
            InitializeComponent();
            var kezeles = from x in Adatbazis.AdatBazis.DataBase.Kartonok
                          where x.Id == id
                          join orv in Adatbazis.AdatBazis.DataBase.Orvosok on x.OrvosID equals orv.Id
                          join pac in Adatbazis.AdatBazis.DataBase.Paciensek on x.PaciensID equals pac.Id
                          select new { OrvosNeve = orv.Nev, PaciensNeve = pac.Nev, Datum=x.KezelesDatuma, Reszletek=x.KezelesReszletei, Siker=x.KezelesSikeressege, Ar=x.KezelesKoltsege, Gyogyszer=x.Receptek };
            paciensTextbox.Text = kezeles.First().PaciensNeve;
            orvosTextbox.Text = kezeles.First().OrvosNeve;
            datumTextbox.Text = kezeles.First().Datum.ToString();
            gyogyszerTextbox.Text = kezeles.First().Gyogyszer;
            reszletekTextbox.Text = kezeles.First().Reszletek;
            if (kezeles.First().Siker)
	        {
                 sikeresTextbox.Text = "Sikeres kezelés";
	        }
            else
            {
                sikeresTextbox.Text = "Sikertelen kezelés";
            }
            arTextbox.Text = kezeles.First().Ar.ToString();
        }
    }
}
