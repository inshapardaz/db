using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000079)]
    public class Migration000079_AddedMultipleAuthorSupportForArticle : Migration
    {
        public override void Up()
        {
            Create.Table("ArticleAuthor").InSchema(Schemas.Dbo)
                .WithColumn("ArticleId").AsInt32().Indexed("IX_ArticleAuthor_BookId")
                .WithColumn("AuthorId").AsInt32().Indexed("IX_ArticleAuthor_AuthorId");

            Create.PrimaryKey("PK_ArticleAuthor")
                .OnTable("ArticleAuthor").WithSchema(Schemas.Dbo)
                .Columns("ArticleId", "AuthorId");

            Delete.ForeignKey("FK_IssuePage_IssueArticle_ArticleId").OnTable(Tables.IssuePage).InSchema(Schemas.Dbo);
            Delete.ForeignKey("FK_IssueChapterContent_IssueChapter_ChapterId").OnTable(Tables.ArticleContent).InSchema(Schemas.Dbo);
            Delete.PrimaryKey("PK_IssueChapter").FromTable("Article").InSchema(Schemas.Dbo);
            Create.PrimaryKey("PK_Article").OnTable("Article").WithSchema(Schemas.Dbo).Column(Columns.Id);
            Create.ForeignKey("FK_IssuePage_IssueArticle_ArticleId")
                .FromTable(Tables.IssuePage).InSchema(Schemas.Dbo).ForeignColumn("ArticleId")
                .ToTable(Tables.Article).InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.None);
            
            Rename.Column("ChapterId").OnTable(Tables.ArticleContent).InSchema(Schemas.Dbo).To("ArticleId");
            Create.ForeignKey("FK_IssueChapterContent_IssueChapter_ChapterId")
                .FromTable(Tables.ArticleContent).InSchema(Schemas.Dbo).ForeignColumn("ArticleId")
                .ToTable(Tables.Article).InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.None);

            Create.ForeignKey("FK_ArticleAuthor_Article_ArticleId")
                .FromTable("ArticleAuthor").InSchema(Schemas.Dbo).ForeignColumn("ArticleId")
                .ToTable(Tables.Article).InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);
            
            Create.ForeignKey("FK_ArticleAuthor_Author_AuthorId")
                .FromTable("ArticleAuthor").InSchema(Schemas.Dbo).ForeignColumn("AuthorId")
                .ToTable(Tables.Author).InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.None);

            Execute.Sql("INSERT INTO ArticleAuthor Select Id, AuthorId from Article");

            Delete.Index("IX_Article_AuthorId").OnTable(Tables.Article).InSchema(Schemas.Dbo);
            Delete.ForeignKey("FK_Article_Author_AuthorId").OnTable("Article").InSchema(Schemas.Dbo);
            Delete.Column("AuthorId").FromTable(Tables.Article).InSchema(Schemas.Dbo);

            Delete.Index("IX_IssueChapter_IssueId").OnTable(Tables.Article).InSchema(Schemas.Dbo);

            Delete.ForeignKey("FK_IssueChapter_Issue_IssueId").OnTable("Article").InSchema(Schemas.Dbo);
            Create.ForeignKey("FK_Article_Issue_IssueId")
                .FromTable(Tables.Article).InSchema(Schemas.Dbo).ForeignColumn("IssueId")
                .ToTable(Tables.Issue).InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);

            Delete.ForeignKey("FK_IssueChapter_Reviewer_Accounts_AccountId").OnTable("Article").InSchema(Schemas.Dbo);
            Create.ForeignKey("FK_Article_Reviewer_Accounts_AccountId")
                .FromTable(Tables.Article).InSchema(Schemas.Dbo).ForeignColumn("ReviewerAccountId")
                .ToTable("Accounts").InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.None);

            Delete.ForeignKey("FK_IssueChapter_Writer_Accounts_AccountId").OnTable("Article").InSchema(Schemas.Dbo);
            Create.ForeignKey("FK_Article_Writer_Accounts_AccountId")
                .FromTable(Tables.Article).InSchema(Schemas.Dbo).ForeignColumn("WriterAccountId")
                .ToTable("Accounts").InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.None);
        }

        public override void Down()
        {
            Delete.Table("ArticleAuthor").InSchema(Schemas.Dbo);
            Alter.Table(Tables.Article).InSchema(Schemas.Dbo)
                .AddColumn("AuthorId").AsInt32().NotNullable().Indexed("IX_Article_AuthorId");
            Create.ForeignKey("FK_Article_Author_AuthorId")
                .FromTable(Tables.Article).InSchema(Schemas.Dbo).ForeignColumn("AuthorId")
                .ToTable(Tables.Author).InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.SetNull);
            
            Delete.ForeignKey("FK_Article_Reviewer_Accounts_AccountId").OnTable("Article").InSchema(Schemas.Dbo);
            Create.ForeignKey("FK_IssueChapter_Reviewer_Accounts_AccountId")
                .FromTable(Tables.Article).InSchema(Schemas.Dbo).ForeignColumn("ReviewerAccountId")
                .ToTable("Accounts").InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.None);

            Delete.ForeignKey("FK_Article_Writer_Accounts_AccountId").OnTable("Article").InSchema(Schemas.Dbo);
            Create.ForeignKey("FK_IssueChapter_Writer_Accounts_AccountId")
                .FromTable(Tables.Article).InSchema(Schemas.Dbo).ForeignColumn("WriterAccountId")
                .ToTable("Accounts").InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.None);

            Delete.PrimaryKey("PK_Article").FromTable("Article").InSchema(Schemas.Dbo);
            Create.PrimaryKey("PK_IssueChapter").OnTable("Article").WithSchema(Schemas.Dbo).Column(Columns.Id);
        }
    }
}
