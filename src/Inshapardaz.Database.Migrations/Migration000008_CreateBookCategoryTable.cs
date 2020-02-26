using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000008)]
    public class Migration000008_CreateBookCategoryTable : Migration
    {
        public override void Up()
        {
            Create.Table(Tables.BookCategory)
                .InSchema(Schemas.Library)
                .WithColumn(Columns.BookId).AsInt32()
                .WithColumn("CategoryId").AsInt32().Indexed("IX_BookCategory_CategoryId");

            Create.PrimaryKey("PK_BookCategory")
                .OnTable(Tables.BookCategory).WithSchema(Schemas.Library)
                .Columns(Columns.BookId, "CategoryId");
            Create.ForeignKey("FK_BookCategory_Category_CategoryId")
                .FromTable(Tables.BookCategory).InSchema(Schemas.Library).ForeignColumn("CategoryId")
                .ToTable(Tables.Category).InSchema(Schemas.Library).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);
            Create.ForeignKey("FK_BookCategory_Book_BookId")
                .FromTable(Tables.BookCategory).InSchema(Schemas.Library).ForeignColumn(Columns.BookId)
                .ToTable(Tables.Book).InSchema(Schemas.Library).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table(Tables.BookCategory)
                .InSchema(Schemas.Library);
        }
    }
}
