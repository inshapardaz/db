using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000087)]
    public class Migration000087_AddLibraryImageAndDescription : Migration
    {
        public override void Up()
        {
            Alter.Table(Tables.Library)
                .InSchema(Schemas.Dbo)
                .AddColumn("Description")
                    .AsString()
                    .Nullable()
                .AddColumn(Columns.ImageId).AsInt32().Nullable();

            Create.ForeignKey("FK_Library_Image")
                  .FromTable(Tables.Library).InSchema(Schemas.Dbo).ForeignColumn(Columns.ImageId)
                  .ToTable(Tables.File).InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                  .OnDelete(System.Data.Rule.SetDefault);
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_Library_Image")
                  .OnTable(Tables.Library)
                  .InSchema(Schemas.Dbo);

            Delete.Column("Description")
                .FromTable(Tables.Library)
                .InSchema(Schemas.Dbo);
            Delete.Column(Columns.ImageId)
                .FromTable(Tables.Library)
                .InSchema(Schemas.Dbo);
        }
    }
}
