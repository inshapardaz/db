using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000073)]
    public class Migration000073_AddedIssuePage : Migration
    {
        public override void Up()
        {
             Create.Table(Tables.IssuePage)
                .InSchema(Schemas.Dbo)
                .WithColumn(Columns.Id).AsInt64().PrimaryKey().Identity()
                .WithColumn("IssueId").AsInt32().NotNullable().Indexed("IX_IssuePage_IssueId")
                .WithColumn("Text").AsString(int.MaxValue).Nullable()
                .WithColumn("ChapterId").AsInt32().Nullable()
                .WithColumn("SequenceNumber").AsInt32().Nullable()
                .WithColumn("ImageId").AsString(int.MaxValue).Nullable()
                .WithColumn("Status").AsInt32().WithDefaultValue(0)
                .WithColumn("WriterAccountId").AsInt32().Nullable()
                .WithColumn("WriterAssignTimeStamp").AsDateTime2().Nullable()
                .WithColumn("ReviewerAccountId").AsInt32().Nullable()
                .WithColumn("ReviewerAssignTimeStamp").AsDateTime2().Nullable();
            
            Create.ForeignKey("FK_IssuePage_Issue_IssueId")
                .FromTable(Tables.IssuePage).InSchema(Schemas.Dbo).ForeignColumn("IssueId")
                .ToTable(Tables.Issue).InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);
            Create.ForeignKey("FK_IssuePage_IssueChapter_ChapterId")
                .FromTable(Tables.IssuePage).InSchema(Schemas.Dbo).ForeignColumn("ChapterId")
                .ToTable(Tables.IssueChapter).InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.None);
            Create.ForeignKey("FK_IssuePage_Writer_Accounts_AccountId")
                .FromTable(Tables.IssuePage).InSchema(Schemas.Dbo).ForeignColumn("WriterAccountId")
                .ToTable("Accounts").InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.None);
            Create.ForeignKey("FK_IssuePage_Reviewer_Accounts_AccountId")
                .FromTable(Tables.IssuePage).InSchema(Schemas.Dbo).ForeignColumn("ReviewerAccountId")
                .ToTable("Accounts").InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.None);
        }

        public override void Down()
        {
            Delete.Table(Tables.IssuePage).InSchema(Schemas.Dbo);
        }
    }
}
