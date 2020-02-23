using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000008)]
    public class Migration000008_CreateBookCategoryTable : Migration
    {
        public override void Up()
        {
            Create.Table("BookCategory")
                .InSchema("Library")
                .WithColumn("BookId").AsInt32()
                .WithColumn("CategoryId").AsInt32().Indexed("IX_BookCategory_CategoryId");

            Create.PrimaryKey("PK_BookCategory")
                .OnTable("BookCategory").WithSchema("Library")
                .Columns("BookId", "CategoryId");
            Create.ForeignKey("FK_BookCategory_Category_CategoryId")
                .FromTable("BookCategory").InSchema("Library").ForeignColumn("CategoryId")
                .ToTable("Category").InSchema("Library").PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade);
            Create.ForeignKey("FK_BookCategory_Book_BookId")
                .FromTable("BookCategory").InSchema("Library").ForeignColumn("BookId")
                .ToTable("Book").InSchema("Library").PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table("BookCategory")
                .InSchema("Library");
        }
    }
}
