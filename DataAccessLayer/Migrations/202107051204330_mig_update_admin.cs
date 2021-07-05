namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_update_admin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Role", c => c.String());
            DropColumn("dbo.Admins", "AdminRoleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminRoleId", c => c.Int(nullable: false));
            DropColumn("dbo.Admins", "Role");
        }
    }
}
