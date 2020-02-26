using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000023)]
    public class Migration000023_CreateLibrary : Migration
    {
        public override void Up()
        {
            Create.Table(Tables.Library)
                  .InSchema(Schemas.Library)
                  .WithColumn(Columns.Id).AsInt32().PrimaryKey().Identity()
                  .WithColumn(Columns.Name).AsString(256).NotNullable()
                  .WithColumn(Columns.Language).AsString(10).NotNullable().WithDefaultValue("en");
        }

        public override void Down()
        {
            Delete.Table(Tables.Library).InSchema(Schemas.Library);
        }
    }
}
