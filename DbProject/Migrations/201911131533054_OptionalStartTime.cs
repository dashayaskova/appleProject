namespace DbProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OptionalStartTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.record", "start_time", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.record", "start_time", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
