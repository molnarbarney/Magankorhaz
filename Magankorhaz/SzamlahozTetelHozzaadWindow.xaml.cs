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
    /// Interaction logic for SzamlahozTetelHozzaadWindow.xaml
    /// </summary>
    public partial class SzamlahozTetelHozzaadWindow : Window
    {
        ObservableCollection<Magankorhaz.Adatbazis.Orvos> orvoskak;
        ObservableCollection<string> kezelesek;
        Magankorhaz.Adatbazis.Paciens emberke;

        public SzamlahozTetelHozzaadWindow(Magankorhaz.Adatbazis.Paciens paciens)
        {
            InitializeComponent();
            emberke = paciens;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var orvosokID = from akt in Magankorhaz.Adatbazis.AdatBazis.DataBase.Kartonok
                            where emberke.Id == akt.PaciensID
                            select akt.OrvosID;

            var orvosok = from akt in Magankorhaz.Adatbazis.AdatBazis.DataBase.Orvosok
                          where orvosokID.Contains(akt.Id)
                          select akt;

            orvoskak = new ObservableCollection<Adatbazis.Orvos>(orvosok);
            kezeloorvosComboBox.ItemsSource = orvoskak;
            kezeloorvosComboBox.SelectedItem = orvoskak.FirstOrDefault();

            var kezeles = from akt in Magankorhaz.Adatbazis.AdatBazis.DataBase.Kartonok
                          where (kezeloorvosComboBox.SelectedItem as Adatbazis.Orvos).Id == akt.OrvosID
                          select akt.KezelesReszletei;

           /* kezelesek = new ObservableCollection<string>(kezeles);
            szolgaltatasneveComboBox.ItemsSource = kezelesek;
            szolgaltatasneveComboBox.SelectedItem = kezelesek.FirstOrDefault();*/

        }
    }
}
