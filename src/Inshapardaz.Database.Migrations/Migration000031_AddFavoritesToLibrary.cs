using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000031)]
    public class Migration000031_AddFavoritesToLibrary : Migration
    {
        public override void Up()
        {
            Alter.Table(Tables.FavoriteBooks).InSchema(Schemas.Library)
                 .AddColumn("LibraryId")
                 .AsInt32()
                 .Nullable();
            
            Create.ForeignKey("FK_FavoriteBooks_Library")
                  .FromTable(Tables.FavoriteBooks).InSchema(Schemas.Library).ForeignColumn("LibraryId")
                  .ToTable(Tables.Library).InSchema(Schemas.Library).PrimaryColumn(Columns.Id)
                  .OnDelete(System.Data.Rule.None);
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_FavoriteBooks_Library").OnTable(Tables.FavoriteBooks).InSchema(Schemas.Library);
            Delete.Column("LibraryId").FromTable(Tables.FavoriteBooks).InSchema(Schemas.Library);
        }
    }
}
