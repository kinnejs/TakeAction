namespace TakeAction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "EmployeeOwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Manager", "AssignmentOwnerId", c => c.Guid(nullable: false));
            DropColumn("dbo.Employee", "ManagerOwnerId");
            DropColumn("dbo.Manager", "ManagerOwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Manager", "ManagerOwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Employee", "ManagerOwnerId", c => c.Guid(nullable: false));
            DropColumn("dbo.Manager", "AssignmentOwnerId");
            DropColumn("dbo.Employee", "EmployeeOwnerId");
        }
    }
}
