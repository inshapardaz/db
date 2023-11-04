using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000090)]
    public class Migration000090_AddArticle : Migration
    {
        public override void Up()
        {
            Create.Table("Article").InSchema(Schemas.Dbo)
                .WithColumn(Columns.Id).AsInt64().PrimaryKey().Identity()
                .WithColumn("Title").AsString(512).NotNullable()
                .WithColumn("Status").AsInt32().WithDefaultValue(0)
                .WithColumn(Columns.IsPublic).AsBoolean().WithDefaultValue(0)
                .WithColumn("Type").AsInt32().WithDefaultValue(0)
                .WithColumn("LibraryId").AsInt32().ForeignKey("Library", "Id")
                .WithColumn("ImageId").AsInt32().ForeignKey("File", "Id").Nullable()
                .WithColumn("WriterAccountId").AsInt32().ForeignKey("Accounts", "Id").Nullable()
                .WithColumn("WriterAssignTimeStamp").AsDateTime2().Nullable()
                .WithColumn("ReviewerAccountId").AsInt32().ForeignKey("Accounts", "Id").Nullable()
                .WithColumn("ReviewerAssignTimeStamp").AsDateTime2().Nullable()
                .WithColumn("SourceType").AsString().Nullable()
                .WithColumn("SourceId").AsInt32().Nullable()
                .WithColumn("LastModified").AsDateTime2().WithDefaultValue(SystemMethods.CurrentUTCDateTime);
            Create.Table("ArticleAuthor").InSchema(Schemas.Dbo)
                .WithColumn("ArticleId").AsInt64().ForeignKey("Article","Id").OnDeleteOrUpdate(System.Data.Rule.Cascade)
                .WithColumn("AuthorId").AsInt32().ForeignKey("Author","Id").OnDeleteOrUpdate(System.Data.Rule.Cascade);
            Create.Table("ArticleCategory").InSchema(Schemas.Dbo)
                .WithColumn("ArticleId").AsInt64().ForeignKey("Article","Id").OnDeleteOrUpdate(System.Data.Rule.Cascade)
                .WithColumn("CategoryId").AsInt32().ForeignKey("Category","Id").OnDeleteOrUpdate(System.Data.Rule.Cascade);
            Create.Table("ArticleContent").InSchema(Schemas.Dbo)
                .WithColumn(Columns.Id).AsInt32().PrimaryKey().Identity()
                .WithColumn("ArticleId").AsInt64().ForeignKey("Article", "Id").OnDeleteOrUpdate(System.Data.Rule.Cascade).Indexed("IX_ArticleContent_ArticleId")
                .WithColumn(Columns.Language).AsString().Nullable()
                .WithColumn("Text").AsString(int.MaxValue).NotNullable();
            Create.Table("ArticleFavorite").InSchema(Schemas.Dbo)
                .WithColumn("ArticleId").AsInt64().ForeignKey("Article","Id").OnDeleteOrUpdate(System.Data.Rule.Cascade)
                .WithColumn("AccountId").AsInt32().ForeignKey("Accounts","Id").OnDeleteOrUpdate(System.Data.Rule.Cascade)
                .WithColumn("LibraryId").AsInt32().ForeignKey("Library", "Id").OnDeleteOrUpdate(System.Data.Rule.Cascade);
            Create.Table("ArticleRead").InSchema(Schemas.Dbo)
                .WithColumn("ArticleId").AsInt64().ForeignKey("Article","Id").OnDeleteOrUpdate(System.Data.Rule.Cascade)
                .WithColumn("AccountId").AsInt32().ForeignKey("Accounts","Id").OnDeleteOrUpdate(System.Data.Rule.Cascade)
                .WithColumn("LibraryId").AsInt32().ForeignKey("Library", "Id").OnDeleteOrUpdate(System.Data.Rule.Cascade)
                .WithColumn("DateRead").AsDateTime2().WithDefaultValue(SystemMethods.CurrentUTCDateTime);
        }

        public override void Down()
        {
            Delete.Table("ArticleFavorite").InSchema(Schemas.Dbo);
            Delete.Table("ArticleRead").InSchema(Schemas.Dbo);
            Delete.Table("ArticleContent").InSchema(Schemas.Dbo);
            Delete.Table("ArticleCategory").InSchema(Schemas.Dbo);
            Delete.Table("ArticleAuthor").InSchema(Schemas.Dbo);
            Delete.Table("Article").InSchema(Schemas.Dbo);
        }
    }
}
