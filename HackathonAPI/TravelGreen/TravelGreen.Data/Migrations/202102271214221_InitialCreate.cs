namespace TravelGreen.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Entries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Minutes = c.Int(nullable: false),
                        Transport_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TransportTypes", t => t.Transport_ID)
                .Index(t => t.Transport_ID);
            
            CreateTable(
                "dbo.TransportTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TransportFootprintValues",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FootprintPerKm = c.Int(nullable: false),
                        FootprintPerMin = c.Int(nullable: false),
                        TransportType_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TransportTypes", t => t.TransportType_ID)
                .Index(t => t.TransportType_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransportFootprintValues", "TransportType_ID", "dbo.TransportTypes");
            DropForeignKey("dbo.Entries", "Transport_ID", "dbo.TransportTypes");
            DropIndex("dbo.TransportFootprintValues", new[] { "TransportType_ID" });
            DropIndex("dbo.Entries", new[] { "Transport_ID" });
            DropTable("dbo.TransportFootprintValues");
            DropTable("dbo.TransportTypes");
            DropTable("dbo.Entries");
        }
    }
}
