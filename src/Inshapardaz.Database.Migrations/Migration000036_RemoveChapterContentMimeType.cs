using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000037)]
    public class Migration000036_RemoveChapterContentMimeType : Migration
    {
        public override void Up()
        {
            Delete.Column("MimeType").FromTable(Tables.ChapterContent).InSchema(Schemas.Library);
        }

        public override void Down()
        {
            Alter.Table(Tables.ChapterContent).InSchema(Schemas.Library)
                .AddColumn("MimeType").AsString(int.MaxValue).Nullable();
        }
    }
}