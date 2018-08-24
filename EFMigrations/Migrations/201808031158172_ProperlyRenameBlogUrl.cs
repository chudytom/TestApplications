namespace EFMigrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProperlyRenameBlogUrl : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Blogs", "AwesomeUrl", "EvenBetterUrl");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.Blogs", "EvenBetterUrl", "AwesomeUrl");
        }
    }
}
