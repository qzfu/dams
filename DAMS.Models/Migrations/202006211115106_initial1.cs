namespace DAMS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Catagorys");
            AddColumn("dbo.Catagorys", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Catagorys", "Type", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Catagorys", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Catagorys");
            AlterColumn("dbo.Catagorys", "Type", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Catagorys", "Id");
            AddPrimaryKey("dbo.Catagorys", "Type");
        }
    }
}
