using Magankorhaz.MNBService;
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
using System.Xml.Linq;

namespace Magankorhaz
{
    /// <summary>
    /// Interaction logic for ValutaValto.xaml
    /// </summary>
    public partial class ValutaValto : Window
    {
        string osszeg;
        public ValutaValto(string osszeg)
        {
            InitializeComponent();
            this.osszeg = osszeg;
            
        }

        MNBArfolyamServiceSoapClient client;
        List<Rate> rates;

        void RefreshRate()
        {
            Dispatcher.Invoke(() =>
            {
                dbGrid.ItemsSource = null;
                dbGrid.ItemsSource = rates;
            });
        }

        void ProcessInfo(string xml)
        {
            XDocument doc = XDocument.Parse(xml);
            string dateStart = doc.Element("MNBExchangeRatesQueryValues").Element("FirstDate").Value;
            string dateEnd = doc.Element("MNBExchangeRatesQueryValues").Element("LastDate").Value;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            client = new MNBArfolyamServiceSoapClient();
            string result = client.GetInfo();
            ProcessInfo(result);
            result = client.GetCurrentExchangeRates();
            ProcessRates(result);
        }

        void ProcessRates(string xml)
        {
            XDocument doc = XDocument.Parse(xml);
            string date = doc.Element("MNBCurrentExchangeRates").Element("Day").Attribute("date").Value;
            
            rates = doc.Descendants("Rate").Select(x => new Rate(date, x.Attribute("curr").Value, x.Value, osszeg)).ToList();
            RefreshRate();
            //MessageBox.Show(xml);
        }

        

        private void ProcessRatesList(Task<GetExchangeRatesResponse> request)
        {
            rates.Clear();
            XDocument doc = XDocument.Parse(request.Result.Body.GetExchangeRatesResult);
            foreach (var day in doc.Descendants("Day"))
            {
                string date = day.Attribute("date").Value;
                rates.AddRange(day.Descendants("Rate").Select(x => new Rate(date, x.Attribute("curr").Value, x.Value, osszeg)));
            }
        }
    }
}
