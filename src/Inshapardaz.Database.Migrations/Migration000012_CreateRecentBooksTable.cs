using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000012)]
    public class Migration000012_CreateRecentBooksTable : Migration
    {
        public override void Up()
        {
            Create.Table("RecentBooks")
                .InSchema("Library")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("BookId").AsInt32().Indexed("IX_RecentBooks_BookId")
                .WithColumn("UserId").AsGuid()
                .WithColumn("DateRead").AsDateTime2();
            Create.ForeignKey("FK_RecentBooks_Book_BookId")
                .FromTable("RecentBooks").InSchema("Library").ForeignColumn("BookId")
                .ToTable("Book").InSchema("Library").PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table("RecentBooks")
                .InSchema("Library");
        }
    }
}
