using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000021)]
    public class Migration000021_CreateSeriesConstraints : Migration
    {
        public override void Up()
        {
            Alter.Column(Columns.Name).OnTable(Tables.Series).InSchema(Schemas.Library)
                 .AsString(256);
            Alter.Column(Columns.Name).OnTable(Tables.Series).InSchema(Schemas.Library)
                 .AsString(256)
                 .Indexed("IDX_Series_Name");

            Create.ForeignKey("FK_Series_Image")
                  .FromTable(Tables.Series).InSchema(Schemas.Library).ForeignColumn(Columns.ImageId)
                  .ToTable(Tables.File).InSchema(Schemas.Inshapardaz).PrimaryColumn(Columns.Id)
                  .OnDelete(System.Data.Rule.SetDefault);
        }

        public override void Down()
        {
            Delete.Index("IDX_Series_Name").OnTable(Tables.Series).InSchema(Schemas.Library)
                  .OnColumn("Name");

            Alter.Column(Columns.Name).OnTable(Tables.Series).InSchema(Schemas.Library)
                 .AsString(int.MaxValue);

            Delete.ForeignKey("FK_Series_Image").OnTable(Tables.Series).InSchema(Schemas.Library);
        }
    }
}
