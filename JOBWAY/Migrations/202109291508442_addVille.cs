namespace JOBWAY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addVille : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Offres", "Ville", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Offres", "Ville");
        }
    }
}
