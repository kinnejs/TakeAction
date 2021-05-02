namespace TakeAction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedManagerFullNameToTask : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Taskl", "ManagerFullName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Taskl", "ManagerFullName");
        }
    }
}
