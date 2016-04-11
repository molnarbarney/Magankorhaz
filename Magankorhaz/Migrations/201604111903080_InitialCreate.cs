namespace Magankorhaz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nev = c.String(),
                        Email = c.String(),
                        Felhasznalonev = c.String(),
                        Jelszo = c.String(),
                        LegutolsoBejelentkezes = c.DateTime(nullable: false),
                        Inaktiv = c.Boolean(nullable: false),
                        SzemelyiSzam = c.String(),
                        TAJ = c.Int(nullable: false),
                        Adoazonosito = c.Int(nullable: false),
                        Cim = c.String(),
                        Telefon = c.String(),
                        SzuletesiDatum = c.DateTime(nullable: false),
                        MunkabaAllasDatuma = c.DateTime(nullable: false),
                        OraberBrutto = c.Int(nullable: false),
                        SzabadsagNapok = c.Int(nullable: false),
                        MunkabeosztasID_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Munkabeosztas", t => t.MunkabeosztasID_Id)
                .Index(t => t.MunkabeosztasID_Id);
            
            CreateTable(
                "dbo.Munkabeosztas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Idoponts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FoglaltIdopont = c.DateTime(nullable: false),
                        Megnevezes = c.String(),
                        OrvosID_Id = c.Int(),
                        PaciensID_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orvos", t => t.OrvosID_Id)
                .ForeignKey("dbo.Paciens", t => t.PaciensID_Id)
                .Index(t => t.OrvosID_Id)
                .Index(t => t.PaciensID_Id);
            
            CreateTable(
                "dbo.Orvos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nev = c.String(),
                        Email = c.String(),
                        Felhasznalonev = c.String(),
                        Jelszo = c.String(),
                        LegutolsoBejelentkezes = c.DateTime(nullable: false),
                        Inaktiv = c.Boolean(nullable: false),
                        Kepesites = c.String(),
                        SzemelyiSzam = c.String(),
                        TAJ = c.Int(nullable: false),
                        Adoazonosito = c.Int(nullable: false),
                        Cim = c.String(),
                        Telefon = c.String(),
                        SzuletesiDatum = c.DateTime(nullable: false),
                        MunkabaAllasDatuma = c.DateTime(nullable: false),
                        OraberBrutto = c.Int(nullable: false),
                        SzabadsagNapok = c.Int(nullable: false),
                        MunkabeosztasID_Id = c.Int(),
                        OsztalyID_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Munkabeosztas", t => t.MunkabeosztasID_Id)
                .ForeignKey("dbo.Osztalies", t => t.OsztalyID_Id)
                .Index(t => t.MunkabeosztasID_Id)
                .Index(t => t.OsztalyID_Id);
            
            CreateTable(
                "dbo.Osztalies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Megnevezes = c.String(),
                        OsszesFerohely = c.Int(nullable: false),
                        SzobakSzama = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Paciens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nev = c.String(),
                        Email = c.String(),
                        Felhasznalonev = c.String(),
                        Jelszo = c.String(),
                        LegutolsoBejelentkezes = c.DateTime(nullable: false),
                        SzemelyiSzam = c.String(),
                        TAJ = c.Int(nullable: false),
                        Cim = c.String(),
                        Telefon = c.String(),
                        SzuletesiDatum = c.DateTime(nullable: false),
                        Neme = c.Boolean(nullable: false),
                        FelvetelDatuma = c.DateTime(nullable: false),
                        TavozasDatuma = c.DateTime(nullable: false),
                        OrvosID_Id = c.Int(),
                        OsztalyID_Id = c.Int(),
                        UgyvezetoID_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orvos", t => t.OrvosID_Id)
                .ForeignKey("dbo.Osztalies", t => t.OsztalyID_Id)
                .ForeignKey("dbo.Ugyvezetoes", t => t.UgyvezetoID_Id)
                .Index(t => t.OrvosID_Id)
                .Index(t => t.OsztalyID_Id)
                .Index(t => t.UgyvezetoID_Id);
            
            CreateTable(
                "dbo.Ugyvezetoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nev = c.String(),
                        Email = c.String(),
                        Felhasznalonev = c.String(),
                        Jelszo = c.String(),
                        LegutolsoBejelentkezes = c.DateTime(nullable: false),
                        Inaktiv = c.Boolean(nullable: false),
                        SzemelyiSzam = c.String(),
                        TAJ = c.Int(nullable: false),
                        Adoazonosito = c.Int(nullable: false),
                        Cim = c.String(),
                        Telefon = c.String(),
                        SzuletesiDatum = c.DateTime(nullable: false),
                        MunkabaAllasDatuma = c.DateTime(nullable: false),
                        OraberBrutto = c.Int(nullable: false),
                        SzabadsagNapok = c.Int(nullable: false),
                        MunkabeosztasID_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Munkabeosztas", t => t.MunkabeosztasID_Id)
                .Index(t => t.MunkabeosztasID_Id);
            
            CreateTable(
                "dbo.Kartons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KezelesDatuma = c.DateTime(nullable: false),
                        KezelesReszletei = c.String(),
                        KezelesSikeressege = c.Boolean(nullable: false),
                        KezelesKoltsege = c.Int(nullable: false),
                        OrvosID_Id = c.Int(),
                        PaciensID_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orvos", t => t.OrvosID_Id)
                .ForeignKey("dbo.Paciens", t => t.PaciensID_Id)
                .Index(t => t.OrvosID_Id)
                .Index(t => t.PaciensID_Id);
            
            CreateTable(
                "dbo.Recepts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Reszletek = c.String(),
                        Karton_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kartons", t => t.Karton_Id)
                .Index(t => t.Karton_Id);
            
            CreateTable(
                "dbo.Szamlas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fizetendo = c.Int(nullable: false),
                        Befizetve = c.Boolean(nullable: false),
                        BefizetesDatuma = c.DateTime(nullable: false),
                        KartonID_Id = c.Int(),
                        PaciensID_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kartons", t => t.KartonID_Id)
                .ForeignKey("dbo.Paciens", t => t.PaciensID_Id)
                .Index(t => t.KartonID_Id)
                .Index(t => t.PaciensID_Id);
            
            CreateTable(
                "dbo.VezetosegiTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nev = c.String(),
                        Email = c.String(),
                        Felhasznalonev = c.String(),
                        Jelszo = c.String(),
                        LegutolsoBejelentkezes = c.DateTime(nullable: false),
                        Statusz = c.String(),
                        Inaktiv = c.Boolean(nullable: false),
                        SzemelyiSzam = c.String(),
                        TAJ = c.Int(nullable: false),
                        Adoazonosito = c.Int(nullable: false),
                        Cim = c.String(),
                        Telefon = c.String(),
                        SzuletesiDatum = c.DateTime(nullable: false),
                        MunkabaAllasDatuma = c.DateTime(nullable: false),
                        OraberBrutto = c.Int(nullable: false),
                        SzabadsagNapok = c.Int(nullable: false),
                        MunkabeosztasID_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Munkabeosztas", t => t.MunkabeosztasID_Id)
                .Index(t => t.MunkabeosztasID_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VezetosegiTags", "MunkabeosztasID_Id", "dbo.Munkabeosztas");
            DropForeignKey("dbo.Szamlas", "PaciensID_Id", "dbo.Paciens");
            DropForeignKey("dbo.Szamlas", "KartonID_Id", "dbo.Kartons");
            DropForeignKey("dbo.Recepts", "Karton_Id", "dbo.Kartons");
            DropForeignKey("dbo.Kartons", "PaciensID_Id", "dbo.Paciens");
            DropForeignKey("dbo.Kartons", "OrvosID_Id", "dbo.Orvos");
            DropForeignKey("dbo.Idoponts", "PaciensID_Id", "dbo.Paciens");
            DropForeignKey("dbo.Paciens", "UgyvezetoID_Id", "dbo.Ugyvezetoes");
            DropForeignKey("dbo.Ugyvezetoes", "MunkabeosztasID_Id", "dbo.Munkabeosztas");
            DropForeignKey("dbo.Paciens", "OsztalyID_Id", "dbo.Osztalies");
            DropForeignKey("dbo.Paciens", "OrvosID_Id", "dbo.Orvos");
            DropForeignKey("dbo.Idoponts", "OrvosID_Id", "dbo.Orvos");
            DropForeignKey("dbo.Orvos", "OsztalyID_Id", "dbo.Osztalies");
            DropForeignKey("dbo.Orvos", "MunkabeosztasID_Id", "dbo.Munkabeosztas");
            DropForeignKey("dbo.Admins", "MunkabeosztasID_Id", "dbo.Munkabeosztas");
            DropIndex("dbo.VezetosegiTags", new[] { "MunkabeosztasID_Id" });
            DropIndex("dbo.Szamlas", new[] { "PaciensID_Id" });
            DropIndex("dbo.Szamlas", new[] { "KartonID_Id" });
            DropIndex("dbo.Recepts", new[] { "Karton_Id" });
            DropIndex("dbo.Kartons", new[] { "PaciensID_Id" });
            DropIndex("dbo.Kartons", new[] { "OrvosID_Id" });
            DropIndex("dbo.Ugyvezetoes", new[] { "MunkabeosztasID_Id" });
            DropIndex("dbo.Paciens", new[] { "UgyvezetoID_Id" });
            DropIndex("dbo.Paciens", new[] { "OsztalyID_Id" });
            DropIndex("dbo.Paciens", new[] { "OrvosID_Id" });
            DropIndex("dbo.Orvos", new[] { "OsztalyID_Id" });
            DropIndex("dbo.Orvos", new[] { "MunkabeosztasID_Id" });
            DropIndex("dbo.Idoponts", new[] { "PaciensID_Id" });
            DropIndex("dbo.Idoponts", new[] { "OrvosID_Id" });
            DropIndex("dbo.Admins", new[] { "MunkabeosztasID_Id" });
            DropTable("dbo.VezetosegiTags");
            DropTable("dbo.Szamlas");
            DropTable("dbo.Recepts");
            DropTable("dbo.Kartons");
            DropTable("dbo.Ugyvezetoes");
            DropTable("dbo.Paciens");
            DropTable("dbo.Osztalies");
            DropTable("dbo.Orvos");
            DropTable("dbo.Idoponts");
            DropTable("dbo.Munkabeosztas");
            DropTable("dbo.Admins");
        }
    }
}
