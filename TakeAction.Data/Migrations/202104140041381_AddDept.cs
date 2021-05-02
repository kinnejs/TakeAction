namespace TakeAction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDept : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "Dept", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employee", "Dept");
        }
    }
}
