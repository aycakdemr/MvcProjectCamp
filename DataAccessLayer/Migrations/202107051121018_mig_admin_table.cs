namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_admin_table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminRoleId", c => c.Int(nullable: false));
            DropColumn("dbo.Admins", "AdminRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminRole", c => c.String());
            DropColumn("dbo.Admins", "AdminRoleId");
        }
    }
}
