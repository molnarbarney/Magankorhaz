using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magankorhaz.ViewModellek
{
    public class OrvosKezelesekViewModel
    {
        public int Id
        {
            set;
            get;
        }
        public string Paciens
        {
            set;
            get;
        }

        public string Orvos
        {
            set;
            get;
        }

        public string Receptek
        {
            set;
            get;
        }

        public DateTime KezelesDatuma
        {
            set;
            get;
        }

        public string KezelesReszletei
        {
            set;
            get;
        }

        public bool KezelesSikeressege
        {
            set;
            get;
        }

        public int KezelesKoltsege
        {
            set;
            get;
        }

        public override string ToString()
        {
            return KezelesDatuma.ToShortDateString()+" "+Paciens;
        }
    }
}
