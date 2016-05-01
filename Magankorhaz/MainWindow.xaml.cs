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
            Magankorhaz.FeldolgozoOsztalyok.Beleptetes beleptetes = new FeldolgozoOsztalyok.Beleptetes();
            string[] adatok = beleptetes.BeleptetesEllenorzes(felhasznalonev.Text, jelszo.Password);

            if (adatok[0] == "admin")
            {
                mainWindow.Hide();
                felhasznalonev.Clear();
                jelszo.Clear();
                AdminWindow adminWindow = new AdminWindow(adatok[1]);
                adminWindow.Show();
            }
            else if (adatok[0] == "orvos")
            {
                mainWindow.Hide();
                felhasznalonev.Clear();
                jelszo.Clear();
                OrvosWindow orvosWindow = new OrvosWindow(adatok[1]);
                orvosWindow.Show();
            }
            else if (adatok[0] == "paciens")
            {
                mainWindow.Hide();
                felhasznalonev.Clear();
                jelszo.Clear();
                PaciensWindow paciensWindow = new PaciensWindow(adatok[1]);
                paciensWindow.Show();
            }
            else if (adatok[0] == "ugyintezo")
            {
                mainWindow.Hide();
                felhasznalonev.Clear();
                jelszo.Clear();
                UgyintezoWindow ugyintezoWindow = new UgyintezoWindow(adatok[1]);
                ugyintezoWindow.Show();
            }
            else if (adatok[0] == "vezetoseg")
            {
                mainWindow.Hide();
                felhasznalonev.Clear();
                jelszo.Clear();
                VezetosegWindow vezetosegWindow = new VezetosegWindow(adatok[1]);
                vezetosegWindow.Show();
            }
            else MessageBox.Show(adatok[0]);
        }

        private void mainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            bool sikeresAdatbazisCsatlakozas = adatbazisCsatlakozas();
            if (sikeresAdatbazisCsatlakozas)
            {
                db_connection_status.Content = "Sikeres adatbázis csatlakozás!";
            }
            else db_connection_status.Content = "Sikertelen adatbázis csatlakozás!";
        }

        public bool adatbazisCsatlakozas()
        {
            MagankorhazDB = new Adatbazis.MagankorhazDB();

            var q0 = from akt in Magankorhaz.Adatbazis.AdatBazis.DataBase.Osztalyok
                     select akt;

            if (q0.Count() > 0)
            {
                return true;
            }
            else return false;
        }
    }
}
