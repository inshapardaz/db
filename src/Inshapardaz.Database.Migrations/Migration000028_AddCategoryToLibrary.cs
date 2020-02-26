using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000028)]
    public class Migration000028_AddCategoryToLibrary : Migration
    {
        public override void Up()
        {
            Alter.Table(Tables.Category).InSchema(Schemas.Library)
                 .AddColumn("LibraryId")
                 .AsInt32()
                 .Nullable();
            
            Create.ForeignKey("FK_Category_Library")
                  .FromTable(Tables.Category).InSchema(Schemas.Library).ForeignColumn("LibraryId")
                  .ToTable(Tables.Library).InSchema(Schemas.Library).PrimaryColumn(Columns.Id)
                  .OnDelete(System.Data.Rule.SetNull);
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_Category_Library").OnTable(Tables.Category).InSchema(Schemas.Library);
            Delete.Column("LibraryId").FromTable(Tables.Category).InSchema(Schemas.Library);
        }
    }
}
