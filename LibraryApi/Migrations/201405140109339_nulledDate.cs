namespace LibraryApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nulledDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Loans", "Returned", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Loans", "Returned", c => c.DateTime(nullable: false));
        }
    }
}
