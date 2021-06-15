namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_writer_password : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "PasswordSalt", c => c.Binary(maxLength: 200));
            AddColumn("dbo.Writers", "PasswordHash", c => c.Binary());
            AlterColumn("dbo.Writers", "WriterTitle", c => c.String());
            DropColumn("dbo.Writers", "WriterPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 200));
            AlterColumn("dbo.Writers", "WriterTitle", c => c.String(maxLength: 50));
            DropColumn("dbo.Writers", "PasswordHash");
            DropColumn("dbo.Writers", "PasswordSalt");
        }
    }
}
