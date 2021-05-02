namespace TakeAction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedManagerHiredDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Manager", "HiredDate", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Manager", "HiredDate");
        }
    }
}
