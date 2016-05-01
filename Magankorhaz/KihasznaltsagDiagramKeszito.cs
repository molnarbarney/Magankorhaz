using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Magankorhaz
{
    class MegElemek
    {
        int érték;

        public int Érték
        {
            get { return érték; }
            set { érték = value; }
        }

        public MegElemek(int érték)
        {
            this.érték = érték;
        }

        public override string ToString()
        {
            return érték.ToString();
        }
    }
    class MegViewModel : MegBindable
    {
        int cw, ch;

        List<MegAlakzat> alakzatok;
        public List<MegAlakzat> Alakzatok
        {
            get { return alakzatok; }
            set { alakzatok = value; OnPropertyChanged(); }
        }

        ObservableCollection<MegElemek> listaelemek;

        public ObservableCollection<MegElemek> Listaelemek
        {
            get { return listaelemek; }
            set { listaelemek = value; OnPropertyChanged(); }
        }

        ObservableCollection<Adatbazis.Osztaly> osztalyok;

        public ObservableCollection<Adatbazis.Osztaly> Osztalyok
        {
            get { return osztalyok; }
            set { osztalyok = value; }
        }
        
        public MegViewModel(int cw, int ch)
        {
            this.cw = cw;
            this.ch = ch;
            listaelemek = new ObservableCollection<MegElemek>();
            alakzatok = new List<MegAlakzat>();
            osztalyok = new ObservableCollection<Adatbazis.Osztaly>();
        }

        public void Rajzol()
        {
            int listaHossz = listaelemek.Count;
            int szelesseg = cw / listaHossz;
            for (int i = 0; i < listaHossz; i++)
            {
                Alakzatok.Add(new MegAlakzat(i * szelesseg, ch - Listaelemek[i].Érték, szelesseg, Listaelemek[i].Érték + 15));
            }
        }
    }
    class MegBindable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string s = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(s));
            }
        }
    }

    class MegAlakzat : Bindable
    {
        Rect alap;

        public Rect Alap
        {
            get { return alap; }
            set { alap = value; }
        }

        public MegAlakzat(int x, int y, int w, int h)
        {
            alap.X = x;
            alap.Y = y;
            alap.Width = w;
            alap.Height = h;
        }
    }
}
