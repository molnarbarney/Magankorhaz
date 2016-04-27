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
    /// Interaction logic for PaciensWindow.xaml
    /// </summary>
    public partial class PaciensWindow : Window
    {
        public PaciensWindow(string felhasznalonev)
        {
            InitializeComponent();

            felhasznalo.Content = felhasznalonev;
        }

        private void kijelentkezesButton_Click(object sender, RoutedEventArgs e)
        {
            paciensWindow.Close();
            Application.Current.MainWindow.Visibility = Visibility.Visible;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.MainWindow.Visibility = Visibility.Visible;
        }
    }
}
