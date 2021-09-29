namespace JOBWAY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class offreUpdate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Offres", "DateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Offres", "IsTaken", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Offres", "IsTaken");
            DropColumn("dbo.Offres", "DateTime");
        }
    }
}
