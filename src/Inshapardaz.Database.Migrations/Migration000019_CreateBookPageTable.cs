using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000019)]
    public class Migration000019_CreateBookPageTable : Migration
    {
        public override void Up()
        {
            Create.Table(Tables.BookPage)
                .InSchema(Schemas.Library)
                .WithColumn(Columns.Id).AsInt64().PrimaryKey().Identity()
                .WithColumn(Columns.BookId).AsInt32().NotNullable().Indexed("IX_BookPage_BookId")
                .WithColumn("Text").AsString(int.MaxValue).Nullable()
                .WithColumn("PageNumber").AsInt32().Nullable()
                .WithColumn("PageUrl").AsString(int.MaxValue).Nullable();

            Create.ForeignKey("FK_BookPage_Book_BookId")
                .FromTable(Tables.BookPage).InSchema(Schemas.Library).ForeignColumn(Columns.BookId)
                .ToTable(Tables.Book).InSchema(Schemas.Library).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table(Tables.BookPage)
                .InSchema(Schemas.Library);
        }
    }
}
