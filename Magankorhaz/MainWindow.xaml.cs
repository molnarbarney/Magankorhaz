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

namespace Magankorhaz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Magankorhaz.Adatbazis.MagankorhazDB MagankorhazDB = new Adatbazis.MagankorhazDB();

        public MainWindow()
        {
            InitializeComponent();

            /*var q0 = from akt in MagankorhazDB.Osztalyok
                     select akt;

            if (q0.Count() > 0)
            {
                db_connection_status.Content="Sikeres adatbázis csatlakozás!";
            }
            else db_connection_status.Content = "Sikertelen adatbázis csatlakozás!";*/
        }

        private void login_button_Click(object sender, RoutedEventArgs e)
        {
            if (felhasznalonev.Text == "admin" && jelszo.Password == "admin")
            {
                mainWindow.Hide();
                felhasznalonev.Clear();
                jelszo.Clear();
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
            }
            else if (felhasznalonev.Text == "orvos" && jelszo.Password == "orvos")
            {
                mainWindow.Hide();
                felhasznalonev.Clear();
                jelszo.Clear();
                OrvosWindow orvosWindow = new OrvosWindow();
                orvosWindow.Show();
            }
            else if (felhasznalonev.Text == "paciens" && jelszo.Password == "paciens")
            {
                mainWindow.Hide();
                felhasznalonev.Clear();
                jelszo.Clear();
                PaciensWindow paciensWindow = new PaciensWindow();
                paciensWindow.Show();
            }
            else if (felhasznalonev.Text == "ugyintezo" && jelszo.Password == "ugyintezo")
            {
                mainWindow.Hide();
                felhasznalonev.Clear();
                jelszo.Clear();
                UgyintezoWindow ugyintezoWindow = new UgyintezoWindow();
                ugyintezoWindow.Show();
            }
            else if (felhasznalonev.Text == "vezetoseg" && jelszo.Password == "vezetoseg")
            {
                mainWindow.Hide();
                felhasznalonev.Clear();
                jelszo.Clear();
                VezetosegWindow vezetosegWindow = new VezetosegWindow();
                vezetosegWindow.Show();
            }
            else MessageBox.Show("Sikertelen login!");
        }
    }
}
