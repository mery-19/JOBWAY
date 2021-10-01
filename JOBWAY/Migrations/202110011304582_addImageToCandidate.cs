namespace JOBWAY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImageToCandidate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidats", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Candidats", "Image");
        }
    }
}
