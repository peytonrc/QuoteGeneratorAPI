namespace QuoteGenerator.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotSure : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "FavoriteCategory", c => c.Int(nullable: false));
            DropColumn("dbo.ApplicationUser", "FavoriteCategoroy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUser", "FavoriteCategoroy", c => c.Int(nullable: false));
            DropColumn("dbo.ApplicationUser", "FavoriteCategory");
        }
    }
}
