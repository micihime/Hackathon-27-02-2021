namespace TravelGreen.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyTransportTypeName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TransportTypes", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TransportTypes", "Name", c => c.Int(nullable: false));
        }
    }
}
