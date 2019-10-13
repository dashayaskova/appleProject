namespace DbProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.group",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        name = c.String(nullable: false),
                        color_name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.user", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.record",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        start_time = c.DateTime(nullable: false),
                        duration = c.Long(),
                        endTime = c.DateTime(),
                        comment = c.String(),
                        GroupId = c.Guid(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.group", t => t.GroupId)
                .ForeignKey("dbo.user", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.user",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        username = c.String(nullable: false),
                        name = c.String(nullable: false),
                        surname = c.String(),
                        email = c.String(nullable: false),
                        password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.group", "UserId", "dbo.user");
            DropForeignKey("dbo.record", "UserId", "dbo.user");
            DropForeignKey("dbo.record", "GroupId", "dbo.group");
            DropIndex("dbo.record", new[] { "GroupId" });
            DropIndex("dbo.record", new[] { "UserId" });
            DropIndex("dbo.group", new[] { "UserId" });
            DropTable("dbo.user");
            DropTable("dbo.record");
            DropTable("dbo.group");
        }
    }
}
