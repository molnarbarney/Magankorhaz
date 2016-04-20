namespace Magankorhaz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recepts", "Karton_Id", "dbo.Kartons");
            DropIndex("dbo.Recepts", new[] { "Karton_Id" });
            AddColumn("dbo.Munkabeosztas", "Hetfo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Munkabeosztas", "Kedd", c => c.Boolean(nullable: false));
            AddColumn("dbo.Munkabeosztas", "Szerda", c => c.Boolean(nullable: false));
            AddColumn("dbo.Munkabeosztas", "Csutortok", c => c.Boolean(nullable: false));
            AddColumn("dbo.Munkabeosztas", "Pentek", c => c.Boolean(nullable: false));
            AddColumn("dbo.Munkabeosztas", "Szombat", c => c.Boolean(nullable: false));
            AddColumn("dbo.Munkabeosztas", "Vasarnap", c => c.Boolean(nullable: false));
            AddColumn("dbo.Kartons", "Receptek", c => c.String());
            DropColumn("dbo.Recepts", "Karton_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recepts", "Karton_Id", c => c.Int());
            DropColumn("dbo.Kartons", "Receptek");
            DropColumn("dbo.Munkabeosztas", "Vasarnap");
            DropColumn("dbo.Munkabeosztas", "Szombat");
            DropColumn("dbo.Munkabeosztas", "Pentek");
            DropColumn("dbo.Munkabeosztas", "Csutortok");
            DropColumn("dbo.Munkabeosztas", "Szerda");
            DropColumn("dbo.Munkabeosztas", "Kedd");
            DropColumn("dbo.Munkabeosztas", "Hetfo");
            CreateIndex("dbo.Recepts", "Karton_Id");
            AddForeignKey("dbo.Recepts", "Karton_Id", "dbo.Kartons", "Id");
        }
    }
}
