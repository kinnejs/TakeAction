namespace TakeAction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedHiredDate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "ManagerFullName", c => c.String(nullable: false));
            DropColumn("dbo.Employee", "ManagerFirstName");
            DropColumn("dbo.Employee", "ManagerLastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "ManagerLastName", c => c.String(nullable: false));
            AddColumn("dbo.Employee", "ManagerFirstName", c => c.String(nullable: false));
            DropColumn("dbo.Employee", "ManagerFullName");
        }
    }
}
