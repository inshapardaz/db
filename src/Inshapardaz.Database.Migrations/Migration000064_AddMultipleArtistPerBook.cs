using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000065)]
    public class Migration000064_AddMultipleArtistPerBook : Migration
    {
        public override void Up()
        {
            Delete.ForeignKey("FK_Book_Author_AuthorId").OnTable("Book").InSchema(Schemas.Dbo);
            Create.Table("BookAuthor").InSchema(Schemas.Dbo)
                .WithColumn("BookId").AsInt32().Indexed("IX_BookAuthor_BookId")
                .WithColumn("AuthorId").AsInt32().Indexed("IX_BookAuthor_AuthorId");

            Create.PrimaryKey("PK_BookAuthor")
                .OnTable("BookAuthor").WithSchema(Schemas.Dbo)
                .Columns("BookId", "AuthorId");
            
            Create.ForeignKey("FK_BookAuthor_Book_BookId")
                .FromTable("BookAuthor").InSchema(Schemas.Dbo).ForeignColumn("BookId")
                .ToTable(Tables.Book).InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);
            
            Create.ForeignKey("FK_BookAuthor_Author_AuthorId")
                .FromTable("BookAuthor").InSchema(Schemas.Dbo).ForeignColumn("AuthorId")
                .ToTable(Tables.Author).InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);

            Execute.Sql("INSERT INTO BookAuthor Select Id, AuthorId from Book");
        }

        public override void Down()
        {
            Delete.Table("BookAuthor").InSchema(Schemas.Dbo);
            Create.ForeignKey("FK_Book_Author_AuthorId")
                .FromTable(Tables.Book).InSchema(Schemas.Library).ForeignColumn("AuthorId")
                .ToTable(Tables.Author).InSchema(Schemas.Library).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);
        }
    }
}