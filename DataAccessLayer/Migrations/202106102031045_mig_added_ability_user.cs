namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_added_ability_user : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Degree = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Admins", "UserName", c => c.String());
            AddColumn("dbo.Admins", "AdminUserNameSalt", c => c.Binary());
            AddColumn("dbo.Admins", "AdminUserNameHash", c => c.Binary());
            DropColumn("dbo.Admins", "AdminUserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminUserName", c => c.String());
            DropColumn("dbo.Admins", "AdminUserNameHash");
            DropColumn("dbo.Admins", "AdminUserNameSalt");
            DropColumn("dbo.Admins", "UserName");
            DropTable("dbo.Users");
            DropTable("dbo.Abilities");
        }
    }
}
