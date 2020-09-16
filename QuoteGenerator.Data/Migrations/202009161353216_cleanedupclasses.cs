namespace QuoteGenerator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cleanedupclasses : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Author", "CreatorId");
            DropColumn("dbo.Quote", "OwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Quote", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Author", "CreatorId", c => c.Guid(nullable: false));
        }
    }
}
