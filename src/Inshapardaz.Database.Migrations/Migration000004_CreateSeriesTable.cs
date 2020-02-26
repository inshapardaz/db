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
                // TODO : Add index
                //.Indexed("IDX_Name")
                .WithColumn(Columns.Description).AsString(int.MaxValue).Nullable()
                .WithColumn(Columns.ImageId).AsInt32().Nullable();

            // TODO : Add Foreign key
            // Create.ForeignKey()
            //     .FromTable("Series").InSchema(Schemas.Library).ForeignColumn("ImageId")
            //     .ToTable(Tables.File).InSchema(Schemas.Library).PrimaryColumn(Columns.Id)
            //     .OnDelete(System.Data.Rule.SetDefault);
        }

        public override void Down()
        {
            Delete.Table(Tables.Series)
                .InSchema(Schemas.Library);
        }
    }
}
