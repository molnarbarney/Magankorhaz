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
                        MunkabeosztasID = c.Int(nullable: false),
                        SzemelyiSzam = c.String(),
                        TAJ = c.Int(nullable: false),
                        Adoazonosito = c.Int(nullable: false),
                        Cim = c.String(),
                        Telefon = c.String(),
                        SzuletesiDatum = c.DateTime(nullable: false),
                        MunkabaAllasDatuma = c.DateTime(nullable: false),
                        OraberBrutto = c.Int(nullable: false),
                        SzabadsagNapok = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Idoponts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaciensID = c.Int(nullable: false),
                        OrvosID = c.Int(nullable: false),
                        FoglaltIdopont = c.DateTime(nullable: false),
                        Megnevezes = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kartons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaciensID = c.Int(nullable: false),
                        OrvosID = c.Int(nullable: false),
                        Receptek = c.String(),
                        KezelesDatuma = c.DateTime(nullable: false),
                        KezelesReszletei = c.String(),
                        KezelesSikeressege = c.Boolean(nullable: false),
                        KezelesKoltsege = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Munkabeosztas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Hetfo = c.Boolean(nullable: false),
                        Kedd = c.Boolean(nullable: false),
                        Szerda = c.Boolean(nullable: false),
                        Csutortok = c.Boolean(nullable: false),
                        Pentek = c.Boolean(nullable: false),
                        Szombat = c.Boolean(nullable: false),
                        Vasarnap = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        OsztalyID = c.Int(nullable: false),
                        MunkabeosztasID = c.Int(nullable: false),
                        SzemelyiSzam = c.String(),
                        TAJ = c.Int(nullable: false),
                        Adoazonosito = c.Int(nullable: false),
                        Cim = c.String(),
                        Telefon = c.String(),
                        SzuletesiDatum = c.DateTime(nullable: false),
                        MunkabaAllasDatuma = c.DateTime(nullable: false),
                        OraberBrutto = c.Int(nullable: false),
                        SzabadsagNapok = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        Neme = c.String(),
                        OrvosID = c.Int(nullable: false),
                        OsztalyID = c.Int(nullable: false),
                        UgyvezetoID = c.Int(nullable: false),
                        FelvetelDatuma = c.DateTime(nullable: false),
                        TavozasDatuma = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recepts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Reszletek = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Szamlas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaciensID = c.Int(nullable: false),
                        KartonID = c.Int(nullable: false),
                        Fizetendo = c.Int(nullable: false),
                        Befizetve = c.Boolean(nullable: false),
                        BefizetesDatuma = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        MunkabeosztasID = c.Int(nullable: false),
                        SzemelyiSzam = c.String(),
                        TAJ = c.Int(nullable: false),
                        Adoazonosito = c.Int(nullable: false),
                        Cim = c.String(),
                        Telefon = c.String(),
                        SzuletesiDatum = c.DateTime(nullable: false),
                        MunkabaAllasDatuma = c.DateTime(nullable: false),
                        OraberBrutto = c.Int(nullable: false),
                        SzabadsagNapok = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        MunkabeosztasID = c.Int(nullable: false),
                        SzemelyiSzam = c.String(),
                        TAJ = c.Int(nullable: false),
                        Adoazonosito = c.Int(nullable: false),
                        Cim = c.String(),
                        Telefon = c.String(),
                        SzuletesiDatum = c.DateTime(nullable: false),
                        MunkabaAllasDatuma = c.DateTime(nullable: false),
                        OraberBrutto = c.Int(nullable: false),
                        SzabadsagNapok = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VezetosegiTags");
            DropTable("dbo.Ugyvezetoes");
            DropTable("dbo.Szamlas");
            DropTable("dbo.Recepts");
            DropTable("dbo.Paciens");
            DropTable("dbo.Osztalies");
            DropTable("dbo.Orvos");
            DropTable("dbo.Munkabeosztas");
            DropTable("dbo.Kartons");
            DropTable("dbo.Idoponts");
            DropTable("dbo.Admins");
        }
    }
}
