namespace TakeAction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAssignment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assignment", "DeptA", c => c.Int(nullable: false));
            AddColumn("dbo.Assignment", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assignment", "OwnerId");
            DropColumn("dbo.Assignment", "DeptA");
        }
    }
}
