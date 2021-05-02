namespace TakeAction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedHiredDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "HiredDate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "HiredDate");
        }
    }
}
