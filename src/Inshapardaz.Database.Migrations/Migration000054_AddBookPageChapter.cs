using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000054)]
    public class Migration000054_AddBookPageChapter : Migration
    {
        public override void Up()
        {
            Alter.Table(Tables.BookPage).InSchema(Schemas.Dbo)
                .AddColumn("ChapterId").AsInt32().Nullable();

            Create.ForeignKey("FK_BookPage_Chapter_ChapterId")
            .FromTable(Tables.BookPage).InSchema(Schemas.Dbo).ForeignColumn("ChapterId")
            .ToTable(Tables.Chapter).InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id);
        }

        public override void Down()
        {
            Delete.Column("ChapterId").FromTable(Tables.BookPage).InSchema(Schemas.Dbo);
        }
    }
}
