using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magankorhaz.ViewModellek;
using System.Collections.ObjectModel;

namespace Magankorhaz.FeldolgozoOsztalyok
{
    class OrvosKezelesekFeldolgozo
    {
        public ObservableCollection<Adatbazis.Paciens> Paciensek
        {
            private set;
            get;
        }

        public ObservableCollection<Adatbazis.Orvos> Orvosok
        {
            private set;
            get;
        }

        Adatbazis.MagankorhazDB Adatbazis
        {
            set;
            get;
        }

        public Adatbazis.Orvos Orvos
        {
            set;
            get;
        }

        public ObservableCollection<OrvosKezelesekViewModel> Kezelesek
        {
            private set;
            get;
        }

        public OrvosKezelesekFeldolgozo(Adatbazis.MagankorhazDB adatbazis, Adatbazis.Orvos orvos)
        {
            Adatbazis = adatbazis;
            Orvos = orvos;
            Kezelesek = new ObservableCollection<OrvosKezelesekViewModel>();

            OrvosokLekerdezese();
            PaciensekLekerdezese();
            KezelesekLekerdezese();
        }

        public ObservableCollection<Adatbazis.Karton> KezelesekLekerdezese()
        {
            var kezelesek = from x in Adatbazis.Kartonok
                            select x;

            Kezelesek.Clear();
            foreach (var akt in kezelesek)
            {
                Adatbazis.Paciens paciens = ElsoPaciensIdAlapjan(akt.PaciensID);
                Adatbazis.Orvos orvos = ElsoOrvosIdAlapjan(akt.OrvosID);
                Kezelesek.Add(new OrvosKezelesekViewModel()
                {
                    Id = akt.Id,
                    Paciens = paciens.Nev,
                    Orvos = orvos.Nev,
                    KezelesDatuma = akt.KezelesDatuma,
                    KezelesKoltsege = akt.KezelesKoltsege,
                    KezelesReszletei = akt.KezelesReszletei,
                    KezelesSikeressege = akt.KezelesSikeressege,
                    Receptek = akt.Receptek
                });
            }
            return new ObservableCollection<Magankorhaz.Adatbazis.Karton>(kezelesek.ToList<Adatbazis.Karton>());
        }

        public void KezelesekLekerdezese(Adatbazis.Paciens kivalasztottPaciens)
        {
            var kezelesek = from x in Adatbazis.Kartonok
                            where x.PaciensID == kivalasztottPaciens.Id
                            select x;

            Kezelesek.Clear();
            foreach (var akt in kezelesek)
            {
                Adatbazis.Paciens paciens = ElsoPaciensIdAlapjan(akt.PaciensID);
                Adatbazis.Orvos orvos = ElsoOrvosIdAlapjan(akt.OrvosID);
                Kezelesek.Add(new OrvosKezelesekViewModel()
                {
                    Id = akt.Id,
                    Paciens = paciens.Nev,
                    Orvos = orvos.Nev,
                    KezelesDatuma = akt.KezelesDatuma,
                    KezelesKoltsege = akt.KezelesKoltsege,
                    KezelesReszletei = akt.KezelesReszletei,
                    KezelesSikeressege = akt.KezelesSikeressege,
                    Receptek = akt.Receptek
                });
            }
        }




        public bool KezelesFelvetele(DateTime kezelesidopont, Adatbazis.Paciens paciens, Adatbazis.Orvos orvos, string recept, int koltseg, string kezelesreszletei, bool sikeresseg)
        {
            try
            {
                Adatbazis.Kartonok.Add(new Adatbazis.Karton() { KezelesDatuma = kezelesidopont, PaciensID = paciens.Id, OrvosID = orvos.Id, Receptek = recept, KezelesKoltsege = koltseg, KezelesReszletei = kezelesreszletei, KezelesSikeressege = sikeresseg });
                Adatbazis.SaveChanges();
                var kezeles = from x in Adatbazis.Kartonok
                              select x;
                Adatbazis.Karton felvettkarton = kezeles.ToList<Adatbazis.Karton>().Last();
                Adatbazis.Szamlak.Add(new Adatbazis.Szamla() { KartonID = felvettkarton.Id, PaciensID = felvettkarton.PaciensID, Fizetendo = felvettkarton.KezelesKoltsege, Befizetve = false, BefizetesDatuma = new DateTime() });
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool KezelesTorlese(OrvosKezelesekViewModel kivalasztottKezeles)
        {
            try
            {
                var torlendoKezeles = from x in Adatbazis.Kartonok
                                      where x.Id == kivalasztottKezeles.Id
                                      select x;
                if (torlendoKezeles.Count() > 0)
                    Adatbazis.Kartonok.Remove(torlendoKezeles.First());
                Adatbazis.SaveChanges();
                Kezelesek.Remove(kivalasztottKezeles);
                return true;
            }
            catch
            {
                return false;
            }
        }


        void OrvosokLekerdezese()
        {
            var orvosok = from x in Adatbazis.Orvosok
                          select x;
            Orvosok = new ObservableCollection<Magankorhaz.Adatbazis.Orvos>(orvosok.ToList<Adatbazis.Orvos>());
        }

        void PaciensekLekerdezese()
        {
            var paciensek = from x in Adatbazis.Paciensek
                            select x;
            Paciensek = new ObservableCollection<Adatbazis.Paciens>(paciensek.ToList<Adatbazis.Paciens>());
        }

        public Adatbazis.Paciens ElsoPaciensIdAlapjan(int id)
        {
            foreach (Adatbazis.Paciens akt in Paciensek)
            {
                if (akt.Id == id)
                {
                    return akt;
                }
            }
            return null;
        }

        public Adatbazis.Orvos ElsoOrvosIdAlapjan(int id)
        {
            foreach (Adatbazis.Orvos akt in Orvosok)
            {
                if (akt.Id == id)
                {
                    return akt;
                }
            }
            return null;
        }
    }
}
