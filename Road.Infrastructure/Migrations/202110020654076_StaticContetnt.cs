namespace Road.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StaticContetnt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StaticContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Instagram = c.String(),
                        Facebook = c.String(),
                        Whatsapp = c.String(),
                        AboutUs = c.String(),
                        FooterDesc = c.String(),
                        Phonenumber = c.String(),
                        InsertUser = c.String(),
                        InsertDate = c.DateTime(),
                        UpdateUser = c.String(),
                        UpdateDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        Map = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Videos");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        FileName = c.String(),
                        InsertUser = c.String(),
                        InsertDate = c.DateTime(),
                        UpdateUser = c.String(),
                        UpdateDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.StaticContents");
        }
    }
}
