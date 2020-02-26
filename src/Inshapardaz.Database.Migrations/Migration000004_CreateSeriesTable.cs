using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000004)]
    public class Migration000004_CreateSeriesTable : Migration
    {
        public override void Up()
        {
            Create.Table(Tables.Series)
                .InSchema(Schemas.Library)
                .WithColumn(Columns.Id).AsInt32().PrimaryKey().Identity()
                .WithColumn(Columns.Name).AsString(int.MaxValue).NotNullable()
                .WithColumn(Columns.Description).AsString(int.MaxValue).Nullable()
                .WithColumn(Columns.ImageId).AsInt32().Nullable();
        }

        public override void Down()
        {
            Delete.Table(Tables.Series)
                .InSchema(Schemas.Library);
        }
    }
}
