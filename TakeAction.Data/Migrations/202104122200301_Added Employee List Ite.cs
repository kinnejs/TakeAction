namespace TakeAction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEmployeeListIte : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Assignment", "AssignedDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.TaskL", "DueDate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TaskL", "DueDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Assignment", "AssignedDate", c => c.DateTime(nullable: false));
        }
    }
}
