namespace JOBWAY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Usernname = c.String(),
                        Password = c.String(),
                        Description = c.String(),
                        Cv = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Date_creation = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Candidats");
        }
    }
}
