namespace Road.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class staticContent : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StaticContents");
        }
    }
}
