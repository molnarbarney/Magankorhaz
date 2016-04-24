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
using System.Windows.Threading;

namespace Magankorhaz
{
    /// <summary>
    /// Interaction logic for VezetosegWindow.xaml
    /// </summary>
    public partial class VezetosegWindow : Window
    {
        ViewModel vm;
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

        static Random rand = new Random();

        private void vezetosegWindow_Loaded(object sender, RoutedEventArgs e)
        {
            maiDatum.Content = DateTime.Now.ToShortDateString();
            vm = new ViewModel((int)bevetelekvaszon.ActualWidth, (int)bevetelekvaszon.ActualHeight);

            vm.Listaelemek.Add(new Elemek(0));
            vm.MegListaelemek.Add(new Elemek(0));

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
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }
        
        private void KoltsegvetesClick(object sender, RoutedEventArgs e)
        {
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
    }
}
