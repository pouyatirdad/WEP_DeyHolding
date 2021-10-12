namespace Road.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StaticContents", "Feature1Des", c => c.String());
            AddColumn("dbo.StaticContents", "Feature2Des", c => c.String());
            AddColumn("dbo.StaticContents", "Feature3Des", c => c.String());
            AddColumn("dbo.StaticContents", "Feature4Des", c => c.String());
            AddColumn("dbo.StaticContents", "Counter1Num", c => c.Int(nullable: false));
            AddColumn("dbo.StaticContents", "Counter1Text", c => c.String());
            AddColumn("dbo.StaticContents", "Counter2Num", c => c.Int(nullable: false));
            AddColumn("dbo.StaticContents", "Counter2Text", c => c.String());
            AddColumn("dbo.StaticContents", "Counter3Num", c => c.Int(nullable: false));
            AddColumn("dbo.StaticContents", "Counter3Text", c => c.String());
            AddColumn("dbo.StaticContents", "Counter4Num", c => c.Int(nullable: false));
            AddColumn("dbo.StaticContents", "Counter4Text", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StaticContents", "Counter4Text");
            DropColumn("dbo.StaticContents", "Counter4Num");
            DropColumn("dbo.StaticContents", "Counter3Text");
            DropColumn("dbo.StaticContents", "Counter3Num");
            DropColumn("dbo.StaticContents", "Counter2Text");
            DropColumn("dbo.StaticContents", "Counter2Num");
            DropColumn("dbo.StaticContents", "Counter1Text");
            DropColumn("dbo.StaticContents", "Counter1Num");
            DropColumn("dbo.StaticContents", "Feature4Des");
            DropColumn("dbo.StaticContents", "Feature3Des");
            DropColumn("dbo.StaticContents", "Feature2Des");
            DropColumn("dbo.StaticContents", "Feature1Des");
        }
    }
}
