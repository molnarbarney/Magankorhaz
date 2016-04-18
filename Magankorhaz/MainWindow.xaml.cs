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

            var q0 = from akt in MagankorhazDB.Receptek
                     select akt;

            if (q0.Count() > 0)
            {
                db_connection_status.Content="Sikeres adatbázis csatlakozás!";
            }

            // Létrehozáshoz
            /*MagankorhazDB.Receptek.Add(new Adatbazis.Recept
            {
                Reszletek = "teszt"
            });

            MagankorhazDB.SaveChanges();*/
        }

        private void login_button_Click(object sender, RoutedEventArgs e)
        {
            if (username.Text == "admin" && password.Password == "admin")
            {
                mainWindow.Hide();
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.ShowDialog();
            }
            else if (username.Text == "orvos" && password.Password == "orvos")
            {
                mainWindow.Hide();
                OrvosWindow orvosWindow = new OrvosWindow();
                orvosWindow.ShowDialog();
            }
            else if (username.Text == "paciens" && password.Password == "paciens")
            {
                mainWindow.Hide();
                PaciensWindow paciensWindow = new PaciensWindow();
                paciensWindow.ShowDialog();
            }
            else if (username.Text == "ugyintezo" && password.Password == "ugyintezo")
            {
                mainWindow.Hide();
                UgyintezoWindow ugyintezoWindow = new UgyintezoWindow();
                ugyintezoWindow.ShowDialog();
            }
            else if (username.Text == "vezetoseg" && password.Password == "vezetoseg")
            {
                mainWindow.Hide();
                VezetosegWindow vezetosegWindow = new VezetosegWindow();
                vezetosegWindow.ShowDialog();
            }
            else MessageBox.Show("Sikertelen login!");
        }
    }
}
