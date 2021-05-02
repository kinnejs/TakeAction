namespace TakeAction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedComments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assignment", "ManagerId", c => c.Int());
            CreateIndex("dbo.Assignment", "ManagerId");
            AddForeignKey("dbo.Assignment", "ManagerId", "dbo.Manager", "ManagerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assignment", "ManagerId", "dbo.Manager");
            DropIndex("dbo.Assignment", new[] { "ManagerId" });
            DropColumn("dbo.Assignment", "ManagerId");
        }
    }
}
