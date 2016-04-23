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

        public SzamlahozTetelHozzaadWindow()
        {
            InitializeComponent();

        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var orvosok = from akt in Magankorhaz.Adatbazis.AdatBazis.DataBase.Orvosok
                          select akt;

            orvoskak = new ObservableCollection<Adatbazis.Orvos>(orvosok);
            kezeloorvosComboBox.ItemsSource = orvoskak;
        }
    }
}
