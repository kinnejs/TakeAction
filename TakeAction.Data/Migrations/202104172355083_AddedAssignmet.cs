namespace TakeAction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAssignmet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assignment", "AssignmentOwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assignment", "AssignmentOwnerId");
        }
    }
}
