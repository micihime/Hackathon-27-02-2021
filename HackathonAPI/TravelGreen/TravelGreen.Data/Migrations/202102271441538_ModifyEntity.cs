namespace TravelGreen.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyEntity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Entries", "Transport_ID", "dbo.TransportTypes");
            DropIndex("dbo.Entries", new[] { "Transport_ID" });
            RenameColumn(table: "dbo.Entries", name: "Transport_ID", newName: "TransportTypeId");
            AddColumn("dbo.Entries", "Footprint", c => c.Double(nullable: false));
            AlterColumn("dbo.Entries", "TransportTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Entries", "TransportTypeId");
            AddForeignKey("dbo.Entries", "TransportTypeId", "dbo.TransportTypes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Entries", "TransportTypeId", "dbo.TransportTypes");
            DropIndex("dbo.Entries", new[] { "TransportTypeId" });
            AlterColumn("dbo.Entries", "TransportTypeId", c => c.Int());
            DropColumn("dbo.Entries", "Footprint");
            RenameColumn(table: "dbo.Entries", name: "TransportTypeId", newName: "Transport_ID");
            CreateIndex("dbo.Entries", "Transport_ID");
            AddForeignKey("dbo.Entries", "Transport_ID", "dbo.TransportTypes", "ID");
        }
    }
}
