using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000013)]
    public class Migration000013_CreateFavoriteBooksTable : Migration
    {
        public override void Up()
        {
            Create.Table("FavoriteBooks")
                .InSchema("Library")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("BookId").AsInt32().Indexed("IX_FavoriteBooks_BookId")
                .WithColumn("UserId").AsGuid()
                .WithColumn("DateAdded").AsDateTime2();
            Create.ForeignKey("FK_FavoriteBooks_Book_BookId")
                .FromTable("FavoriteBooks").InSchema("Library").ForeignColumn("BookId")
                .ToTable("Book").InSchema("Library").PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table("FavoriteBooks")
                .InSchema("Library");
        }
    }
}
