namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class birthdateproperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BirthDate", c => c.DateTime());
            Sql("UPDATE Customers SET BirthDate='12/12/2002' WHERE Id = 1");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "BirthDate");
        }
    }
}
