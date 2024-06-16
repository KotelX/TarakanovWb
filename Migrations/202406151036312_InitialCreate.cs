namespace TarakanovWb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dishes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Eaten",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dishes_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dishes", t => t.Dishes_Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.Dishes_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Eaten", "User_Id", "dbo.User");
            DropForeignKey("dbo.Eaten", "Dishes_Id", "dbo.Dishes");
            DropForeignKey("dbo.Dishes", "User_Id", "dbo.User");
            DropIndex("dbo.Eaten", new[] { "User_Id" });
            DropIndex("dbo.Eaten", new[] { "Dishes_Id" });
            DropIndex("dbo.Dishes", new[] { "User_Id" });
            DropTable("dbo.Eaten");
            DropTable("dbo.User");
            DropTable("dbo.Dishes");
        }
    }
}
