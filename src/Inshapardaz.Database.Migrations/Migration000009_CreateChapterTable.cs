using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000009)]
    public class Migration000009_CreateChapterTable : Migration
    {
        public override void Up()
        {
            Create.Table(Tables.Chapter)
                .InSchema(Schemas.Library)
                .WithColumn(Columns.Id).AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(int.MaxValue).NotNullable()
                .WithColumn(Columns.BookId).AsInt32().Indexed("IX_Chapter_BookId")
                .WithColumn("ChapterNumber").AsInt32();
            Create.ForeignKey("FK_Chapter_Book_BookId")
                .FromTable(Tables.Chapter).InSchema(Schemas.Library).ForeignColumn(Columns.BookId)
                .ToTable(Tables.Book).InSchema(Schemas.Library).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table(Tables.Chapter)
                .InSchema(Schemas.Library);
        }
    }
}
