using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000088)]
    public class Migration000088_RenameArticleTable : Migration
    {
        public override void Up()
        {
            Rename.Table(Tables.ArticleContent)
                .InSchema(Schemas.Dbo)
                .To("IssueArticleContent");
            
            Rename.Table("ArticleAuthor")
                .InSchema(Schemas.Dbo)
                .To("IssueArticleAuthor");

            Rename.Column("ArticleId")
                .OnTable("IssueArticleAuthor")
                .To("IssueArticleId");

            Rename.Table(Tables.Article)
                .InSchema(Schemas.Dbo)
                .To("IssueArticle");

            Execute.Sql("EXEC sp_rename N'[PK_Article]', '[PK_IssueArticle]'");
            Execute.Sql("EXEC sp_rename N'[FK_Article_Issue_IssueId]', '[FK_IssueArticle_Issue_IssueId]'");
            Execute.Sql("EXEC sp_rename N'[FK_Article_Reviewer_Accounts_AccountId]', '[FK_IssueArticle_Reviewer_Accounts_AccountId]'");
            Execute.Sql("EXEC sp_rename N'[FK_Article_Writer_Accounts_AccountId]', '[FK_IssueArticle_Writer_Accounts_AccountId]'");
            
            Execute.Sql("EXEC sp_rename N'[PK_ArticleAuthor]', '[PK_IssueArticleAuthor]'");
            Execute.Sql("EXEC sp_rename N'[FK_ArticleAuthor_Article_ArticleId]', '[FK_IssueArticleAuthor_Article_ArticleId]'");
            Execute.Sql("EXEC sp_rename N'[FK_ArticleAuthor_Author_AuthorId]', '[FK_IssueArticleAuthor_Author_AuthorId]'");

            Execute.Sql("EXEC sp_rename N'[PK_IssueChapterContent]', '[PK_IssueArticle_Content]'");
            Execute.Sql("EXEC sp_rename N'[UQ_ArticleId_Language]', '[UQ_IssueArticleId_Language]'");
            Execute.Sql("EXEC sp_rename N'[FK_IssueChapterContent_IssueChapter_ChapterId]', '[FK_IssueArticleContent_IssueArticle_ArticleId]'");
        }

        public override void Down()
        {
            Rename.Table("IssueArticleContent")
                .InSchema(Schemas.Dbo)
                .To(Tables.ArticleContent);

            Rename.Column("IssueArticleId")
                .OnTable("IssueArticleAuthor")
                .To("ArticleId");
            
            Rename.Table("IssueArticleAuthor")
                .InSchema(Schemas.Dbo)
                .To("ArticleAuthor");

            Rename.Table("IssueArticle")
                .InSchema(Schemas.Dbo)
                .To(Tables.Article);

            Execute.Sql("EXEC sp_rename N'[PK_IssueArticle]', '[PK_Article]'");
            Execute.Sql("EXEC sp_rename N'[FK_IssueArticle_Issue_IssueId]', '[FK_Article_Issue_IssueId]'");
            Execute.Sql("EXEC sp_rename N'[FK_IssueArticle_Reviewer_Accounts_AccountId]', '[FK_Article_Reviewer_Accounts_AccountId]'");
            Execute.Sql("EXEC sp_rename N'[FK_IssueArticle_Writer_Accounts_AccountId]', '[FK_Article_Writer_Accounts_AccountId]'");

            Execute.Sql("EXEC sp_rename N'[PK_IssueArticleAuthor]', '[PK_ArticleAuthor]'");
            Execute.Sql("EXEC sp_rename N'[FK_IssueArticleAuthor_Article_ArticleId]', '[FK_ArticleAuthor_Article_ArticleId]'");
            Execute.Sql("EXEC sp_rename N'[FK_IssueArticleAuthor_Author_AuthorId]', '[FK_ArticleAuthor_Author_AuthorId]'");

            Execute.Sql("EXEC sp_rename N'[PK_IssueArticle_Content]', '[PK_IssueChapterContent]'");
            Execute.Sql("EXEC sp_rename N'[UQ_IssueArticleId_Language]', '[UQ_ArticleId_Language]'");
            Execute.Sql("EXEC sp_rename N'[FK_IssueArticleContent_IssueArticle_ArticleId]', '[FK_IssueChapterContent_IssueChapter_ChapterId]'");
        }
    }
}
