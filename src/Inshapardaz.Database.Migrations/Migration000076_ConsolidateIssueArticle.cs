using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000076)]
    public class Migration000076_ConsolidateIssueArticle : Migration
    {
        public override void Up()
        {
            Delete.ForeignKey("FK_Article_Issue_IssueId").OnTable(Tables.Article).InSchema(Schemas.Dbo);
            Delete.ForeignKey("FK_Article_Author_AuthorId").OnTable(Tables.Article).InSchema(Schemas.Dbo);
            Delete.ForeignKey("FK_ArticleText_Article_ArticleId").OnTable(Tables.ArticleText).InSchema(Schemas.Dbo);
            Delete.Index("IX_Article_AuthorId").OnTable(Tables.Article).InSchema(Schemas.Dbo);
            Delete.Index("IX_Article_IssueId").OnTable(Tables.Article).InSchema(Schemas.Dbo);
            
            Delete.Table(Tables.Article).InSchema(Schemas.Dbo);
            Delete.Table(Tables.ArticleText).InSchema(Schemas.Dbo);
            Rename.Table(Tables.IssueChapter).InSchema(Schemas.Dbo).To(Tables.Article);
            Rename.Table(Tables.IssueChapterContent).InSchema(Schemas.Dbo).To(Tables.ArticleContent);
            Alter.Table(Tables.Article).InSchema(Schemas.Dbo)
                .AddColumn("AuthorId").AsInt32().NotNullable().Indexed("IX_Article_AuthorId")
                .AddColumn("SequenceNumber").AsInt32().Nullable()
                .AddColumn("SeriesIndex").AsInt32().Nullable()
                .AddColumn("SeriesName").AsString(int.MaxValue).Nullable();
            
            Create.ForeignKey("FK_Article_Author_AuthorId")
                .FromTable(Tables.Article).InSchema(Schemas.Dbo).ForeignColumn("AuthorId")
                .ToTable(Tables.Author).InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);

            Create.Index("IX_Article_IssueId").OnTable(Tables.Article).InSchema(Schemas.Dbo).OnColumn("IssueId");
        }

        public override void Down()
        {
            Delete.Column("AuthorId")
                .Column("SequenceNumber")
                .Column("SeriesIndex")
                .Column("SeriesName")
                .FromTable(Tables.Article)
                .InSchema(Schemas.Dbo);

            Rename.Table(Tables.Article).InSchema(Schemas.Dbo).To(Tables.IssueChapter);
            Rename.Table(Tables.ArticleContent).InSchema(Schemas.Dbo).To(Tables.IssueChapterContent);
            Create.Table(Tables.Article)
                .InSchema(Schemas.Dbo)
                .WithColumn(Columns.Id).AsInt32().PrimaryKey().Identity()
                .WithColumn("AuthorId").AsInt32().NotNullable().Indexed("IX_Article_AuthorId")
                .WithColumn("IssueId").AsInt32().NotNullable().Indexed("IX_Article_IssueId")
                .WithColumn("SequenceNumber").AsInt32().NotNullable()
                .WithColumn("SeriesIndex").AsInt32().Nullable()
                .WithColumn("SeriesName").AsString(int.MaxValue).Nullable();

            Create.ForeignKey("FK_Article_Issue_IssueId")
                .FromTable(Tables.Article).InSchema(Schemas.Dbo).ForeignColumn("IssueId")
                .ToTable(Tables.Issue).InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);
            Create.ForeignKey("FK_Article_Author_AuthorId")
                .FromTable(Tables.Article).InSchema(Schemas.Dbo).ForeignColumn("AuthorId")
                .ToTable(Tables.Author).InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);

            Create.Table(Tables.ArticleText)
                .InSchema(Schemas.Dbo)
                .WithColumn(Columns.Id).AsInt32().PrimaryKey().Identity()
                .WithColumn("ArticleId").AsInt32().NotNullable().Indexed("IX_ArticleText_ArticleId")
                .WithColumn("Content").AsString(int.MaxValue).Nullable();
            Create.ForeignKey("FK_ArticleText_Article_ArticleId")
                .FromTable(Tables.ArticleText).InSchema(Schemas.Dbo).ForeignColumn("ArticleId")
                .ToTable(Tables.Article).InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);
        }
    }
}
