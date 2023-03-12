namespace WishListManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestIfItsWork : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BaseEntities",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CreatedDateTime = c.DateTime(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Name = c.String(),
                        BirthDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BaseEntities", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.WishListItems",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        WishListItemDescription = c.String(nullable: false),
                        RoughPrice = c.Decimal(precision: 18, scale: 2),
                        Priority = c.Int(),
                        UserId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BaseEntities", t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.Id)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WishListItems", "UserId", "dbo.Users");
            DropForeignKey("dbo.WishListItems", "Id", "dbo.BaseEntities");
            DropForeignKey("dbo.Users", "Id", "dbo.BaseEntities");
            DropIndex("dbo.WishListItems", new[] { "UserId" });
            DropIndex("dbo.WishListItems", new[] { "Id" });
            DropIndex("dbo.Users", new[] { "Id" });
            DropTable("dbo.WishListItems");
            DropTable("dbo.Users");
            DropTable("dbo.BaseEntities");
        }
    }
}
