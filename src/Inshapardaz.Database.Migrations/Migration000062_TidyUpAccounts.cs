using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000062)]
    public class Migration000062_TidyUpAccounts : Migration
    {
        public override void Up()
        {
            Execute.Sql("UPDATE Accounts SET [NAME] = FirstName + ' ' + LastName");
            Delete.Column("FirstName").FromTable("Accounts").InSchema(Schemas.Dbo);
            Delete.Column("LastName").FromTable("Accounts").InSchema(Schemas.Dbo);
        }

        public override void Down()
        {
            Alter.Table("Accounts").InSchema(Schemas.Dbo)
                .AddColumn("FirstName").AsString().Nullable()
                .AddColumn("LastName").AsString().Nullable();
            Execute.Sql("UPDATE Accounts SET FirstName = SUBSTRING([NAME],0,CHARINDEX(' ',[NAME])), LastName = SUBSTRING([NAME],CHARINDEX(' ',[NAME]),LEN([NAME]))");

        }
    }
}