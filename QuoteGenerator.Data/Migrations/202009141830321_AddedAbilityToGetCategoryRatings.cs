namespace QuoteGenerator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAbilityToGetCategoryRatings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserRatingQuote", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserRatingQuote", "CategoryId");
            AddForeignKey("dbo.UserRatingQuote", "CategoryId", "dbo.Category", "CategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRatingQuote", "CategoryId", "dbo.Category");
            DropIndex("dbo.UserRatingQuote", new[] { "CategoryId" });
            DropColumn("dbo.UserRatingQuote", "CategoryId");
        }
    }
}
