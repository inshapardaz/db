using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000018)]
    public class Migration000018_CreateArticleTextTable : Migration
    {
        public override void Up()
        {
            Create.Table(Tables.ArticleText)
                .InSchema(Schemas.Library)
                .WithColumn(Columns.Id).AsInt32().PrimaryKey().Identity()
                //.WithColumn("ContentUrl").AsString(int.MaxValue)
                .WithColumn("ArticleId").AsInt32().NotNullable().Indexed("IX_ArticleText_ArticleId")
                // TODO : Make not nullable
                .WithColumn("Content").AsString(int.MaxValue).Nullable();
            Create.ForeignKey("FK_ArticleText_Article_ArticleId")
                .FromTable(Tables.ArticleText).InSchema(Schemas.Library).ForeignColumn("ArticleId")
                .ToTable(Tables.Article).InSchema(Schemas.Library).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table(Tables.ArticleText)
                .InSchema(Schemas.Library);
        }
    }
}
