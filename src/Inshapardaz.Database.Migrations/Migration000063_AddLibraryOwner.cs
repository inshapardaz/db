using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000063)]
    public class Migration000063_AddLibraryOwner : Migration
    {
        public override void Up()
        {
             Alter.Table("Library").InSchema(Schemas.Dbo)
                .AddColumn("OwnerEmail").AsString().Nullable();
        }

        public override void Down()
        {
            Delete.Column("OwnerEmail").FromTable("Library").InSchema(Schemas.Dbo);

        }
    }
}