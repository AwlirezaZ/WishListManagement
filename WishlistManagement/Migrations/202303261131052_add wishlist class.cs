namespace WishListManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addwishlistclass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WishListItems", "UserId", "dbo.Users");
            DropIndex("dbo.WishListItems", new[] { "UserId" });
            CreateTable(
                "dbo.WishLists",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        UserId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BaseEntities", t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.Id)
                .Index(t => t.UserId);
            
            AddColumn("dbo.WishListItems", "Title", c => c.String(nullable: false));
            AddColumn("dbo.WishListItems", "WishListId", c => c.Long(nullable: false));
            CreateIndex("dbo.WishListItems", "WishListId");
            AddForeignKey("dbo.WishListItems", "WishListId", "dbo.WishLists", "Id");
            DropColumn("dbo.WishListItems", "WishListItemDescription");
            DropColumn("dbo.WishListItems", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WishListItems", "UserId", c => c.Long(nullable: false));
            AddColumn("dbo.WishListItems", "WishListItemDescription", c => c.String(nullable: false));
            DropForeignKey("dbo.WishLists", "UserId", "dbo.Users");
            DropForeignKey("dbo.WishLists", "Id", "dbo.BaseEntities");
            DropForeignKey("dbo.WishListItems", "WishListId", "dbo.WishLists");
            DropIndex("dbo.WishLists", new[] { "UserId" });
            DropIndex("dbo.WishLists", new[] { "Id" });
            DropIndex("dbo.WishListItems", new[] { "WishListId" });
            DropColumn("dbo.WishListItems", "WishListId");
            DropColumn("dbo.WishListItems", "Title");
            DropTable("dbo.WishLists");
            CreateIndex("dbo.WishListItems", "UserId");
            AddForeignKey("dbo.WishListItems", "UserId", "dbo.Users", "Id");
        }
    }
}
