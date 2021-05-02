namespace TakeAction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "HiredDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Employee", "ManagerFullName", c => c.String());
            DropColumn("dbo.Manager", "AssignmentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Manager", "AssignmentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Employee", "ManagerFullName", c => c.String(nullable: false));
            DropColumn("dbo.Employee", "HiredDate");
        }
    }
}
