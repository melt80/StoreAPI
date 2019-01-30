namespace Store.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_shopping_cart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartItem",
                c => new
                    {
                        CartItemId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        AlbumId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.CartItemId)
                .ForeignKey("dbo.Album", t => t.AlbumId, cascadeDelete: true)
                .Index(t => t.AlbumId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItem", "AlbumId", "dbo.Album");
            DropIndex("dbo.CartItem", new[] { "AlbumId" });
            DropTable("dbo.CartItem");
        }
    }
}
