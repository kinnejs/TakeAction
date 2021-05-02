namespace TakeAction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedEmployeeManagerFullName : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employee", "ManagerFullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "ManagerFullName", c => c.String());
        }
    }
}
