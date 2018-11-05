namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemoviedb : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET ReleaseDate = '6/15/2001', DateAdded = '12/23/2009', NumberInStock =3 WHERE Id = 1");
            Sql("UPDATE Movies SET ReleaseDate = '5/5/2005', DateAdded = '5/5/2012', NumberInStock =11 WHERE Id = 2");
            Sql("UPDATE Movies SET ReleaseDate = '9/16/2003', DateAdded = '11/23/2011', NumberInStock =2 WHERE Id = 3");
            Sql("UPDATE Movies SET ReleaseDate = '1/5/1999', DateAdded = '05/06/2015', NumberInStock =0 WHERE Id = 4");
            Sql("UPDATE Movies SET ReleaseDate = '6/23/2008', DateAdded = '12/12/2009', NumberInStock =9 WHERE Id = 5");
        }
        
        public override void Down()
        {
        }
    }
}
