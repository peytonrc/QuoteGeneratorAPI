namespace QuoteGenerator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Quote", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Quote", "Rating", c => c.Double(nullable: false));
        }
    }
}
