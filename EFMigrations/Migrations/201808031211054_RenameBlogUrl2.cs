namespace EFMigrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameBlogUrl2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Blogs", "BestUrlEver", "AnotherUrl");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.Blogs", "AnotherUrl", "BestUrlEver");
        }
    }
}
