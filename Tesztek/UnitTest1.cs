using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Magankorhaz;
using Magankorhaz.FeldolgozoOsztalyok;
using Magankorhaz.Adatbazis;
using System.Data.Entity;
using System.Linq;

namespace Tesztek
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Bejelentkezes()
        {
            // Adatbázis
            Magankorhaz.Adatbazis.MagankorhazDB MagankorhazDB = new MagankorhazDB();

            // Beléptetés ellenőrzés:

            // Arrange
            Magankorhaz.FeldolgozoOsztalyok.Beleptetes beleptetes = new Magankorhaz.FeldolgozoOsztalyok.Beleptetes();

            // Act
            string[] adatok = beleptetes.BeleptetesEllenorzes("admin", "1234");

            // Assert
            Assert.AreEqual("admin", adatok[0]);
            Assert.AreEqual("Ferenci Béla", adatok[1]);
        }

        [TestMethod]
        public void UjPaciensFelvetelEsTorles()
        {
            // Adatbázis
            Magankorhaz.Adatbazis.MagankorhazDB MagankorhazDB = new MagankorhazDB();

            // =====================================================================================================================
            // =====================================================================================================================
            // =====================================================================================================================

            // Új páviens felvétele ellenőrzés:

            // Arrange
            Magankorhaz.FeldolgozoOsztalyok.UjPacinesFelvetelFeldolgozo ujPaciens = new Magankorhaz.FeldolgozoOsztalyok.UjPacinesFelvetelFeldolgozo();

            // Act
            bool sikeresPaciensFelvetel = ujPaciens.ujPaciensFelvetele(
                "Teszt Elek",
                "teszt.elek@gmail.com",
                "tesz.elek",
                "111111111111",
                "11111",
                "11111111",
                "Nincs cím",
                "+00000000000",
                Convert.ToDateTime("2016. 04. 08. 0:00:00"),
                "Férfi",
                Convert.ToDateTime("2016. 04. 08. 0:00:00"),
                "Dr. Szigeti Dóra",
                "Általános Belgyógyászati Osztály",
                "Kiss Éva",
                MagankorhazDB);

            // Assert
            Assert.AreEqual(true, sikeresPaciensFelvetel);

            // Törlés:
            int torles = 0;

            if (sikeresPaciensFelvetel)
            {
                var paciensek = from akt in MagankorhazDB.Paciensek
                                where akt.Nev == "Teszt Elek"
                                select akt;

                foreach (var paciens in paciensek)
                {
                    MagankorhazDB.Paciensek.Remove(paciens);
                }

                torles = MagankorhazDB.SaveChanges();
            }

            // Assert
            Assert.AreEqual(1, torles);
        }

        [TestMethod]
        public void UjIdopontFelvetelEsTorles()
        {
            // Adatbázis
            Magankorhaz.Adatbazis.MagankorhazDB MagankorhazDB = new MagankorhazDB();

            // =====================================================================================================================
            // =====================================================================================================================
            // =====================================================================================================================

            // Új páviens felvétele ellenőrzés:

            // Arrange
            Magankorhaz.FeldolgozoOsztalyok.RendelesiIdopontFeldolgozo ujIdopont = new Magankorhaz.FeldolgozoOsztalyok.RendelesiIdopontFeldolgozo();

            // Act
            // Megjegyzés: Kiss Árpád-ot ne töröljük mert ő a 4-es ID!!!
            int sikeres = ujIdopont.UjIdopont("2050. 10. 10  0:00:00", "10", "00", "teszt", 4);

            // Assert
            Assert.AreEqual(1, sikeres);

            // Törlés:
            int torles = ujIdopont.IdopontTorlese(Convert.ToDateTime("2050. 10. 10. 10:00:00"), "teszt");

            // Assert
            Assert.AreEqual(1, torles);
        }
    }
}
