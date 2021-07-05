namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_update_admin3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "Mail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "Mail");
        }
    }
}
