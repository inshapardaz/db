using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000035)]
    public class Migration000035_AddMultipleChapterFiles : Migration
    {
        public override void Up()
        {
            Alter.Table(Tables.ChapterContent).InSchema(Schemas.Library)
                .AddColumn("FileId").AsInt32().NotNullable();

            Create.ForeignKey("FK_ChapterContent_File_FileId")
                .FromTable(Tables.ChapterContent).InSchema(Schemas.Library).ForeignColumn(Columns.FileId)
                .ToTable(Tables.File).InSchema(Schemas.Inshapardaz).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_ChapterContent_File_FileId")
                .OnTable(Tables.ChapterContent).InSchema(Schemas.Library);

            Delete.Column("FileId")
                .FromTable(Tables.ChapterContent).InSchema(Schemas.Library);
        }
    }
}