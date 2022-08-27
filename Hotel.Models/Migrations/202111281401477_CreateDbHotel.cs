namespace Hotel.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDbHotel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        CommentText = c.String(nullable: false, maxLength: 2000),
                        Name = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 30),
                        RegisterDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId);
            
            CreateTable(
                "dbo.T_Factors",
                c => new
                    {
                        FactorId = c.Int(nullable: false, identity: true),
                        IsFainally = c.Boolean(nullable: false),
                        ValidateTime = c.Int(nullable: false),
                        FainallyDate = c.DateTime(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                        Price = c.Int(nullable: false),
                        RegisterUserId = c.Int(nullable: false),
                        Description = c.String(maxLength: 500),
                        UserId = c.Int(nullable: false),
                        RoomsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FactorId)
                .ForeignKey("dbo.T_Rooms", t => t.RoomsId)
                .ForeignKey("dbo.T_Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoomsId);
            
            CreateTable(
                "dbo.T_Rooms",
                c => new
                    {
                        ProductRoomsID = c.Int(nullable: false),
                        RoomsTitle = c.String(nullable: false, maxLength: 300),
                        Description = c.String(nullable: false),
                        ImageName = c.String(nullable: false, maxLength: 100),
                        PricePerNight = c.String(nullable: false, maxLength: 10),
                        CapacityRoom = c.String(nullable: false, maxLength: 10),
                        RegisterDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        RoomsGroupId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Raservations_RaservationId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductRoomsID)
                .ForeignKey("dbo.T_RoomsGroups", t => t.RoomsGroupId)
                .ForeignKey("dbo.T_Users", t => t.UserId)
                .ForeignKey("dbo.T_Raservations", t => t.Raservations_RaservationId)
                .Index(t => t.RoomsGroupId)
                .Index(t => t.UserId)
                .Index(t => t.Raservations_RaservationId);
            
            CreateTable(
                "dbo.T_RoomsGroups",
                c => new
                    {
                        RoomsGroupId = c.Int(nullable: false),
                        RoomsGroupTitle = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false),
                        ImageName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.RoomsGroupId);
            
            CreateTable(
                "dbo.T_Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 50),
                        MobileNumber = c.String(nullable: false, maxLength: 15),
                        Password = c.String(nullable: false, maxLength: 100),
                        RegisterDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        RoleId = c.Int(nullable: false),
                        Role_RoleId = c.Byte(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.T_Roles", t => t.Role_RoleId)
                .Index(t => t.Role_RoleId);
            
            CreateTable(
                "dbo.T_Roles",
                c => new
                    {
                        RoleId = c.Byte(nullable: false),
                        RoleTittle = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.T_Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        TittlePay = c.String(nullable: false, maxLength: 200),
                        Price = c.Int(nullable: false),
                        ResultPayment = c.Boolean(nullable: false),
                        ResultCode = c.Byte(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                        TransactionCode = c.String(nullable: false, maxLength: 200),
                        RandomFactorId = c.String(nullable: false, maxLength: 200),
                        ApIKey = c.String(nullable: false, maxLength: 100),
                        FactorId = c.Int(nullable: false),
                        RaservationsId = c.Int(nullable: false),
                        Raservations_RaservationId = c.Int(),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.T_Factors", t => t.FactorId)
                .ForeignKey("dbo.T_Raservations", t => t.Raservations_RaservationId)
                .Index(t => t.FactorId)
                .Index(t => t.Raservations_RaservationId);
            
            CreateTable(
                "dbo.T_Raservations",
                c => new
                    {
                        RaservationId = c.Int(nullable: false, identity: true),
                        RegisterDate = c.DateTime(nullable: false),
                        InnerDate = c.DateTime(nullable: false),
                        OuterDate = c.DateTime(nullable: false),
                        CountOfUser = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        RoomsId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RaservationId)
                .ForeignKey("dbo.T_Users", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_Raservations", "UserId", "dbo.T_Users");
            DropForeignKey("dbo.T_Rooms", "Raservations_RaservationId", "dbo.T_Raservations");
            DropForeignKey("dbo.T_Payments", "Raservations_RaservationId", "dbo.T_Raservations");
            DropForeignKey("dbo.T_Payments", "FactorId", "dbo.T_Factors");
            DropForeignKey("dbo.T_Rooms", "UserId", "dbo.T_Users");
            DropForeignKey("dbo.T_Users", "Role_RoleId", "dbo.T_Roles");
            DropForeignKey("dbo.T_Factors", "UserId", "dbo.T_Users");
            DropForeignKey("dbo.T_Rooms", "RoomsGroupId", "dbo.T_RoomsGroups");
            DropForeignKey("dbo.T_Factors", "RoomsId", "dbo.T_Rooms");
            DropIndex("dbo.T_Raservations", new[] { "UserId" });
            DropIndex("dbo.T_Payments", new[] { "Raservations_RaservationId" });
            DropIndex("dbo.T_Payments", new[] { "FactorId" });
            DropIndex("dbo.T_Users", new[] { "Role_RoleId" });
            DropIndex("dbo.T_Rooms", new[] { "Raservations_RaservationId" });
            DropIndex("dbo.T_Rooms", new[] { "UserId" });
            DropIndex("dbo.T_Rooms", new[] { "RoomsGroupId" });
            DropIndex("dbo.T_Factors", new[] { "RoomsId" });
            DropIndex("dbo.T_Factors", new[] { "UserId" });
            DropTable("dbo.T_Raservations");
            DropTable("dbo.T_Payments");
            DropTable("dbo.T_Roles");
            DropTable("dbo.T_Users");
            DropTable("dbo.T_RoomsGroups");
            DropTable("dbo.T_Rooms");
            DropTable("dbo.T_Factors");
            DropTable("dbo.T_Comments");
        }
    }
}
