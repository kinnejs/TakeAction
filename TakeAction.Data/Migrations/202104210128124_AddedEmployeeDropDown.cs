namespace TakeAction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEmployeeDropDown : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assignment", "EmployeeFullName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assignment", "EmployeeFullName");
        }
    }
}
