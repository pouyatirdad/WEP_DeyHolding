namespace Road.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class show : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArticleComments", "Show", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ArticleComments", "Show");
        }
    }
}
