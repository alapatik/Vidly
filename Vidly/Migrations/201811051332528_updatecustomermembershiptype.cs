namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecustomermembershiptype : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET MembershipTypeId=2 WHERE Id = 2");
        }
        
        public override void Down()
        {
        }
    }
}
