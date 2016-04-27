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
using Magankorhaz.Adatbazis;

namespace Magankorhaz.UserControlok
{
    /// <summary>
    /// Interaction logic for OrvosSajatAdatok.xaml
    /// </summary>
    public partial class OrvosSajatAdatok : UserControl
    {
        public OrvosSajatAdatok(Orvos orvos)
        {
            InitializeComponent();
            SajatAdatokKiirasa(orvos);
        }

        void SajatAdatokKiirasa(Magankorhaz.Adatbazis.Orvos orvos)
        {
            cimLabel.Content = orvos.Cim;
            emailLabel.Content = orvos.Email;
            kepesitesLabel.Content = orvos.Kepesites;
            nevLabel.Content = orvos.Nev;
            osztalyLabel.Content = orvos.OsztalyID;
            telefonLabel.Content = orvos.Telefon;
        }
    }
}
