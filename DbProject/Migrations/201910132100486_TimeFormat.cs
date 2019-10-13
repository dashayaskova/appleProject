namespace DbProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimeFormat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.record", "start_time", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.record", "endTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.record", "endTime", c => c.DateTime());
            AlterColumn("dbo.record", "start_time", c => c.DateTime(nullable: false));
        }
    }
}
