using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magankorhaz
{
    class Rate
    {
        public DateTime Date { get; set; } //2016-04-19
        public string Curr { get; set; } //JPY
        public double Value { get; set; } //246,7
        public double Osszeg { get; set; }
        public Rate(string newdate, string newcurr, string newvalue, string newosszeg)
        {
            Date = DateTime.Parse(newdate);
            Curr = newcurr;
            Value = double.Parse(newvalue);
            Osszeg = Math.Round(double.Parse(newosszeg) / Value, 2);
        }
    }
}
