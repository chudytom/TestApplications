namespace EFMigrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameBlogUrl1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Blogs", "EvenBetterUrl", "BestUrlEver");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.Blogs", "BestUrlEver", "EvenBetterUrl");
        }
    }
}
