namespace Road.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StaticChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StaticContents", "Feature1", c => c.String());
            AddColumn("dbo.StaticContents", "Feature2", c => c.String());
            AddColumn("dbo.StaticContents", "Feature3", c => c.String());
            AddColumn("dbo.StaticContents", "Feature4", c => c.String());
            AddColumn("dbo.StaticContents", "History", c => c.String());
            AddColumn("dbo.StaticContents", "CompanyVision", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StaticContents", "CompanyVision");
            DropColumn("dbo.StaticContents", "History");
            DropColumn("dbo.StaticContents", "Feature4");
            DropColumn("dbo.StaticContents", "Feature3");
            DropColumn("dbo.StaticContents", "Feature2");
            DropColumn("dbo.StaticContents", "Feature1");
        }
    }
}
