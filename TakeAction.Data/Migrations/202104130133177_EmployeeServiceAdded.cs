namespace TakeAction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeServiceAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "EmployeeOwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "EmployeeOwnerId");
        }
    }
}
