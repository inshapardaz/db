using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000019)]
    public class Migration000019_CreateBookPageTable : Migration
    {
        public override void Up()
        {
            Create.Table("BookPage")
                .InSchema("Library")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("BookId").AsInt32().NotNullable().Indexed("IX_BookPage_BookId")
                .WithColumn("Text").AsString(int.MaxValue).Nullable()
                .WithColumn("PageNumber").AsInt32().Nullable()
                .WithColumn("PageUrl").AsString(int.MaxValue).Nullable();

            Create.ForeignKey("FK_BookPage_Book_BookId")
                .FromTable("BookPage").InSchema("Library").ForeignColumn("BookId")
                .ToTable("Book").InSchema("Library").PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table("BookPage")
                .InSchema("Library");
        }
    }
}
