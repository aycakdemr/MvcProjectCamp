namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_added_hashing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "PasswordSalt", c => c.Binary());
            AddColumn("dbo.Admins", "PasswordHash", c => c.Binary());
            DropColumn("dbo.Admins", "AdminPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminPassword", c => c.String());
            DropColumn("dbo.Admins", "PasswordHash");
            DropColumn("dbo.Admins", "PasswordSalt");
        }
    }
}
