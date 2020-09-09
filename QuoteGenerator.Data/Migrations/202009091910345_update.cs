namespace QuoteGenerator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRatingQuote",
                c => new
                    {
                        UserRatingQuoteId = c.Int(nullable: false, identity: true),
                        QuoteId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        UserRating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.UserRatingQuoteId)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Quote", t => t.QuoteId, cascadeDelete: true)
                .Index(t => t.QuoteId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRatingQuote", "QuoteId", "dbo.Quote");
            DropForeignKey("dbo.UserRatingQuote", "UserId", "dbo.ApplicationUser");
            DropIndex("dbo.UserRatingQuote", new[] { "UserId" });
            DropIndex("dbo.UserRatingQuote", new[] { "QuoteId" });
            DropTable("dbo.UserRatingQuote");
        }
    }
}
