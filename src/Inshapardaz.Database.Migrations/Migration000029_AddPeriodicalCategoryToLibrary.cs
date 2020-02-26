using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000029)]
    public class Migration000029_AddPeriodicalCategoryCategoryToLibrary : Migration
    {
        public override void Up()
        {
            Alter.Table(Tables.PeriodicalCategory).InSchema(Schemas.Library)
                 .AddColumn("LibraryId")
                 .AsInt32()
                 .Nullable();
            
            Create.ForeignKey("FK_PeriodicalCategory_Library")
                  .FromTable(Tables.PeriodicalCategory).InSchema(Schemas.Library).ForeignColumn("LibraryId")
                  .ToTable(Tables.Library).InSchema(Schemas.Library).PrimaryColumn(Columns.Id)
                  .OnDelete(System.Data.Rule.SetNull);
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_PeriodicalCategory_Library").OnTable(Tables.PeriodicalCategory).InSchema(Schemas.Library);
            Delete.Column("LibraryId").FromTable(Tables.PeriodicalCategory).InSchema(Schemas.Library);
        }
    }
}
