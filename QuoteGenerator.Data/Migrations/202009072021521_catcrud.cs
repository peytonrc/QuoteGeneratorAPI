namespace QuoteGenerator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class catcrud : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "CreatorId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Category", "CreatorId");
        }
    }
}
