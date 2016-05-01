using Magankorhaz.FeldolgozoOsztalyok;
using Magankorhaz.ViewModellek;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Magankorhaz.UserControlok
{
    /// <summary>
    /// Interaction logic for OrvosKezelesek.xaml
    /// </summary>
    public partial class OrvosKezelesek : UserControl
    {
        OrvosKezelesekFeldolgozo KezelesFeldolgozo;
        Adatbazis.Paciens kivalasztottPaciens;
        OrvosKezelesekViewModel kivalasztottKezeles;
        public OrvosKezelesek(Adatbazis.Orvos orvos)
        {
            InitializeComponent();
            KezelesFeldolgozo = new OrvosKezelesekFeldolgozo(Adatbazis.AdatBazis.DataBase, orvos);
            paciensListBox.DataContext = KezelesFeldolgozo;
            kezelesekDataGrid.DataContext = KezelesFeldolgozo;

            kivalasztottKezeles = new OrvosKezelesekViewModel();
            kivalasztottPaciens = new Adatbazis.Paciens();

            foreach (DataGridColumn akt in kezelesekDataGrid.Columns)
            {
                akt.Width = kezelesekDataGrid.Width / 4 - 2;
            }

            kezelesmodositasaButton.IsEnabled = false;
            kezelesTorleseButton.IsEnabled = false;
        }

        private void ujkezelesButton_Click(object sender, RoutedEventArgs e)
        {
            Grid parent = (Grid)this.Parent;
            parent.Children.Clear();
            parent.Children.Add(new OrvosUjKezelesFelvetele(KezelesFeldolgozo.Orvos));
        }

        private void kezelesmodositasaButton_Click(object sender, RoutedEventArgs e)
        {
            Grid parent = (Grid)this.Parent;
            parent.Children.Clear();
            parent.Children.Add(new OrvosKezelesModositasa((OrvosKezelesekViewModel)kezelesekDataGrid.SelectedItem, KezelesFeldolgozo.Orvos));
        }

        private void kezelesTorleseButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Biztosan törli a kiválasztott kezelést?", "Törlés", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                if (KezelesFeldolgozo.KezelesTorlese(kivalasztottKezeles))
                {
                    kezelesmodositasaButton.IsEnabled = false;
                    kezelesTorleseButton.IsEnabled = false;
                }
            }  
        }

        private void kezelesekDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            kivalasztottKezeles = (OrvosKezelesekViewModel)kezelesekDataGrid.SelectedItem;
            kezelesmodositasaButton.IsEnabled = true;
            kezelesTorleseButton.IsEnabled = true;
        }
    }
}
