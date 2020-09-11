namespace QuoteGenerator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedYourName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "YourName", c => c.String());
            DropColumn("dbo.ApplicationUser", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUser", "Name", c => c.String());
            DropColumn("dbo.ApplicationUser", "YourName");
        }
    }
}
