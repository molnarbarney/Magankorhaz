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

        public ObservableCollection<Adatbazis.Orvos> Orvosok
        {
            set;
            get;
        }

        public ObservableCollection<Adatbazis.Osztaly> Osztalyok;

        public OrvosRendelesFeldolgozo(Adatbazis.MagankorhazDB adatbazis, Adatbazis.Orvos orvos)
        {
            Adatbazis = adatbazis;
            AktualisOrvos = orvos;

            IdopontLekeres();

            var paciensek = from x in adatbazis.Paciensek
                            select x;
            Paciensek = new ObservableCollection<Adatbazis.Paciens>(paciensek.ToList<Adatbazis.Paciens>());

            var osztalyok = from x in adatbazis.Osztalyok
                            select x;
            Osztalyok = new ObservableCollection<Magankorhaz.Adatbazis.Osztaly>(osztalyok.ToList<Magankorhaz.Adatbazis.Osztaly>());

            var orvosok = from x in adatbazis.Orvosok
                          select x;
            Orvosok = new ObservableCollection<Adatbazis.Orvos>(orvosok.ToList<Magankorhaz.Adatbazis.Orvos>());
        }

        public OrvosRendelesFeldolgozo(Adatbazis.MagankorhazDB adatbazis)
        {
            Adatbazis = adatbazis;
            AktualisOrvos = ElsoOrvos();
            IdopontLekeres();
            

            var paciensek = from x in adatbazis.Paciensek
                            select x;
            Paciensek = new ObservableCollection<Adatbazis.Paciens>(paciensek.ToList<Adatbazis.Paciens>());

            var osztalyok = from x in adatbazis.Osztalyok
                            select x;
            Osztalyok = new ObservableCollection<Magankorhaz.Adatbazis.Osztaly>(osztalyok.ToList<Magankorhaz.Adatbazis.Osztaly>());

            var orvosok = from x in adatbazis.Orvosok
                          select x;
            Orvosok = new ObservableCollection<Adatbazis.Orvos>(orvosok.ToList<Magankorhaz.Adatbazis.Orvos>());

            
        }

        public void IdopontLekeres()
        {
            var idopontok = from x in Adatbazis.Idopontok
                            join o in Adatbazis.Orvosok on x.OrvosID equals o.Id
                            join p in Adatbazis.Paciensek on x.PaciensID equals p.Id
                            orderby x.FoglaltIdopont
                            select new { FoglaltIdopont = x.FoglaltIdopont, Orvos = o.Nev, Paciens = p.Nev, Megnevezes = x.Megnevezes };
            var tempList = idopontok.ToList();
            Idopontok = new ObservableCollection<OrvosRendelesekViewModel>();
            foreach (var akt in tempList)
            {
                if(akt.FoglaltIdopont > DateTime.Now)
                    Idopontok.Add(new OrvosRendelesekViewModel() { FoglaltIdopont = akt.FoglaltIdopont, Orvos = akt.Orvos, Paciens = akt.Paciens, Megnevezes = akt.Megnevezes });
            }
        }

        public ObservableCollection<OrvosRendelesekViewModel> IdopontLekeres(Adatbazis.Orvos orvos)
        {
            var idopontok = from x in Adatbazis.Idopontok
                            join o in Adatbazis.Orvosok on x.OrvosID equals o.Id
                            join p in Adatbazis.Paciensek on x.PaciensID equals p.Id
                            orderby x.FoglaltIdopont
                            select new { FoglaltIdopont = x.FoglaltIdopont, Orvos = o.Nev, Paciens = p.Nev, Megnevezes = x.Megnevezes };
            var tempList = idopontok.ToList();
            ObservableCollection<OrvosRendelesekViewModel> szurtLekerdezes = new ObservableCollection<OrvosRendelesekViewModel>();
            foreach (var akt in tempList)
            {
                if (akt.FoglaltIdopont > DateTime.Now && akt.Orvos == orvos.Nev)
                    szurtLekerdezes.Add(new OrvosRendelesekViewModel() { FoglaltIdopont = akt.FoglaltIdopont, Orvos = akt.Orvos, Paciens = akt.Paciens, Megnevezes = akt.Megnevezes });
            }
            return szurtLekerdezes;
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


        public bool UjIdopontFelvetele(DateTime idopont,Adatbazis.Orvos orvos, Adatbazis.Paciens paciens, string megnevezes)
        {
            ObservableCollection<OrvosRendelesekViewModel> foglaltIdopontok = IdopontLekeres(orvos);
            foreach (OrvosRendelesekViewModel akt in foglaltIdopontok)
            {
                if (akt.FoglaltIdopont == idopont && akt.Orvos == orvos.Nev)
                {
                    return false;
                }
            }
            try
            {
                Adatbazis.Idopontok.Add(new Adatbazis.Idopont() { FoglaltIdopont = idopont, PaciensID = paciens.Id, OrvosID = orvos.Id, Megnevezes = megnevezes });
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

        public string OsztalyMegnevezesIdAlapjan(int id)
        {
            var osztaly = from x in Adatbazis.Osztalyok
                          where x.Id == id
                          select x.Megnevezes;

            return osztaly.ToList<string>().First().ToString();
        }

        public Adatbazis.Orvos ElsoOrvosFelhasznalonevAlapjan(string felhasznalonev)
        {
            var orvos = from x in Adatbazis.Orvosok
                        where x.Nev == felhasznalonev
                        select x;
            if (AktualisOrvos.Felhasznalonev == "")
                AktualisOrvos = orvos.ToList<Adatbazis.Orvos>().First();
            return orvos.ToList<Adatbazis.Orvos>().First();
        }
        public Adatbazis.Paciens ElsoPaciensNevAlapjan(string nev)
        {
            var paciens = from x in Adatbazis.Paciensek
                          where x.Nev == nev
                          select x;
            return paciens.ToList<Adatbazis.Paciens>().First();
        }
    }
}
