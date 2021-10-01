namespace JOBWAY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAttributeToCandidat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidats", "Poste", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidats", "Poste");
        }
    }
}
