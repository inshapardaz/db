using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000091)]
    public class Migration000091_AddArticleContentLayout : Migration
    {
        public override void Up()
        {
            Alter.Table("ArticleContent").InSchema(Schemas.Dbo)
                .AddColumn("Layout")
                .AsString()
                .Nullable();
        }

        public override void Down()
        {
            Delete.Column("Layout")
                .FromTable("ArticleContent")
                .InSchema(Schemas.Dbo);
        }
    }
}
