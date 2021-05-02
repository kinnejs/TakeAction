namespace TakeAction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewComputer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "OwnerId");
        }
    }
}
