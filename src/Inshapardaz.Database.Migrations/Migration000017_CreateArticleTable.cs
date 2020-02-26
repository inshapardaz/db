using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000017)]
    public class Migration000017_CreateArticleTable : Migration
    {
        public override void Up()
        {
            Create.Table(Tables.Article)
                .InSchema(Schemas.Library)
                .WithColumn(Columns.Id).AsInt32().PrimaryKey().Identity()
                .WithColumn("AuthorId").AsInt32().NotNullable().Indexed("IX_Article_AuthorId")
                .WithColumn("IssueId").AsInt32().NotNullable().Indexed("IX_Article_IssueId")
                .WithColumn("SequenceNumber").AsInt32().NotNullable()
                .WithColumn("SeriesIndex").AsInt32().Nullable()
                .WithColumn("SeriesName").AsString(int.MaxValue).Nullable();

            Create.ForeignKey("FK_Article_Issue_IssueId")
                .FromTable(Tables.Article).InSchema(Schemas.Library).ForeignColumn("IssueId")
                .ToTable(Tables.Issue).InSchema(Schemas.Library).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);
            Create.ForeignKey("FK_Article_Author_AuthorId")
                .FromTable(Tables.Article).InSchema(Schemas.Library).ForeignColumn("AuthorId")
                .ToTable(Tables.Author).InSchema(Schemas.Library).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table(Tables.Article)
                .InSchema(Schemas.Library);
        }
    }
}