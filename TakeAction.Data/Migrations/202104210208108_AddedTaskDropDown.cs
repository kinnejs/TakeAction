namespace TakeAction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTaskDropDown : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assignment", "TaskName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assignment", "TaskName");
        }
    }
}
