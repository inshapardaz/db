using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000077)]
    public class Migration000077_UpdatedIssuePageChapter : Migration
    {
        public override void Up()
        {
            Delete.ForeignKey("FK_IssuePage_IssueChapter_ChapterId").OnTable(Tables.IssuePage).InSchema(Schemas.Dbo);

            Rename.Column("ChapterId").OnTable(Tables.IssuePage).InSchema(Schemas.Dbo).To("ArticleId");
            
            Create.ForeignKey("FK_IssuePage_IssueArticle_ArticleId")
                .FromTable(Tables.IssuePage).InSchema(Schemas.Dbo).ForeignColumn("ArticleId")
                .ToTable(Tables.Article).InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.None);
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_IssuePage_IssueArticle_ArticleId").OnTable(Tables.IssuePage).InSchema(Schemas.Dbo);

            Rename.Column("ArticleId").OnTable(Tables.IssuePage).InSchema(Schemas.Dbo).To("ChapterId");

            Create.ForeignKey("FK_IssuePage_IssueChapter_ChapterId")
                .FromTable(Tables.IssuePage).InSchema(Schemas.Dbo).ForeignColumn("ChapterId")
                .ToTable(Tables.Article).InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.None);
        }
    }
}
