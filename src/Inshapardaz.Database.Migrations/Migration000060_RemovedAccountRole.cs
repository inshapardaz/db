using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000060)]
    public class Migration000060_RemovedAccountRole : Migration
    {
        public override void Up()
        {
            Delete.Column("Role").FromTable("Accounts").InSchema(Schemas.Dbo);
        }

        public override void Down()
        {
            Alter.Table("Account").InSchema(Schemas.Dbo)
                .AddColumn("Role").AsInt32().NotNullable();
        }
    }
}