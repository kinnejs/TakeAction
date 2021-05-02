namespace TakeAction.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedsubordinates : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Manager", "Subordinates");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Manager", "Subordinates", c => c.Int(nullable: false));
        }
    }
}
