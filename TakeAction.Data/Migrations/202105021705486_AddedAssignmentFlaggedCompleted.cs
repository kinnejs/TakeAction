namespace TakeAction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAssignmentFlaggedCompleted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assignment", "Flagged", c => c.Boolean(nullable: false));
            AddColumn("dbo.Assignment", "Completed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assignment", "Completed");
            DropColumn("dbo.Assignment", "Flagged");
        }
    }
}
