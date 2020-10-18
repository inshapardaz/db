using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000043)]
    public class Migration000043_AddedArticleTitle : Migration
    {
        public override void Up()
        {
            Alter.Table("Article")
            .InSchema(Schemas.Dbo)
            .AddColumn("Title").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Column("Title").FromTable("IssueContent")
                .InSchema(Schemas.Dbo);
        }
    }
}
