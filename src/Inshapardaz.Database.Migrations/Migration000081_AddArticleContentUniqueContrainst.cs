using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000081)]
    public class Migration000081_AddArticleContentUniqueContrainst : Migration
    {
        public override void Up()
        {
            Create.UniqueConstraint("UQ_ArticleId_Language")
                  .OnTable(Tables.ArticleContent).Columns("ArticleId", "Language");
        }

        public override void Down()
        {
            Delete.UniqueConstraint("UQ_ArticleId_Language")
                .FromTable(Tables.ArticleContent)
                .InSchema(Schemas.Dbo);
        }
    }
}
