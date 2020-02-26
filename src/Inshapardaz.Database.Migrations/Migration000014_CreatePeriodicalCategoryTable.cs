using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000014)]
    public class Migration000014_CreatePeriodicalCategoryTable : Migration
    {
        public override void Up()
        {
            Create.Table(Tables.PeriodicalCategory)
                .InSchema(Schemas.Library)
                .WithColumn(Columns.Id).AsInt32().PrimaryKey().Identity()
                .WithColumn(Columns.Name).AsString(int.MaxValue).NotNullable();
        }

        public override void Down()
        {
            Delete.Table(Tables.PeriodicalCategory)
                .InSchema(Schemas.Library);
        }
    }
}