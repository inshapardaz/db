using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000072)]
    public class Migration000072_AddedIssueChapter : Migration
    {
        public override void Up()
        {
            Create.Table(Tables.IssueChapter)
                .InSchema(Schemas.Dbo)
                .WithColumn(Columns.Id).AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(int.MaxValue).NotNullable()
                .WithColumn("IssueId").AsInt32().Indexed("IX_IssueChapter_IssueId")
                .WithColumn("ChapterNumber").AsInt32()
                .WithColumn("Status").AsInt32().WithDefaultValue(0)
                .WithColumn("WriterAccountId").AsInt32().Nullable()
                .WithColumn("WriterAssignTimeStamp").AsDateTime2().Nullable()
                .WithColumn("ReviewerAccountId").AsInt32().Nullable()
                .WithColumn("ReviewerAssignTimeStamp").AsDateTime2().Nullable();

            Create.Table(Tables.IssueChapterContent)
                .InSchema(Schemas.Dbo)
                .WithColumn(Columns.Id).AsInt32().PrimaryKey().Identity()
                .WithColumn("Text").AsString(int.MaxValue).Nullable()
                .WithColumn("ChapterId").AsInt32().Indexed("IX_ChapterContent_ChapterId")
                .WithColumn("Language").AsString().Nullable();

            Create.ForeignKey("FK_IssueChapterContent_IssueChapter_ChapterId")
                .FromTable(Tables.IssueChapterContent).InSchema(Schemas.Dbo).ForeignColumn("ChapterId")
                .ToTable(Tables.IssueChapter).InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);

            Create.ForeignKey("FK_IssueChapter_Issue_IssueId")
                .FromTable(Tables.IssueChapter).InSchema(Schemas.Dbo).ForeignColumn("IssueId")
                .ToTable(Tables.Issue).InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);
            
            Create.ForeignKey("FK_IssueChapter_Writer_Accounts_AccountId")
                .FromTable(Tables.IssueChapter).InSchema(Schemas.Dbo).ForeignColumn("WriterAccountId")
                .ToTable("Accounts").InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.None);
            Create.ForeignKey("FK_IssueChapter_Reviewer_Accounts_AccountId")
                .FromTable(Tables.IssueChapter).InSchema(Schemas.Dbo).ForeignColumn("ReviewerAccountId")
                .ToTable("Accounts").InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.None );
            
        }

        public override void Down()
        {
            Delete.Table(Tables.IssueChapterContent).InSchema(Schemas.Dbo);
            Delete.Table(Tables.IssueChapter).InSchema(Schemas.Dbo);
        }
    }
}
