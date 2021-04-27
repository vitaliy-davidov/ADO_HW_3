namespace ADO_HW_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Pages = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SageBooks",
                c => new
                    {
                        Sage_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Sage_Id, t.Book_Id })
                .ForeignKey("dbo.Sages", t => t.Sage_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Sage_Id)
                .Index(t => t.Book_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SageBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.SageBooks", "Sage_Id", "dbo.Sages");
            DropIndex("dbo.SageBooks", new[] { "Book_Id" });
            DropIndex("dbo.SageBooks", new[] { "Sage_Id" });
            DropTable("dbo.SageBooks");
            DropTable("dbo.Sages");
            DropTable("dbo.Books");
        }
    }
}
