namespace DAMS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catagorys",
                c => new
                    {
                        Type = c.Int(nullable: false, identity: true),
                        ItemValue = c.String(maxLength: 20, storeType: "nvarchar"),
                        ItemText = c.String(maxLength: 200, storeType: "nvarchar"),
                        Remark = c.String(maxLength: 2000, storeType: "nvarchar"),
                        CreatedTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Type);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DeptId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50, storeType: "nvarchar"),
                        ParentId = c.Int(nullable: false),
                        Remark = c.String(maxLength: 2000, storeType: "nvarchar"),
                        CreatedTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.DeptId);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EquipmentNo = c.String(maxLength: 30, storeType: "nvarchar"),
                        UserId = c.String(maxLength: 20, storeType: "nvarchar"),
                        Name = c.String(maxLength: 50, storeType: "nvarchar"),
                        Remark = c.String(maxLength: 2000, storeType: "nvarchar"),
                        CreatedTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RecorderSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Resolution = c.String(maxLength: 50, storeType: "nvarchar"),
                        RunningType = c.String(maxLength: 10, storeType: "nvarchar"),
                        AutoUplodFile = c.Boolean(nullable: false),
                        IsDelRecorder = c.Boolean(nullable: false),
                        IsSetPort = c.Boolean(nullable: false),
                        RquipmentNum = c.Int(nullable: false),
                        ColNum = c.Int(nullable: false),
                        RawNum = c.Int(nullable: false),
                        LocalNetwork = c.String(maxLength: 50, storeType: "nvarchar"),
                        NetworkAddress = c.String(maxLength: 50, storeType: "nvarchar"),
                        FtpAddress = c.String(maxLength: 50, storeType: "nvarchar"),
                        FtpPort = c.String(maxLength: 20, storeType: "nvarchar"),
                        FtpId = c.String(maxLength: 20, storeType: "nvarchar"),
                        FtpPassword = c.String(maxLength: 50, storeType: "nvarchar"),
                        CreatedTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        ResourceId = c.Int(nullable: false, identity: true),
                        ResourceType = c.Int(nullable: false),
                        UserId = c.String(maxLength: 20, storeType: "nvarchar"),
                        EquipmentNo = c.String(maxLength: 50, storeType: "nvarchar"),
                        UserName = c.String(maxLength: 20, storeType: "nvarchar"),
                        DepartId = c.Int(nullable: false),
                        UploadTime = c.DateTime(precision: 0),
                        FilePath = c.String(maxLength: 200, storeType: "nvarchar"),
                        FileName = c.String(maxLength: 200, storeType: "nvarchar"),
                        Alias = c.String(maxLength: 300, storeType: "nvarchar"),
                        Extension = c.String(maxLength: 20, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.ResourceId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        RoleName = c.String(maxLength: 20, storeType: "nvarchar"),
                        Level = c.Int(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        CreatedTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 20, storeType: "nvarchar"),
                        Password = c.String(maxLength: 50, storeType: "nvarchar"),
                        ImageUrl = c.String(maxLength: 500, storeType: "nvarchar"),
                        UserName = c.String(maxLength: 50, storeType: "nvarchar"),
                        RoleId = c.Int(nullable: false),
                        DeptId = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        CreatedTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.Resources");
            DropTable("dbo.RecorderSettings");
            DropTable("dbo.Equipments");
            DropTable("dbo.Departments");
            DropTable("dbo.Catagorys");
        }
    }
}
