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
                foreach (var akt in q0)
                {
                    db_teszt.Items.Add("ID: " + akt.Id + " Részletek: " + akt.Reszletek);
                }
                db_test_label.Content = "Sikeres csatlakozás!";
            }

            // Létrehozáshoz
            /*MagankorhazDB.Receptek.Add(new Adatbazis.Recept
            {
                Reszletek = "teszt"
            });

            MagankorhazDB.SaveChanges();*/
        }
    }
}
