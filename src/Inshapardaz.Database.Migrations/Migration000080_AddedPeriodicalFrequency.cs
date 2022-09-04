using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000080)]
    public class Migration000080_AddedPeriodicalFrequency : Migration
    {
        public override void Up()
        {
            Create.Column("Frequency")
                  .OnTable("Periodical").InSchema(Schemas.Dbo)
                  .AsInt32().WithDefaultValue(0);
        }

        public override void Down()
        {
            Delete.Column("Frequency").FromTable("Periodical").InSchema(Schemas.Dbo);        }
    }
}
