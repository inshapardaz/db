using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000056)]
    public class Migration000056_AddChapterContentRemovedColumns : Migration
    {
        public override void Up()
        {
            Delete.ForeignKey("FK_ChapterContent_File_FileId")
                           .OnTable(Tables.ChapterContent).InSchema(Schemas.Dbo);
            Delete.Column("ContentUrl").FromTable(Tables.ChapterContent).InSchema(Schemas.Dbo);
            Delete.Column("FileId").FromTable(Tables.ChapterContent).InSchema(Schemas.Dbo);

            Create.UniqueConstraint("UQ_ChapterId_Language")
                  .OnTable(Tables.ChapterContent).Columns("ChapterId", "Language");
        }

        public override void Down()
        {
            Alter.Table(Tables.ChapterContent).InSchema(Schemas.Dbo)
                .AddColumn("ContentUrl").AsString(int.MaxValue).Nullable();
            Alter.Table(Tables.ChapterContent).InSchema(Schemas.Dbo)
                .AddColumn("FileId").AsInt32().Nullable();

            Delete.UniqueConstraint("UQ_ChapterId_Language").FromTable(Tables.ChapterContent).InSchema(Schemas.Dbo);
        }
    }
}
