using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000027)]
    public class Migration000027_AddSeriesToLibrary : Migration
    {
        public override void Up()
        {
            Alter.Table(Tables.Series).InSchema(Schemas.Library)
                 .AddColumn("LibraryId")
                 .AsInt32()
                 .Nullable();
            
            Create.ForeignKey("FK_Series_Library")
                  .FromTable(Tables.Series).InSchema(Schemas.Library).ForeignColumn("LibraryId")
                  .ToTable(Tables.Library).InSchema(Schemas.Library).PrimaryColumn(Columns.Id)
                  .OnDelete(System.Data.Rule.SetNull);
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_Series_Library").OnTable(Tables.Series).InSchema(Schemas.Library);
            Delete.Column("LibraryId").FromTable(Tables.Series).InSchema(Schemas.Library);
        }
    }
}
