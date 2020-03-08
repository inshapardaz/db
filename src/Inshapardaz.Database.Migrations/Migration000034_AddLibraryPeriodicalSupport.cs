using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000034)]
    public class Migration000034_AddLibraryPeriodicalSupport : Migration
    {
        public override void Up()
        {
            Alter.Table(Tables.Library).InSchema(Schemas.Library)
                .AddColumn("SupportsPeriodicals").AsBoolean().WithDefaultValue(false);
        }

        public override void Down()
        {
            Delete.Column("SupportsPeriodicals")
                .FromTable(Tables.Library).InSchema(Schemas.Library);
        }
    }
}
