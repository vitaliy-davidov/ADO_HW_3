namespace ADO_HW_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Description");
        }
    }
}
