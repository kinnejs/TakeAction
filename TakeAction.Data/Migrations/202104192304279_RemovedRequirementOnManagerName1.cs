namespace TakeAction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedRequirementOnManagerName1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employee", "ManagerFullName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employee", "ManagerFullName", c => c.String(nullable: false));
        }
    }
}
