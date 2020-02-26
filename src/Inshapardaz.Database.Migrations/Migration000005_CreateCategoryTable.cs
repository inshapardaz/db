using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000005)]
    public class Migration000005_CreateCategoryTable : Migration
    {
        public override void Up()
        {
            Create.Table(Tables.Category)
                .InSchema(Schemas.Library)
                .WithColumn(Columns.Id).AsInt32().PrimaryKey().Identity()
                .WithColumn(Columns.Name).AsString(int.MaxValue).NotNullable();
        }

        public override void Down()
        {
            Delete.Table(Tables.Category)
                .InSchema(Schemas.Library);
        }
    }
}
