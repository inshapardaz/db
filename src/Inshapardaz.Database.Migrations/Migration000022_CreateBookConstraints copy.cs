using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000024)]
    public class Migration000024_CreateBookToLibrary : Migration
    {
        public override void Up()
        {
            Alter.Table(Tables.Book).InSchema(Schemas.Library)
                 .AddColumn("LibraryId")
                 .AsInt32();
            
            Create.ForeignKey("FK_Book_Library")
                  .FromTable(Tables.Book).InSchema(Schemas.Library).ForeignColumn("LibraryId")
                  .ToTable(Tables.Library).InSchema(Schemas.Library).PrimaryColumn(Columns.Id)
                  .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_Book_Library").OnTable(Tables.Book).InSchema(Schemas.Library);
            Delete.Column("LibraryId").FromTable(Tables.Book).InSchema(Schemas.Library);
        }
    }
}
