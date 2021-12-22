﻿namespace PanonicaV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class druga : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductionDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ProductionDate", c => c.DateTime(nullable: false));
        }
    }
}
