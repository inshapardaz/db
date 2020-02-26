using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000030)]
    public class Migration000030_AddRecentToLibrary : Migration
    {
        public override void Up()
        {
            Alter.Table(Tables.RecentBooks).InSchema(Schemas.Library)
                 .AddColumn("LibraryId")
                 .AsInt32()
                 .Nullable();
            
            Create.ForeignKey("FK_RecentBooks_Library")
                  .FromTable(Tables.RecentBooks).InSchema(Schemas.Library).ForeignColumn("LibraryId")
                  .ToTable(Tables.Library).InSchema(Schemas.Library).PrimaryColumn(Columns.Id)
                  .OnDelete(System.Data.Rule.None);
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_RecentBooks_Library").OnTable(Tables.RecentBooks).InSchema(Schemas.Library);
            Delete.Column("LibraryId").FromTable(Tables.RecentBooks).InSchema(Schemas.Library);
        }
    }
}
