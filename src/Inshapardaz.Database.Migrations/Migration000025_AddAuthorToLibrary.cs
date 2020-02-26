using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000025)]
    public class Migration000025_AddAuthorToLibrary : Migration
    {
        public override void Up()
        {
            Alter.Table(Tables.Author).InSchema(Schemas.Library)
                 .AddColumn("LibraryId")
                 .AsInt32()
                 .Nullable();
            
            Create.ForeignKey("FK_Author_Library")
                  .FromTable(Tables.Author).InSchema(Schemas.Library).ForeignColumn("LibraryId")
                  .ToTable(Tables.Library).InSchema(Schemas.Library).PrimaryColumn(Columns.Id)
                  .OnDelete(System.Data.Rule.SetNull);
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_Author_Library").OnTable(Tables.Author).InSchema(Schemas.Library);
            Delete.Column("LibraryId").FromTable(Tables.Author).InSchema(Schemas.Library);
        }
    }
}
