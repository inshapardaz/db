using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000017)]
    public class Migration000017_CreateArticleTable : Migration
    {
        public override void Up()
        {
            Create.Table("Article")
                .InSchema("Library")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("AuthorId").AsInt32().NotNullable().Indexed("IX_Article_AuthorId")
                .WithColumn("IssueId").AsInt32().NotNullable().Indexed("IX_Article_IssueId")
                .WithColumn("SequenceNumber").AsInt32().NotNullable()
                .WithColumn("SeriesIndex").AsInt32().Nullable()
                .WithColumn("SeriesName").AsString(int.MaxValue).Nullable();

            Create.ForeignKey("FK_Article_Issue_IssueId")
                .FromTable("Article").InSchema("Library").ForeignColumn("IssueId")
                .ToTable("Issue").InSchema("Library").PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade);
            Create.ForeignKey("FK_Article_Author_AuthorId")
                .FromTable("Article").InSchema("Library").ForeignColumn("AuthorId")
                .ToTable("Author").InSchema("Library").PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table("Article")
                .InSchema("Library");
        }
    }
}