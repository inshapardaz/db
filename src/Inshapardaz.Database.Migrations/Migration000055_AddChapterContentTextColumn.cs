using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000055)]
    public class Migration000055_AddChapterContentTextColumn : Migration
    {
        public override void Up()
        {
            Alter.Table(Tables.ChapterContent).InSchema(Schemas.Dbo)
                .AddColumn("Text").AsString(int.MaxValue).Nullable();
        }

        public override void Down()
        {
            Delete.Column("Text").FromTable(Tables.ChapterContent).InSchema(Schemas.Dbo);
        }
    }
}
