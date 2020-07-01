namespace DAMS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Catagorys", "ItemValue", c => c.String(maxLength: 100, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Catagorys", "ItemValue", c => c.String(maxLength: 20, storeType: "nvarchar"));
        }
    }
}
