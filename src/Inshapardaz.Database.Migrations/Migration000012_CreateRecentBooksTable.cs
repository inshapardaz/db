using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000012)]
    public class Migration000012_CreateRecentBooksTable : Migration
    {
        public override void Up()
        {
            Create.Table(Tables.RecentBooks)
                .InSchema(Schemas.Library)
                .WithColumn(Columns.Id).AsInt32().PrimaryKey().Identity()
                .WithColumn(Columns.BookId).AsInt32().Indexed("IX_RecentBooks_BookId")
                .WithColumn("UserId").AsGuid()
                .WithColumn("DateRead").AsDateTime2();
            Create.ForeignKey("FK_RecentBooks_Book_BookId")
                .FromTable(Tables.RecentBooks).InSchema(Schemas.Library).ForeignColumn(Columns.BookId)
                .ToTable(Tables.Book).InSchema(Schemas.Library).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table(Tables.RecentBooks)
                .InSchema(Schemas.Library);
        }
    }
}
