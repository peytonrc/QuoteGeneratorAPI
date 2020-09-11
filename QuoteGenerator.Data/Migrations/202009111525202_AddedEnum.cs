namespace QuoteGenerator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEnum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "CategoryPreference", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUser", "CategoryPreference");
        }
    }
}
