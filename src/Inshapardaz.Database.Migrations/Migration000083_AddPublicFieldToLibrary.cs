using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000083)]
    public class Migration000083_AddPublicFieldToLibrary : Migration
    {
        public override void Up()
        {
            Alter.Table(Tables.Library).InSchema(Schemas.Dbo)
                .AddColumn("Public")
                .AsBoolean()
                .WithDefaultValue(0);
        }

        public override void Down()
        {
            Delete.Column("Public")
                .FromTable(Tables.Library)
                .InSchema(Schemas.Dbo);
        }
    }
}
