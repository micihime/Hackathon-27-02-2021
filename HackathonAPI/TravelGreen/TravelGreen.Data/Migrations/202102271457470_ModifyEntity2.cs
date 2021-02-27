namespace TravelGreen.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyEntity2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TransportFootprintValues", "TransportType_ID", "dbo.TransportTypes");
            DropIndex("dbo.TransportFootprintValues", new[] { "TransportType_ID" });
            RenameColumn(table: "dbo.TransportFootprintValues", name: "TransportType_ID", newName: "TransportTypeId");
            AlterColumn("dbo.TransportFootprintValues", "TransportTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.TransportFootprintValues", "TransportTypeId");
            AddForeignKey("dbo.TransportFootprintValues", "TransportTypeId", "dbo.TransportTypes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransportFootprintValues", "TransportTypeId", "dbo.TransportTypes");
            DropIndex("dbo.TransportFootprintValues", new[] { "TransportTypeId" });
            AlterColumn("dbo.TransportFootprintValues", "TransportTypeId", c => c.Int());
            RenameColumn(table: "dbo.TransportFootprintValues", name: "TransportTypeId", newName: "TransportType_ID");
            CreateIndex("dbo.TransportFootprintValues", "TransportType_ID");
            AddForeignKey("dbo.TransportFootprintValues", "TransportType_ID", "dbo.TransportTypes", "ID");
        }
    }
}
