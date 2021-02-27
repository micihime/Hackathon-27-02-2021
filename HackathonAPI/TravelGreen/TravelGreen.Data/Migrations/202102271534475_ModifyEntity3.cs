namespace TravelGreen.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyEntity3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Entries", "TransportTypeId", "dbo.TransportTypes");
            DropForeignKey("dbo.TransportFootprintValues", "TransportTypeId", "dbo.TransportTypes");
            DropIndex("dbo.Entries", new[] { "TransportTypeId" });
            DropIndex("dbo.TransportFootprintValues", new[] { "TransportTypeId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.TransportFootprintValues", "TransportTypeId");
            CreateIndex("dbo.Entries", "TransportTypeId");
            AddForeignKey("dbo.TransportFootprintValues", "TransportTypeId", "dbo.TransportTypes", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Entries", "TransportTypeId", "dbo.TransportTypes", "ID", cascadeDelete: true);
        }
    }
}
