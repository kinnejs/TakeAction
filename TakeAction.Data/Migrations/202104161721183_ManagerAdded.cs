namespace TakeAction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManagerAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Manager",
                c => new
                    {
                        ManagerId = c.Int(nullable: false, identity: true),
                        ManagerOwnerId = c.Guid(nullable: false),
                        ManagerFirstName = c.String(nullable: false),
                        ManagerLastName = c.String(nullable: false),
                        Subordinates = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ManagerId);
            
            AddColumn("dbo.Employee", "ManagerId", c => c.Int());
            CreateIndex("dbo.Employee", "ManagerId");
            AddForeignKey("dbo.Employee", "ManagerId", "dbo.Manager", "ManagerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "ManagerId", "dbo.Manager");
            DropIndex("dbo.Employee", new[] { "ManagerId" });
            DropColumn("dbo.Employee", "ManagerId");
            DropTable("dbo.Manager");
        }
    }
}
