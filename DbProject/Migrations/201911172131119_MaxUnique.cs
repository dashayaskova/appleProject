namespace DbProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaxUnique : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.user", "username", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.user", "email", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.user", "username", unique: true);
            CreateIndex("dbo.user", "email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.user", new[] { "email" });
            DropIndex("dbo.user", new[] { "username" });
            AlterColumn("dbo.user", "email", c => c.String(nullable: false));
            AlterColumn("dbo.user", "username", c => c.String(nullable: false));
        }
    }
}
