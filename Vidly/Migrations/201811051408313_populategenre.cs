namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populategenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Family')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Romance')");

            Sql("INSERT INTO Movies (Name, GenreId) VALUES ('Hangover', 1)");
            Sql("INSERT INTO Movies (Name, GenreId) VALUES ('Die Hard', 2)");
            Sql("INSERT INTO Movies (Name, GenreId) VALUES ('The Terminator', 2)");
            Sql("INSERT INTO Movies (Name, GenreId) VALUES ('Toy Story', 3)");
            Sql("INSERT INTO Movies (Name, GenreId) VALUES ('Titanic', 4)");   
        }
        
        public override void Down()
        {
        }
    }
}
