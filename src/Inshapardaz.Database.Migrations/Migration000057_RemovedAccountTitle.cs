using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000057)]
    public class Migration000057_RemovedAccountTitle : Migration
    {
        public override void Up()
        {
            Delete.Column("Title").FromTable("Accounts").InSchema(Schemas.Dbo);
        }

        public override void Down()
        {
            Alter.Table("Accounts").InSchema(Schemas.Dbo)
                .AddColumn("Title").AsString().Nullable();
        }
    }
}