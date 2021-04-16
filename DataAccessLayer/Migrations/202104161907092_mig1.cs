namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Contents", name: "Writer_WriterId", newName: "WriterId");
            RenameIndex(table: "dbo.Contents", name: "IX_Writer_WriterId", newName: "IX_WriterId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Contents", name: "IX_WriterId", newName: "IX_Writer_WriterId");
            RenameColumn(table: "dbo.Contents", name: "WriterId", newName: "Writer_WriterId");
        }
    }
}
