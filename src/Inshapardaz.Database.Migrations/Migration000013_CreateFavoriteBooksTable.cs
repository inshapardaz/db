using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000013)]
    public class Migration000013_CreateFavoriteBooksTable : Migration
    {
        public override void Up()
        {
            Create.Table(Tables.FavoriteBooks)
                .InSchema(Schemas.Library)
                .WithColumn(Columns.Id).AsInt32().PrimaryKey().Identity()
                .WithColumn(Columns.BookId).AsInt32().Indexed("IX_FavoriteBooks_BookId")
                .WithColumn("UserId").AsGuid()
                .WithColumn("DateAdded").AsDateTime2();
            Create.ForeignKey("FK_FavoriteBooks_Book_BookId")
                .FromTable(Tables.FavoriteBooks).InSchema(Schemas.Library).ForeignColumn(Columns.BookId)
                .ToTable(Tables.Book).InSchema(Schemas.Library).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table(Tables.FavoriteBooks)
                .InSchema(Schemas.Library);
        }
    }
}
