using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000011)]
    public class Migration000011_CreateBookFileTable : Migration
    {
        public override void Up()
        {
            Create.Table(Tables.BookFile)
                .InSchema(Schemas.Library)
                .WithColumn(Columns.Id).AsInt32().PrimaryKey().Identity()
                .WithColumn(Columns.BookId).AsInt32().Indexed("IX_BookFile_BookId")
                .WithColumn(Columns.FileId).AsInt32().Indexed("IX_BookFile_FileId");

            Create.ForeignKey("FK_BookFile_Book_BookId")
                .FromTable(Tables.BookFile).InSchema(Schemas.Library).ForeignColumn(Columns.BookId)
                .ToTable(Tables.Book).InSchema("Library").PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);
            Create.ForeignKey("FK_BookFile_File_FileId")
                .FromTable(Tables.BookFile).InSchema(Schemas.Library).ForeignColumn(Columns.FileId)
                .ToTable(Tables.File).InSchema(Schemas.Inshapardaz).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table(Tables.BookFile)
                .InSchema(Schemas.Library);
        }
    }
}
