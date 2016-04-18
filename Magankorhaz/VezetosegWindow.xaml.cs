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
    /// Interaction logic for VezetosegWindow.xaml
    /// </summary>
    public partial class VezetosegWindow : Window
    {
        public VezetosegWindow()
        {
            InitializeComponent();
        }

        private void kijelentkezesButton_Click(object sender, RoutedEventArgs e)
        {
            vezetosegWindow.Close();
            Application.Current.MainWindow.Visibility = Visibility.Visible;
        }
        private void vezetosegWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.MainWindow.Visibility = Visibility.Visible;
        }

        private void attekintesbutton_click(object sender, RoutedEventArgs e)
        {
            koltsegvetesikimutatasokmenu.Visibility = System.Windows.Visibility.Hidden;
            osztalyokkihasznaltsagamenu.Visibility = System.Windows.Visibility.Hidden;
            attekintesmenu.Visibility = System.Windows.Visibility.Visible;
        }

        private void ktskimutatasokbutton_click(object sender, RoutedEventArgs e)
        {
            koltsegvetesikimutatasokmenu.Visibility = System.Windows.Visibility.Visible;
            osztalyokkihasznaltsagamenu.Visibility = System.Windows.Visibility.Hidden;
            attekintesmenu.Visibility = System.Windows.Visibility.Hidden;
        }

        private void osztalyokkihasznbutton_click(object sender, RoutedEventArgs e)
        {
            koltsegvetesikimutatasokmenu.Visibility = System.Windows.Visibility.Hidden;
            osztalyokkihasznaltsagamenu.Visibility = System.Windows.Visibility.Visible;
            attekintesmenu.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
