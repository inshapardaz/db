using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000011)]
    public class Migration000011_CreateBookFileTable : Migration
    {
        public override void Up()
        {
            Create.Table("BookFile")
                .InSchema("Library")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("BookId").AsInt32().Indexed("IX_BookFile_BookId")
                .WithColumn("FileId").AsInt32().Indexed("IX_BookFile_FileId");

            Create.ForeignKey("FK_BookFile_Book_BookId")
                .FromTable("BookFile").InSchema("Library").ForeignColumn("BookId")
                .ToTable("Book").InSchema("Library").PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade);
            Create.ForeignKey("FK_BookFile_File_FileId")
                .FromTable("BookFile").InSchema("Library").ForeignColumn("FileId")
                .ToTable("File").InSchema("Inshapardaz").PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table("BookFile")
                .InSchema("Library");
        }
    }
}
