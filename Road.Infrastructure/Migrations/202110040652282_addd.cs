namespace Road.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StaticContentDetails", "StaticContentTypeId", "dbo.StaticContentTypes");
            DropIndex("dbo.StaticContentDetails", new[] { "StaticContentTypeId" });
            AddColumn("dbo.StaticContents", "ImageLogo", c => c.String());
            DropTable("dbo.StaticContentDetails");
            DropTable("dbo.StaticContentTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StaticContentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 600),
                        InsertUser = c.String(),
                        InsertDate = c.DateTime(),
                        UpdateUser = c.String(),
                        UpdateDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StaticContentDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 600),
                        ShortDescription = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                        Link = c.String(),
                        StaticContentTypeId = c.Int(nullable: false),
                        InsertUser = c.String(),
                        InsertDate = c.DateTime(),
                        UpdateUser = c.String(),
                        UpdateDate = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.StaticContents", "ImageLogo");
            CreateIndex("dbo.StaticContentDetails", "StaticContentTypeId");
            AddForeignKey("dbo.StaticContentDetails", "StaticContentTypeId", "dbo.StaticContentTypes", "Id", cascadeDelete: true);
        }
    }
}
