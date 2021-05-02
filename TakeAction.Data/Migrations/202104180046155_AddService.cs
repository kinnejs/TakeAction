namespace TakeAction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddService : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Manager", "AssignmentOwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Manager", "AssignmentId", c => c.Int(nullable: false));
            DropColumn("dbo.Manager", "ManagerOwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Manager", "ManagerOwnerId", c => c.Guid(nullable: false));
            DropColumn("dbo.Manager", "AssignmentId");
            DropColumn("dbo.Manager", "AssignmentOwnerId");
        }
    }
}
