using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000050)]
    public class Migration000050_ChangeUserIdToInteger : Migration
    {
        public override void Up()
        {
            Delete.Column("UserId").FromTable(Tables.FavoriteBooks);
            Delete.Column("UserId").FromTable(Tables.RecentBooks);
            Delete.Column("UserId").FromTable(Tables.BookShelf);
            Delete.Column("UserId").FromTable(Tables.BookPage);

            Create.Column("UserId").OnTable(Tables.FavoriteBooks).AsInt32().NotNullable();
            Create.Column("UserId").OnTable(Tables.RecentBooks).AsInt32().NotNullable();
            Create.Column("UserId").OnTable(Tables.BookShelf).AsInt32().NotNullable();
            Create.Column("UserId").OnTable(Tables.BookPage).AsInt32().Nullable();
        }

        public override void Down()
        {
            Delete.Column("UserId").FromTable(Tables.FavoriteBooks);
            Delete.Column("UserId").FromTable(Tables.RecentBooks);
            Delete.Column("UserId").FromTable(Tables.BookShelf);
            Delete.Column("UserId").FromTable(Tables.BookPage);

            Create.Column("UserId").OnTable(Tables.FavoriteBooks).AsGuid().NotNullable();
            Create.Column("UserId").OnTable(Tables.RecentBooks).AsGuid().NotNullable();
            Create.Column("UserId").OnTable(Tables.BookShelf).AsGuid().NotNullable();
            Create.Column("UserId").OnTable(Tables.BookPage).AsGuid().Nullable();
        }
    }
}
