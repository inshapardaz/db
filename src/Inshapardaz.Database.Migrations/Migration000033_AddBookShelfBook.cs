using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000033)]
    public class Migration000033_AddBookShelfBook : Migration
    {
        public override void Up()
        {
            Create.Table(Tables.BookShelfBook).InSchema(Schemas.Library)
                 .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                 .WithColumn("BookId").AsInt32().NotNullable()
                 .WithColumn("BookShelfId").AsInt32().NotNullable();
            
            Create.ForeignKey("FK_BookShelfBook_Book")
                  .FromTable(Tables.BookShelfBook).InSchema(Schemas.Library).ForeignColumn("BookId")
                  .ToTable(Tables.Book).InSchema(Schemas.Library).PrimaryColumn(Columns.Id)
                  .OnDelete(System.Data.Rule.Cascade);

            Create.ForeignKey("FK_BookShelfBook_BookShelf")
                  .FromTable(Tables.BookShelfBook).InSchema(Schemas.Library).ForeignColumn("BookShelfId")
                  .ToTable(Tables.BookShelf).InSchema(Schemas.Library).PrimaryColumn(Columns.Id)
                  .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_BookShelfBook_Book").OnTable(Tables.BookShelfBook).InSchema(Schemas.Library);
            Delete.ForeignKey("FK_BookShelfBook_BookShelf").OnTable(Tables.BookShelfBook).InSchema(Schemas.Library);
            Delete.Table(Tables.BookShelfBook).InSchema(Schemas.Library);
        }
    }
}
