using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000042)]
    public class Migration000042_CreateIssueContentTable : Migration
    {
        public override void Up()
        {
            Create.Table("IssueContent")
                .InSchema(Schemas.Dbo)
                .WithColumn(Columns.Id).AsInt32().PrimaryKey().Identity()
                .WithColumn("IssueId").AsInt32().Indexed("IX_IssueContent_IssueId")
                .WithColumn(Columns.Language).AsString().Nullable()
                .WithColumn("MimeType").AsString().Nullable()
                .WithColumn(Columns.FileId).AsInt32().Indexed("IX_IssueContent_FileId");

            Create.ForeignKey("FK_IssueContent_Issue_IssueId")
                .FromTable("IssueContent").InSchema(Schemas.Dbo).ForeignColumn("IssueId")
                .ToTable(Tables.Issue).InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);
            Create.ForeignKey("FK_IssueContent_File_FileId")
                .FromTable("IssueContent").InSchema(Schemas.Dbo).ForeignColumn(Columns.FileId)
                .ToTable(Tables.File).InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table("IssueContent")
                .InSchema(Schemas.Dbo);
        }
    }
}
