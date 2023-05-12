using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000084)]
    public class Migration000084_AddLibrarySettings : Migration
    {
        public override void Up()
        {
            Alter.Table(Tables.Library).InSchema(Schemas.Dbo)
                .AddColumn("DatabaseConnection")
                .AsString().Nullable();
            Alter.Table(Tables.Library).InSchema(Schemas.Dbo)
                .AddColumn("FileStoreType")
                .AsString().WithDefaultValue("Database");
            Alter.Table(Tables.Library).InSchema(Schemas.Dbo)
                .AddColumn("FileStoreSource")
                .AsString();
        }

        public override void Down()
        {
            Delete.Column("DatabaseConnection")
                .FromTable(Tables.Library)
                .InSchema(Schemas.Dbo);
            Delete.Column("FileStoreType")
                .FromTable(Tables.Library)
                .InSchema(Schemas.Dbo);
            Delete.Column("FileStoreSource")
            .FromTable(Tables.Library)
            .InSchema(Schemas.Dbo);
        }
    }
}
