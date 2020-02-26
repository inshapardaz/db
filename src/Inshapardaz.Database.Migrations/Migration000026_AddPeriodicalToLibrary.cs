using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000026)]
    public class Migration000026_AddPeriodicalToLibrary : Migration
    {
        public override void Up()
        {
            Alter.Table(Tables.Periodical).InSchema(Schemas.Library)
                 .AddColumn("LibraryId")
                 .AsInt32()
                 .Nullable();
            
            Create.ForeignKey("FK_Periodical_Library")
                  .FromTable(Tables.Periodical).InSchema(Schemas.Library).ForeignColumn("LibraryId")
                  .ToTable(Tables.Library).InSchema(Schemas.Library).PrimaryColumn(Columns.Id)
                  .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_Periodical_Library").OnTable(Tables.Periodical).InSchema(Schemas.Library);
            Delete.Column("LibraryId").FromTable(Tables.Periodical).InSchema(Schemas.Library);
        }
    }
}
