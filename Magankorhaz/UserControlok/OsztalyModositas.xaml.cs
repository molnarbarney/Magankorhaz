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

namespace Magankorhaz.UserControlok
{
    /// <summary>
    /// Interaction logic for OsztalyModositas.xaml
    /// </summary>
    public partial class OsztalyModositas : Window
    {
        public int osztalyId { get; set; }
        public OsztalyModositas(int id, bool mod)
        {
            InitializeComponent();
            osztalyId = id;

            if (mod)
            {
                modositButton.Visibility = Visibility.Visible;
                var oszt = from akt in Adatbazis.AdatBazis.DataBase.Osztalyok
                           where osztalyId == akt.Id
                           select akt;

                nevTextbox.Text = oszt.First().Megnevezes;
                szobaszamTextbox.Text = oszt.First().SzobakSzama.ToString();
                ferohelyTextbox.Text = oszt.First().OsszesFerohely.ToString();
            }
            else
            {
                felveszButton.Visibility = Visibility.Visible;
                nevTextbox.Text = "";
                szobaszamTextbox.Text = "";
                ferohelyTextbox.Text = "";
            }



        }



        private void modositButton_Click(object sender, RoutedEventArgs e)
        {
            if (nevTextbox.Text != "" && szobaszamTextbox.Text != "" && ferohelyTextbox.Text != "")
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(szobaszamTextbox.Text, "^[0-9]") || !System.Text.RegularExpressions.Regex.IsMatch(ferohelyTextbox.Text, "^[0-9]"))
                {
                    MessageBox.Show("A szobaszámban és férőhelyek számában csak számok szerepelhetnek!");
                }
                else
                {
                    var oszt = from akt in Adatbazis.AdatBazis.DataBase.Osztalyok
                               where osztalyId == akt.Id
                               select akt;
                    oszt.First().Megnevezes = nevTextbox.Text;
                    oszt.First().SzobakSzama = int.Parse(szobaszamTextbox.Text);
                    oszt.First().OsszesFerohely = int.Parse(ferohelyTextbox.Text);
                    Adatbazis.AdatBazis.DataBase.SaveChanges();
                    this.DialogResult = true;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Nincs minden adat kitöltve!");
            }
        }

        private void felveszButton_Click(object sender, RoutedEventArgs e)
        {
            if (nevTextbox.Text != "" && szobaszamTextbox.Text != "" && ferohelyTextbox.Text != "")
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(szobaszamTextbox.Text, "^[0-9]") || !System.Text.RegularExpressions.Regex.IsMatch(ferohelyTextbox.Text, "^[0-9]"))
                {
                    MessageBox.Show("A szobaszámban és férőhelyek számában csak számok szerepelhetnek!");
                }
                else
                {
                    var oszt = from akt in Adatbazis.AdatBazis.DataBase.Osztalyok
                               orderby akt.Id
                               select akt;
                    int utolsoId = oszt.First().Id;
                    Adatbazis.AdatBazis.DataBase.Osztalyok.Add(new Adatbazis.Osztaly
                        {
                            Id = utolsoId + 1,
                            Megnevezes = nevTextbox.Text,
                            OsszesFerohely = int.Parse(ferohelyTextbox.Text),
                            SzobakSzama = int.Parse(szobaszamTextbox.Text)
                        });
                    Adatbazis.AdatBazis.DataBase.SaveChanges();
                    this.DialogResult = true;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Nincs minden adat kitöltve!");
            }
        }



    }
}
