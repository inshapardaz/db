using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000070)]
    public class Migration000070_AddIssueUniqueConstraint: Migration
    {
        public override void Up()
        {
            Create.UniqueConstraint("UNQ_VOLUME_ISSUE")
                .OnTable(Tables.Issue)
                .WithSchema(Schemas.Dbo)
                .Columns("PeriodicalId","Volumenumber","IssueNumber");
        }

        public override void Down()
        {
            Delete.UniqueConstraint("UNQ_VOLUME_ISSUE")
                .FromTable(Tables.Issue)
                .InSchema(Schemas.Dbo);
        }
    }
}