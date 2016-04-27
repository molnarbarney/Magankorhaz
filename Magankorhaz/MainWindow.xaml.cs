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
        Magankorhaz.Adatbazis.MagankorhazDB MagankorhazDB;

        public MainWindow()
        {
            InitializeComponent();

            
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
                OrvosWindow orvosWindow = new OrvosWindow(felhasznalonev.Text);
                felhasznalonev.Clear();
                jelszo.Clear();
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

        private void mainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MagankorhazDB = new Adatbazis.MagankorhazDB();

            var q0 = from akt in Magankorhaz.Adatbazis.AdatBazis.DataBase.Osztalyok
                     select akt;

            if (q0.Count() > 0)
            {
                db_connection_status.Content = "Sikeres adatbázis csatlakozás!";
            }
            else db_connection_status.Content = "Sikertelen adatbázis csatlakozás!";
        }
    }
}
