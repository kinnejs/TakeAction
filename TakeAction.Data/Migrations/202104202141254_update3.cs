namespace TakeAction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "AssignmentOwnerId", c => c.Guid(nullable: false));
            DropColumn("dbo.Employee", "EmployeeOwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "EmployeeOwnerId", c => c.Guid(nullable: false));
            DropColumn("dbo.Employee", "AssignmentOwnerId");
        }
    }
}
