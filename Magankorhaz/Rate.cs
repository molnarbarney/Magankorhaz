using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magankorhaz
{
    class Rate
    {
        public DateTime Dátum { get; set; } //2016-04-19
        public string Pénznem { get; set; } //JPY
        public double Érték { get; set; } //246,7
        public double Összeg { get; set; }
        public Rate(string newdate, string newcurr, string newvalue, string newosszeg)
        {
            Dátum = DateTime.Parse(newdate);
            Pénznem = newcurr;
            Érték = double.Parse(newvalue);
            Összeg = Math.Round(double.Parse(newosszeg) / Érték, 2);
        }
    }
}
