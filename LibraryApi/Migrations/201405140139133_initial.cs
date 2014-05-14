namespace LibraryApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoanedOn = c.DateTime(nullable: false),
                        Returned = c.DateTime(),
                        Description = c.String(),
                        Book_Id = c.Int(),
                        Friend_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .ForeignKey("dbo.Friends", t => t.Friend_Id)
                .Index(t => t.Book_Id)
                .Index(t => t.Friend_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loans", "Friend_Id", "dbo.Friends");
            DropForeignKey("dbo.Loans", "Book_Id", "dbo.Books");
            DropIndex("dbo.Loans", new[] { "Friend_Id" });
            DropIndex("dbo.Loans", new[] { "Book_Id" });
            DropTable("dbo.Loans");
            DropTable("dbo.Friends");
            DropTable("dbo.Books");
        }
    }
}
