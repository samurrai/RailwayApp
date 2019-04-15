namespace RailwayApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        CityFrom_Id = c.Guid(),
                        CityTo_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityFrom_Id)
                .ForeignKey("dbo.Cities", t => t.CityTo_Id)
                .Index(t => t.CityFrom_Id)
                .Index(t => t.CityTo_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "CityTo_Id", "dbo.Cities");
            DropForeignKey("dbo.Tickets", "CityFrom_Id", "dbo.Cities");
            DropIndex("dbo.Tickets", new[] { "CityTo_Id" });
            DropIndex("dbo.Tickets", new[] { "CityFrom_Id" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Cities");
        }
    }
}
