using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Magankorhaz.Adatbazis
{
    public class MagankorhazDB : DbContext
    {
        public DbSet<Admin> Adminok { get; set; }
        public DbSet<Idopont> Idopontok { get; set; }
        public DbSet<Karton> Kartonok { get; set; }
        public DbSet<Munkabeosztas> Munkabeosztasok { get; set; }
        public DbSet<Orvos> Orvosok { get; set; }
        public DbSet<Osztaly> Osztalyok { get; set; }
        public DbSet<Paciens> Paciensek { get; set; }
        public DbSet<Recept> Receptek { get; set; }
        public DbSet<Szamla> Szamlak { get; set; }
        public DbSet<Ugyvezeto> Ugyintezok { get; set; }
        public DbSet<VezetosegiTag> VezetosegiTagok { get; set; }
        public MagankorhazDB()
            : base(@"Data Source=(localdb)\v11.0;Initial Catalog=magankorhazDB;Integrated Security=true")
        {
        }
    }

    public static class AdatBazis
    {
        public static MagankorhazDB dataBase = new MagankorhazDB();

        public static MagankorhazDB DataBase
        {
            get { return AdatBazis.dataBase; }
            set { AdatBazis.dataBase = value; }
        }

    }

}
