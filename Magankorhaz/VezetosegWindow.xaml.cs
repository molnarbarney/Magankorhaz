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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Magankorhaz
{
    /// <summary>
    /// Interaction logic for VezetosegWindow.xaml
    /// </summary>
    public partial class VezetosegWindow : Window
    {
        ViewModel vm;
        MegViewModel mvm;

        public VezetosegWindow(string felhasznalonev)
        {
            InitializeComponent();

            felhasznalo.Content = felhasznalonev;
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

        static Random rand = new Random();

        private void vezetosegWindow_Loaded(object sender, RoutedEventArgs e)
        {
            vm = new ViewModel((int)bevetelekvaszon.ActualWidth, (int)bevetelekvaszon.ActualHeight);
            mvm = new MegViewModel((int)kihasznaltsagvaszon.ActualWidth, (int)kihasznaltsagvaszon.ActualHeight);
            maiDatum.Content = DateTime.Now.ToShortDateString();

            vm.Listaelemek.Add(new Elemek(0));
            vm.MegListaelemek.Add(new Elemek(0));
            mvm.Listaelemek.Add(new MegElemek(0));
        }

        void dt_Tick(object sender, EventArgs e)
        {
            bevetelekvaszon.Children.Clear();
            foreach (Alakzat elem in vm.Alakzatok)
            {
                Rectangle rc = new Rectangle();
                rc.DataContext = elem;
                rc.SetBinding(Canvas.LeftProperty, new Binding("Alap.X"));
                rc.SetBinding(Canvas.TopProperty, new Binding("Alap.Y"));
                rc.SetBinding(Rectangle.WidthProperty, new Binding("Alap.Width"));
                rc.SetBinding(Rectangle.HeightProperty, new Binding("Alap.Height"));
                rc.Fill = Brushes.Green;
                rc.Stroke = Brushes.Black;
                bevetelekvaszon.Children.Add(rc);
            }

        }

        void dt2_Tick(object sender, EventArgs e)
        {

            kiadasokvaszon.Children.Clear();
            foreach (Alakzat elem in vm.MegAlakzatok)
            {
                Rectangle rc = new Rectangle();
                rc.DataContext = elem;
                rc.SetBinding(Canvas.LeftProperty, new Binding("Alap.X"));
                rc.SetBinding(Canvas.TopProperty, new Binding("Alap.Y"));
                rc.SetBinding(Rectangle.WidthProperty, new Binding("Alap.Width"));
                rc.SetBinding(Rectangle.HeightProperty, new Binding("Alap.Height"));
                rc.Fill = Brushes.Red;
                rc.Stroke = Brushes.Black;
                kiadasokvaszon.Children.Add(rc);
            }
        }

        void dt3_Tick(object sender, EventArgs e)
        {
            kihasznaltsagvaszon.Children.Clear();
            foreach (MegAlakzat elem in mvm.Alakzatok)
            {
                Rectangle rc = new Rectangle();
                rc.DataContext = elem;
                rc.SetBinding(Canvas.LeftProperty, new Binding("Alap.X"));
                rc.SetBinding(Canvas.TopProperty, new Binding("Alap.Y"));
                rc.SetBinding(Rectangle.WidthProperty, new Binding("Alap.Width"));
                rc.SetBinding(Rectangle.HeightProperty, new Binding("Alap.Height"));
                rc.Fill = Brushes.DarkOrchid;
                rc.Stroke = Brushes.Black;
                kihasznaltsagvaszon.Children.Add(rc);
            }

        }

        //Ha Költségvetési kimutatást készítek
        private void KoltsegvetesClick(object sender, RoutedEventArgs e)
        {
            legutolsolekerdezesdatuma.Content = DateTime.UtcNow.ToLocalTime();
            vm.Alakzatok.Clear();
            vm.MegAlakzatok.Clear();
            vm.Listaelemek.Clear();
            vm.MegListaelemek.Clear();
            if (kts1date.SelectedDate != null && kts2date.SelectedDate != null)
            {
                if (kts1date.SelectedDate.Value <= kts2date.SelectedDate.Value)
                {
                    int napokdarab = (int)kts2date.SelectedDate.Value.Subtract(kts1date.SelectedDate.Value).TotalDays + 1;
                    for (int i = 0; i < napokdarab; i++)
                    {
                        vm.Listaelemek.Add(new Elemek(rand.Next(30, 300)));
                    }
                    vm.Rajzol();
                    for (int i = 0; i < napokdarab; i++)
                    {
                        vm.MegListaelemek.Add(new Elemek(rand.Next(15, 200)));
                    }
                    vm.MegRajzol();
                }
                else
                {
                    MessageBox.Show("A kezdeti és végdátum fel lett cserélve!");
                }
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva dátum!");
            }
        }

        //Ha osztályok kihasználtságáról készítek kimutatást
        private void KihasznaltsagClick(object sender, RoutedEventArgs e)
        {
            /*
            var osztalyIDmeghatarozas = from akt in Magankorhaz.Adatbazis.AdatBazis.DataBase.Paciensek
                                group akt by akt.OsztalyID into g
                                select g.Key;
            */



            var akarmi = from paciens in Adatbazis.AdatBazis.DataBase.Paciensek
                         join osztaly in Adatbazis.AdatBazis.DataBase.Osztalyok
                         on paciens.OsztalyID equals osztaly.Id
                         group paciens by paciens.OsztalyID into g
                         orderby g.Key
                         select g;

            foreach (var item in akarmi)
            {
                Console.WriteLine(item.Key + " " + item.Count());
            }

            legutolsolekerdezesdatuma.Content = DateTime.UtcNow.ToLocalTime();
            mvm.Alakzatok.Clear();
            mvm.Listaelemek.Clear();
            if (kih1date.SelectedDate != null && kih2date.SelectedDate != null)
            {
                if (kih1date.SelectedDate.Value <= kih2date.SelectedDate.Value)
                {
                    int napokdarab = (int)kih2date.SelectedDate.Value.Subtract(kih1date.SelectedDate.Value).TotalDays + 1;
                    for (int i = 0; i < napokdarab; i++)
                    {
                        mvm.Listaelemek.Add(new MegElemek(rand.Next(0, 20)));
                    }
                    mvm.Rajzol();

                }
                else
                {
                    MessageBox.Show("A kezdeti és végdátum fel lett cserélve!");
                }
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva dátum!");
            }
        }

        //Ha betölt a költségvetési kimutatások Grid, akkor fut le
        private void koltsegvetesikimutatasokmenu_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = vm;
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 0, 0, 20);
            dt.Tick += dt_Tick;
            dt.Start();

            vm.Rajzol();

            DispatcherTimer dt2 = new DispatcherTimer();
            dt2.Interval = new TimeSpan(0, 0, 0, 0, 20);
            dt2.Tick += dt2_Tick;
            dt2.Start();

            vm.MegRajzol();


            var osztalyok = from akt in Adatbazis.AdatBazis.DataBase.Osztalyok
                            select akt;

            mvm.Osztalyok = new ObservableCollection<Adatbazis.Osztaly>(osztalyok);
            osztalyokCombobox.SelectedItem = osztalyok.FirstOrDefault();
            //osztalyokCombobox.ItemsSource = osztalyok.ToList();
            //osztalyokCombobox.SelectedItem = osztalyok.FirstOrDefault();
        }


        //Ha betölt a osztályok kihasználtságának kimutatásai Grid, akkor fut le
        private void osztalyokkihasznaltsagamenu_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = mvm;
            DispatcherTimer dt3 = new DispatcherTimer();
            dt3.Interval = new TimeSpan(0, 0, 0, 0, 20);
            dt3.Tick += dt3_Tick;
            dt3.Start();

            mvm.Rajzol();
        }
    }
}
