using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magankorhaz;
using System.Collections.ObjectModel;
using Magankorhaz.ViewModellek;

namespace Magankorhaz.FeldolgozoOsztalyok
{
    class OrvosRendelesFeldolgozo
    {
        public ObservableCollection<OrvosRendelesekViewModel> Idopontok
        {
            private set;
            get;
        }

        public ObservableCollection<Adatbazis.Paciens> Paciensek
        {
            private set;
            get;
        }

        Adatbazis.MagankorhazDB Adatbazis
        {
            set;
            get;
        }

        public Adatbazis.Orvos AktualisOrvos
        {
            set;
            get;
        }

        public OrvosRendelesFeldolgozo(Adatbazis.MagankorhazDB adatbazis, Adatbazis.Orvos orvos)
        {
            Adatbazis = adatbazis;
            AktualisOrvos = orvos;
            var idopontok = from x in adatbazis.Idopontok
                            join o in adatbazis.Orvosok on x.OrvosID equals o.Id 
                            join p in adatbazis.Paciensek on x.PaciensID equals p.Id
                            select new { FoglaltIdopont = x.FoglaltIdopont, Orvos = o.Nev, Paciens = p.Nev, Megnevezes = x.Megnevezes};
            var tempList = idopontok.ToList();
            Idopontok = new ObservableCollection<OrvosRendelesekViewModel>();
            foreach(var akt in tempList)
            {
                Idopontok.Add(new OrvosRendelesekViewModel() { FoglaltIdopont = akt.FoglaltIdopont, Orvos = akt.Orvos, Paciens = akt.Paciens, Megnevezes = akt.Megnevezes});
            }

            var paciensek = from x in adatbazis.Paciensek
                            select x;
            Paciensek = new ObservableCollection<Adatbazis.Paciens>(paciensek.ToList<Adatbazis.Paciens>());
            
        }

        public OrvosRendelesFeldolgozo(Adatbazis.MagankorhazDB adatbazis)
        {
            Adatbazis = adatbazis;
            AktualisOrvos = ElsoOrvos();
            var idopontok = from x in adatbazis.Idopontok
                            join o in adatbazis.Orvosok on x.OrvosID equals o.Id
                            join p in adatbazis.Paciensek on x.PaciensID equals p.Id
                            select new { FoglaltIdopont = x.FoglaltIdopont, Orvos = o.Nev, Paciens = p.Nev };
            var tempList = idopontok.ToList();
            Idopontok = new ObservableCollection<OrvosRendelesekViewModel>();
            foreach (var akt in tempList)
            {
                Idopontok.Add(new OrvosRendelesekViewModel() { FoglaltIdopont = akt.FoglaltIdopont, Orvos = akt.Orvos, Paciens = akt.Paciens });
            }

            var paciensek = from x in adatbazis.Paciensek
                            select x;
            Paciensek = new ObservableCollection<Adatbazis.Paciens>(paciensek.ToList<Adatbazis.Paciens>());

        }

        public bool IdopontTorlese(OrvosRendelesekViewModel kivalasztottIdopont)
        {
            try
            {
                var torlendoIdopont = from x in Adatbazis.Idopontok
                                      where x.FoglaltIdopont == kivalasztottIdopont.FoglaltIdopont
                                      select x;
                if (torlendoIdopont.Count() > 0)
                    Adatbazis.Idopontok.Remove(torlendoIdopont.First());
                Adatbazis.SaveChanges();
                Idopontok.Remove(kivalasztottIdopont);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IdopontTorlese(DateTime foglaltIdopont)
        {
            try
            {
                var torlendoIdopont = from x in Adatbazis.Idopontok
                                      where x.FoglaltIdopont == foglaltIdopont
                                      select x;
                if (torlendoIdopont.Count() > 0)
                    Adatbazis.Idopontok.Remove(torlendoIdopont.First());
                Adatbazis.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UjIdopontFelvetele(DateTime idopont, Adatbazis.Paciens paciens, string megnevezes)
        {
            try
            {
                Adatbazis.Idopontok.Add(new Adatbazis.Idopont() { FoglaltIdopont = idopont, PaciensID = paciens.Id, OrvosID = AktualisOrvos.Id, Megnevezes = megnevezes });
                Adatbazis.SaveChanges();
            }
            catch { return false; }
            Idopontok.Add(new OrvosRendelesekViewModel() { FoglaltIdopont = idopont, Paciens = paciens.Nev, Orvos = AktualisOrvos.Nev });
            return true;
        }

        public Adatbazis.Orvos ElsoOrvos()
        {
            var orvos = from x in Adatbazis.Orvosok
                        select x;
            return orvos.ToList<Adatbazis.Orvos>().First();
        }
    }
}
