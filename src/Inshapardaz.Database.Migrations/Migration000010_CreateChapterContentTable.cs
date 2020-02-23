using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000010)]
    public class Migration000010_CreateChapterContentTable : Migration
    {
        public override void Up()
        {
            Create.Table("ChapterContent")
                .InSchema("Library")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("ContentUrl").AsString(int.MaxValue).Nullable()
                .WithColumn("ChapterId").AsInt32().Indexed("IX_ChapterContent_ChapterId")
                .WithColumn("MimeType").AsString(int.MaxValue).Nullable();
            Create.ForeignKey("FK_ChapterContent_Chapter_ChapterId")
                .FromTable("ChapterContent").InSchema("Library").ForeignColumn("ChapterId")
                .ToTable("Chapter").InSchema("Library").PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table("ChapterContent")
                .InSchema("Library");
        }
    }
}
