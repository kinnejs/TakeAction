namespace TakeAction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedManagerOwnerId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Manager", "ManagerOwnerId", c => c.Guid(nullable: false));
            DropColumn("dbo.Manager", "AssignmentOwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Manager", "AssignmentOwnerId", c => c.Guid(nullable: false));
            DropColumn("dbo.Manager", "ManagerOwnerId");
        }
    }
}
