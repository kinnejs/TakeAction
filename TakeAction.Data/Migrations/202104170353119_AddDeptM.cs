namespace TakeAction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeptM : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "ManagerOwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Manager", "DeptM", c => c.Int(nullable: false));
            DropColumn("dbo.Employee", "EmployeeOwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "EmployeeOwnerId", c => c.Guid(nullable: false));
            DropColumn("dbo.Manager", "DeptM");
            DropColumn("dbo.Employee", "ManagerOwnerId");
        }
    }
}
