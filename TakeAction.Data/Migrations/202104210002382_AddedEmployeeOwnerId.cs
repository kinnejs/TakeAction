namespace TakeAction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEmployeeOwnerId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "EmployeeOwnerId", c => c.Guid(nullable: false));
            DropColumn("dbo.Employee", "AssignmentOwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "AssignmentOwnerId", c => c.Guid(nullable: false));
            DropColumn("dbo.Employee", "EmployeeOwnerId");
        }
    }
}
