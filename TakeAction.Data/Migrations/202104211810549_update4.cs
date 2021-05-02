namespace TakeAction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assignment", "TaskSummary", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assignment", "TaskSummary");
        }
    }
}
