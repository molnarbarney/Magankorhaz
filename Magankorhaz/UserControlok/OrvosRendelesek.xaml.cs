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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Magankorhaz.FeldolgozoOsztalyok;
using Magankorhaz.ViewModellek;

namespace Magankorhaz.UserControlok
{
    /// <summary>
    /// Interaction logic for OrvosRendelesek.xaml
    /// </summary>
    public partial class OrvosRendelesek : UserControl
    {
        OrvosRendelesFeldolgozo IdopontFeldolgozo;
        OrvosRendelesekViewModel kivalasztottIdopont;
        Adatbazis.Orvos Orvos;

        public OrvosRendelesek(Adatbazis.Orvos orvos)
        {
            InitializeComponent();
            Orvos = orvos;
            IdopontFeldolgozo = new OrvosRendelesFeldolgozo(Adatbazis.AdatBazis.DataBase, orvos);
            idopontokDataGrid.DataContext = IdopontFeldolgozo;
            foreach (DataGridColumn akt in idopontokDataGrid.Columns)
            {
                akt.Width = idopontokDataGrid.Width / 3 - 3;
            }
            kivalasztottIdopont = null;
        }

        private void idopontokDataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            kivalasztottIdopont = (OrvosRendelesekViewModel)idopontokDataGrid.SelectedItem;
            if (kivalasztottIdopont != null)
            {
                idopontModositasaButton.IsEnabled = true;
                idopontTorleseButton.IsEnabled = true;
            }
        }

        private void idopontTorleseButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Biztosan törli az időpontot?", "Törlés", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                bool sikerult = IdopontFeldolgozo.IdopontTorlese((OrvosRendelesekViewModel)idopontokDataGrid.SelectedItem);
                if (sikerult)
                    MessageBox.Show("Időpont sikeresen törölve!", "Törlés sikerült", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ujIdopontButton_Click(object sender, RoutedEventArgs e)
        {
            Grid parent = (Grid)this.Parent;
            parent.Children.Clear();
            parent.Children.Add(new OrvosUjIdopontFelvetele(Orvos));
        }

        private void idopontModositasaButton_Click(object sender, RoutedEventArgs e)
        {
            Grid parent = (Grid)this.Parent;
            parent.Children.Clear();
            parent.Children.Add(new OrvosIdopontModositasa((OrvosRendelesekViewModel)idopontokDataGrid.SelectedItem,Orvos));
        }
    }
}
