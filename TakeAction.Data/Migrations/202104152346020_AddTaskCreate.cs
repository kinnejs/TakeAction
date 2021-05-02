namespace TakeAction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTaskCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Taskl", "TaskOwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Taskl", "TaskOwnerId");
        }
    }
}
