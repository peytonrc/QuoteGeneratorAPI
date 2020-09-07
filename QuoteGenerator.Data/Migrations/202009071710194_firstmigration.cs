namespace QuoteGenerator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRatingQuote", "QuoteId", "dbo.Quote");
            DropForeignKey("dbo.UserRatingQuote", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.UserRatingQuote", new[] { "QuoteId" });
            DropIndex("dbo.UserRatingQuote", new[] { "ApplicationUser_Id" });
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            AddColumn("dbo.Author", "CreatorId", c => c.Guid(nullable: false));
            AddColumn("dbo.Quote", "OwnerId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Quote", "CategoryId");
            AddForeignKey("dbo.Quote", "CategoryId", "dbo.Category", "CategoryId", cascadeDelete: true);
            DropTable("dbo.UserRatingQuote");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserRatingQuote",
                c => new
                    {
                        UserRatingQuoteId = c.Int(nullable: false, identity: true),
                        QuoteId = c.Int(nullable: false),
                        Rating = c.Double(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserRatingQuoteId);
            
            DropForeignKey("dbo.Quote", "CategoryId", "dbo.Category");
            DropIndex("dbo.Quote", new[] { "CategoryId" });
            DropColumn("dbo.Quote", "OwnerId");
            DropColumn("dbo.Author", "CreatorId");
            DropTable("dbo.Category");
            CreateIndex("dbo.UserRatingQuote", "ApplicationUser_Id");
            CreateIndex("dbo.UserRatingQuote", "QuoteId");
            AddForeignKey("dbo.UserRatingQuote", "ApplicationUser_Id", "dbo.ApplicationUser", "Id");
            AddForeignKey("dbo.UserRatingQuote", "QuoteId", "dbo.Quote", "QuoteId", cascadeDelete: true);
        }
    }
}
