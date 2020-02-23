using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000016)]
    public class Migration000016_CreateIssueTable : Migration
    {
        public override void Up()
        {
            Create.Table("Issue")
                .InSchema("Library")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("PeriodicalId").AsInt32().NotNullable().WithDefaultValue(0).Indexed("IX_Issue_PeriodicalId")
                .WithColumn("Volumenumber").AsInt32().NotNullable()
                .WithColumn("IssueNumber").AsInt32().NotNullable()
                .WithColumn("ImageId").AsInt32().Nullable()
                .WithColumn("IssueDate").AsDateTime2().NotNullable();

            Create.ForeignKey("FK_Issue_Periodical_PeriodicalId")
                .FromTable("Issue").InSchema("Library").ForeignColumn("PeriodicalId")
                .ToTable("Periodical").InSchema("Library").PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table("Issue")
                .InSchema("Library");
        }
    }
}