using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000032)]
    public class Migration000032_AddBookShelf : Migration
    {
        public override void Up()
        {
            Create.Table(Tables.BookShelf).InSchema(Schemas.Library)
                 .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                 .WithColumn("UserId").AsGuid().NotNullable()
                 .WithColumn("LibraryId").AsInt32().Nullable();
            
            Create.ForeignKey("FK_BookShelf_Library")
                  .FromTable(Tables.BookShelf).InSchema(Schemas.Library).ForeignColumn("LibraryId")
                  .ToTable(Tables.Library).InSchema(Schemas.Library).PrimaryColumn(Columns.Id)
                  .OnDelete(System.Data.Rule.None);
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_BookShelf_Library").OnTable(Tables.BookShelf).InSchema(Schemas.Library);
            Delete.Table(Tables.BookShelf).InSchema(Schemas.Library);
        }
    }
}
