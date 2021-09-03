using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000059)]
    public class Migration000059_AddedAccountLibrary : Migration
    {
        public override void Up()
        {
            Alter.Table("Accounts").InSchema(Schemas.Dbo)
                .AddColumn("Name").AsString().Nullable()
                .AddColumn("IsSuperAdmin").AsBoolean().WithDefaultValue(false)
                .AddColumn("InvitationCode").AsString().Nullable()
                .AddColumn("InvitationCodeExpiry").AsDateTime2().Nullable();

            Create.Table("AccountLibrary").InSchema(Schemas.Dbo)
                .WithColumn("AccountId").AsInt32().ForeignKey("FK_Accounts_AccountLibrary", "Accounts", "Id")
                        .OnDelete(System.Data.Rule.Cascade)
                        .OnUpdate(System.Data.Rule.None)
                .WithColumn("LibraryId").AsInt32().ForeignKey("FK_Library_AccountLibrary", "Library", "Id")
                        .OnDelete(System.Data.Rule.Cascade)
                        .OnUpdate(System.Data.Rule.None)
                .WithColumn("Role").AsInt32().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("AccountLibrary").InSchema(Schemas.Dbo);
            Delete.Column("Name").FromTable("Accounts").InSchema(Schemas.Dbo);
            Delete.Column("IsSuperAdmin").FromTable("Accounts").InSchema(Schemas.Dbo);
            Delete.Column("InvitationCode").FromTable("Accounts").InSchema(Schemas.Dbo);
            Delete.Column("InvitationCodeExpiry").FromTable("Accounts").InSchema(Schemas.Dbo);
        }
    }
}