using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000078)]
    public class Migration000078_RenameArticleSequenceNumber : Migration
    {
        public override void Up()
        {
            Delete.Column("ChapterNumber").FromTable(Tables.Article).InSchema(Schemas.Dbo);
        }

        public override void Down()
        {
            Alter.Table(Tables.Article).InSchema(Schemas.Dbo)
            .AddColumn("ChapterNumber").AsInt32().NotNullable();
        }
    }
}
