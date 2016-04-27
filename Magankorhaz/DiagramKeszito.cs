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
    class Elemek
    {
        int érték;

        public int Érték
        {
            get { return érték; }
            set { érték = value; }
        }

        public Elemek(int érték)
        {
            this.érték = érték;
        }

        public override string ToString()
        {
            return érték.ToString();
        }
    }
    class ViewModel : Bindable
    {
        int cw, ch;

        List<Alakzat> alakzatok;
        public List<Alakzat> Alakzatok
        {
            get { return alakzatok; }
            set { alakzatok = value; OnPropertyChanged(); }
        }

        List<Alakzat> megalakzatok;
        public List<Alakzat> MegAlakzatok
        {
            get { return megalakzatok; }
            set { megalakzatok = value; OnPropertyChanged(); }
        }

        ObservableCollection<Elemek> listaelemek;

        public ObservableCollection<Elemek> Listaelemek
        {
            get { return listaelemek; }
            set { listaelemek = value; OnPropertyChanged(); }
        }

        ObservableCollection<Elemek> meglistaelemek;

        public ObservableCollection<Elemek> MegListaelemek
        {
            get { return meglistaelemek; }
            set { meglistaelemek = value; OnPropertyChanged(); }
        }


        public ViewModel(int cw, int ch)
        {
            this.cw = cw;
            this.ch = ch;
            listaelemek = new ObservableCollection<Elemek>();
            alakzatok = new List<Alakzat>();
            meglistaelemek = new ObservableCollection<Elemek>();
            megalakzatok = new List<Alakzat>();
        }



        public void Rajzol()
        {
            int listaHossz = listaelemek.Count;
            int szelesseg = cw / listaHossz;
            for (int i = 0; i < listaHossz; i++)
            {
                Alakzatok.Add(new Alakzat(i * szelesseg, ch - Listaelemek[i].Érték, szelesseg, Listaelemek[i].Érték));
            }
        }

        public void MegRajzol()
        {
            int listaHossz = meglistaelemek.Count;
            int szelesseg = cw / listaHossz;
            for (int i = 0; i < listaHossz; i++)
            {
                MegAlakzatok.Add(new Alakzat(i * szelesseg, ch - MegListaelemek[i].Érték, szelesseg, MegListaelemek[i].Érték));
            }
        }

    }
    class Bindable : INotifyPropertyChanged
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

    class Alakzat
    {
        Rect alap;

        public Rect Alap
        {
            get { return alap; }
            set { alap = value; }
        }

        public Alakzat(int x, int y, int w, int h)
        {
            alap.X = x;
            alap.Y = y;
            alap.Width = w;
            alap.Height = h;
        }
    }
}
