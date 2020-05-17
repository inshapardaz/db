using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000036)]
    public class Migration000036_AddedChapterContentLanguage : Migration
    {
        public override void Up()
        {
            Alter.Table(Tables.ChapterContent).InSchema(Schemas.Library)
                .AddColumn("Language").AsString().Nullable();
        }

        public override void Down()
        {
            Delete.Column("Language")
                .FromTable(Tables.ChapterContent).InSchema(Schemas.Library);
        }
    }
}