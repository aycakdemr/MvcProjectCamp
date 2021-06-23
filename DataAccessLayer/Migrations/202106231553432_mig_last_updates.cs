namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_last_updates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Writers", "WriterName", c => c.String());
            AlterColumn("dbo.Writers", "WriterSurname", c => c.String());
            AlterColumn("dbo.Writers", "WriterImage", c => c.String());
            AlterColumn("dbo.Writers", "WriterAbout", c => c.String());
            AlterColumn("dbo.Writers", "WriterMail", c => c.String());
            AlterColumn("dbo.Writers", "PasswordSalt", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writers", "PasswordSalt", c => c.Binary(maxLength: 200));
            AlterColumn("dbo.Writers", "WriterMail", c => c.String(maxLength: 200));
            AlterColumn("dbo.Writers", "WriterAbout", c => c.String(maxLength: 100));
            AlterColumn("dbo.Writers", "WriterImage", c => c.String(maxLength: 100));
            AlterColumn("dbo.Writers", "WriterSurname", c => c.String(maxLength: 250));
            AlterColumn("dbo.Writers", "WriterName", c => c.String(maxLength: 50));
        }
    }
}
