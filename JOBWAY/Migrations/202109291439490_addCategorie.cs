namespace JOBWAY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCategorie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Offres", "Categorie", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Offres", "Categorie");
        }
    }
}
