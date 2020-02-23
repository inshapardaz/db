using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000018)]
    public class Migration000018_CreateArticleTextTable : Migration
    {
        public override void Up()
        {
            Create.Table("ArticleText")
                .InSchema("Library")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                //.WithColumn("ContentUrl").AsString(int.MaxValue)
                .WithColumn("ArticleId").AsInt32().NotNullable().Indexed("IX_ArticleText_ArticleId")
                // TODO : Make not nullable
                .WithColumn("Content").AsString(int.MaxValue).Nullable();
            Create.ForeignKey("FK_ArticleText_Article_ArticleId")
                .FromTable("ArticleText").InSchema("Library").ForeignColumn("ArticleId")
                .ToTable("Article").InSchema("Library").PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table("ArticleText")
                .InSchema("Library");
        }
    }
}
