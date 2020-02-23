using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000009)]
    public class Migration000009_CreateChapterTable : Migration
    {
        public override void Up()
        {
            Create.Table("Chapter")
                .InSchema("Library")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(int.MaxValue).NotNullable()
                .WithColumn("BookId").AsInt32().Indexed("IX_Chapter_BookId")
                .WithColumn("ChapterNumber").AsInt32();
            Create.ForeignKey("FK_Chapter_Book_BookId")
                .FromTable("Chapter").InSchema("Library").ForeignColumn("BookId")
                .ToTable("Book").InSchema("Library").PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table("Chapter")
                .InSchema("Library");
        }
    }
}
