namespace EFMigrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameBlogUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "AwesomeUrl", c => c.String());
            DropColumn("dbo.Blogs", "Url");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "Url", c => c.String());
            DropColumn("dbo.Blogs", "AwesomeUrl");
        }
    }
}
