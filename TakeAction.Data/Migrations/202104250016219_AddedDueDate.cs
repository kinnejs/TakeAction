namespace TakeAction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDueDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Assignment", "DueDate", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Assignment", "DueDate", c => c.String());
        }
    }
}
