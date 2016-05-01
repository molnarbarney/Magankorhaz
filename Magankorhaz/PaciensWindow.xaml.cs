using System;
using System.Collections.Generic;
using System.Data;
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
        Magankorhaz.FeldolgozoOsztalyok.RendelesiIdopontFeldolgozo idopontFeldolgozo = new FeldolgozoOsztalyok.RendelesiIdopontFeldolgozo();
        FeldolgozoOsztalyok.UgyintezoAttekintesFeldolgozo ugyintezoAttekintesFeldolgozo = new FeldolgozoOsztalyok.UgyintezoAttekintesFeldolgozo();
        FeldolgozoOsztalyok.PaciensAdatlapFeldolgozo paciensAdatlapFeldolgozo;
        public int paciensID { get; set; }
        public string paciensEmail { get; set; }
        public string aktNev;

        public PaciensWindow(string felhasznalonev)
        {
            InitializeComponent();

            aktNev = felhasznalonev;
            felhasznalo.Content = felhasznalonev;
            PaciensKereses(aktNev);

            AlapHelyzet(paciensEmail);
           
        }

        private void PaciensKereses(string fhnev)
        {
            var aktPaciens = from akt in Adatbazis.AdatBazis.DataBase.Paciensek
                             where akt.Nev == fhnev
                             select akt;
            paciensID = aktPaciens.First().Id;
            paciensEmail = aktPaciens.First().Email;
        }

        private void AlapHelyzet(string paciensEmail)
        {

            kezelesVaszon.Visibility = Visibility.Hidden;
            paciensMegtekinteseGrid.Visibility = Visibility.Visible;

            paciensAdatlapFeldolgozo = new FeldolgozoOsztalyok.PaciensAdatlapFeldolgozo(paciensEmail);

            Adatbazis.Paciens paciensAdatok = paciensAdatlapFeldolgozo.paciensAdatok;

            this.paciensID = paciensAdatok.Id;

            paciensAdatNev.Text = paciensAdatok.Nev;
            paciensAdatEmail.Text = paciensAdatok.Email;
            paciensAdatFelhasznalonev.Text = paciensAdatok.Felhasznalonev;
            paciensAdatJelszo.Password = paciensAdatok.Jelszo;
            paciensAdatSzemelyiSzam.Text = paciensAdatok.SzemelyiSzam;
            paciensAdatTAJ.Text = Convert.ToString(paciensAdatok.TAJ);

            paciensAdatSzuletesiDatum.SelectedDate = paciensAdatok.SzuletesiDatum;

            paciensAdatLakcim.Text = paciensAdatok.Cim;
            paciensAdatTelefonszam.Text = paciensAdatok.Telefon;
            paciensAdatNeme.Text = paciensAdatok.Neme;

            if (paciensAdatok.LegutolsoBejelentkezes < DateTime.Now.AddYears(-100))
            {
                paciensAdatUtolsoBejelentkezes.Text = "";
            }
            else paciensAdatUtolsoBejelentkezes.Text = Convert.ToString(paciensAdatok.LegutolsoBejelentkezes);

            paciensAdatFelvetel.Text = paciensAdatok.FelvetelDatuma.ToString("yyyy. MM. dd.");

            if (paciensAdatok.TavozasDatuma < DateTime.Now.AddYears(-100))
            {
                paciensAdatTavozasDatum.Visibility = Visibility.Hidden;
            }
            else
            {
                paciensAdatTavozasDatum.IsEnabled = false;
                paciensAdatTavozasDatum.SelectedDate = paciensAdatok.TavozasDatuma;
            }

            paciensAdatOrvos.Text = paciensAdatlapFeldolgozo.orvosNev;
            paciensAdatUgyvezeto.Text = paciensAdatlapFeldolgozo.ugyintezoNev;

            List<Adatbazis.Osztaly> osztalyok = paciensAdatlapFeldolgozo.osszesOsztaly;
            foreach (var osztaly in osztalyok)
            {
                paciensAdatOsztalyComboBox.Items.Add(osztaly.Megnevezes);
            }

            paciensAdatOsztalyText.Content = paciensAdatlapFeldolgozo.paciensOsztaly;

            for (int i = 1; i <= 20; i++)
            {
                paciensAdatSzobaComboBox.Items.Add(i);
            }

            if (paciensAdatok.Szobaszam == 0)
            {
                paciensAdatSzobaText.Content = "Nincs elhelyezve";
            }
            else paciensAdatSzobaText.Content = Convert.ToString(paciensAdatok.Szobaszam);

            IdopontokFrissitese();            
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


        private void paciensAdatUjIdopontGomb_Click(object sender, RoutedEventArgs e)
        {
            UserControlok.UgyintezoIdopontFelvetel ujIdopont = new UserControlok.UgyintezoIdopontFelvetel();
            ujIdopont.paciensID = this.paciensID;
            ujIdopont.ShowDialog();
        }

        private void IdopontokRefreshGomb_Click(object sender, RoutedEventArgs e)
        {
            IdopontokFrissitese();
        }

        private void attekintesMenuGomb_Click(object sender, RoutedEventArgs e)
        {
            AlapHelyzet(paciensEmail);
        }

        private void kezeleseimMenuGomb_Click(object sender, RoutedEventArgs e)
        {
            paciensMegtekinteseGrid.Visibility = Visibility.Hidden;
            kezelesVaszon.Visibility = Visibility.Visible;
            igDate.SelectedDate = DateTime.Today;
            tolDate.SelectedDate = DateTime.Today.AddYears(-1);
        }


        private void paciensIdpontokListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
       
        private void IdopontokFrissitese()
        {
            List<object> idopontok = idopontFeldolgozo.RendelesiIdopontokLekerdezese(this.paciensID);
            if (idopontok != null)
            {
                paciensIdpontokListView.ItemsSource = null;
                paciensIdpontokListView.ItemsSource = idopontok.ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            kezelesLista.Visibility = Visibility.Visible;
            kezelesReszletek.Visibility = Visibility.Hidden;
            kezelesLista.Items.Clear();
            var kezeles = from akt in Adatbazis.AdatBazis.DataBase.Kartonok
                          where akt.PaciensID == paciensID && akt.KezelesDatuma >= tolDate.SelectedDate.Value && akt.KezelesDatuma <= igDate.SelectedDate.Value
                          join szamla in Adatbazis.AdatBazis.DataBase.Szamlak on akt.Id equals szamla.KartonID
                          join orvos in Adatbazis.AdatBazis.DataBase.Orvosok on akt.OrvosID equals orvos.Id
                          orderby akt.KezelesDatuma                         
                          select new { Id = akt.Id, Ido = akt.KezelesDatuma, Orv = orvos.Nev, Szolg = akt.KezelesReszletei, Ar = akt.KezelesKoltsege, Fiz = szamla.Befizetve };
            int osszeg = 0;
            int fizetve = 0;
            int tartozik = 0;
            foreach (var ujsor in kezeles)
            {
                kezelesLista.Items.Add(new Adatsor() { id = ujsor.Id, idopont = ujsor.Ido.ToString(), orvos = ujsor.Orv.ToString(), szolg = ujsor.Szolg, ar = ujsor.Ar.ToString() });
                if (ujsor.Fiz)
                {
                    fizetve += ujsor.Ar;
                }
                else
                {
                    tartozik += ujsor.Ar;
                }
                osszeg += ujsor.Ar;
            }

            osszesKoltseg.Content = new TextBlock() { Text = "A kezelések összköltsége " + osszeg + " Ft, befizetve " + fizetve + " Ft, tartozás " + tartozik + " Ft.", TextWrapping = TextWrapping.Wrap };
            kezelesReszletek.Visibility = Visibility.Hidden;
            
        }

        //kezeléslista feltöltéséhez
        public class Adatsor
        {
            public int id { get; set; }
            public string idopont { get; set; }
            public string orvos { get; set; }
            public string szolg { get; set; }
            public string ar { get; set; }
        }

        private void kezelesLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            kezelesReszletek.Visibility = Visibility.Visible;
        }

        private void kezelesReszletek_Click(object sender, RoutedEventArgs e)
        {
            Adatsor kezelesId = (Adatsor)kezelesLista.SelectedItems[0];
            UserControlok.KezelesReszletei kezelesReszletek = new UserControlok.KezelesReszletei(kezelesId.id);           
            kezelesReszletek.ShowDialog();           
        }
    }
}
