using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000053)]
    public class Migration000053_AddedLibrarySettings : Migration
    {
        public override void Up()
        {
            Alter.Table(Tables.Library).InSchema(Schemas.Dbo)
                .AddColumn("PrimaryColor").AsString().Nullable()
                .AddColumn("SecondaryColor").AsString().Nullable();
        }

        public override void Down()
        {
            Delete.Column("PrimaryColor").FromTable(Tables.Library).InSchema(Schemas.Dbo);
            Delete.Column("SecondaryColor") .FromTable(Tables.Library).InSchema(Schemas.Dbo);
        }
    }
}
