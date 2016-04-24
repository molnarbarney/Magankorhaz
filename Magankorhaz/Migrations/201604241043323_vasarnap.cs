namespace Magankorhaz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vasarnap : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Paciens", "Szobaszam", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Paciens", "Szobaszam");
        }
    }
}
