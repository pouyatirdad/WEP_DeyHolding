namespace Road.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addemail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StaticContents", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StaticContents", "Email");
        }
    }
}
