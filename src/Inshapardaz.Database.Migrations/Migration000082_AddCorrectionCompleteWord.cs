using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000082)]
    public class Migration000082_AddCorrectionCompleteWord : Migration
    {
        public override void Up()
        {
            Alter.Table(Tables.Corrections).InSchema(Schemas.Dbo)
                .AddColumn("CompleteWord")
                .AsBoolean()
                .WithDefaultValue(0);
        }

        public override void Down()
        {
            Delete.Column("CompleteWord")
                .FromTable(Tables.Corrections)
                .InSchema(Schemas.Dbo);
        }
    }
}
