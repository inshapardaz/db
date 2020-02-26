using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000016)]
    public class Migration000016_CreateIssueTable : Migration
    {
        public override void Up()
        {
            Create.Table(Tables.Issue)
                .InSchema(Schemas.Library)
                .WithColumn(Columns.Id).AsInt32().PrimaryKey().Identity()
                .WithColumn("PeriodicalId").AsInt32().NotNullable().WithDefaultValue(0).Indexed("IX_Issue_PeriodicalId")
                .WithColumn("Volumenumber").AsInt32().NotNullable()
                .WithColumn("IssueNumber").AsInt32().NotNullable()
                .WithColumn(Columns.ImageId).AsInt32().Nullable()
                .WithColumn("IssueDate").AsDateTime2().NotNullable();

            Create.ForeignKey("FK_Issue_Periodical_PeriodicalId")
                .FromTable(Tables.Issue).InSchema(Schemas.Library).ForeignColumn("PeriodicalId")
                .ToTable(Tables.Periodical).InSchema(Schemas.Library).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table(Tables.Issue)
                .InSchema(Schemas.Library);
        }
    }
}