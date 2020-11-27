using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000049)]
    public class Migration000049_AddedIdentity : Migration
    {
        public override void Up()
        {
            Create.Table("Accounts").
                InSchema(Schemas.Dbo)
                .WithColumn("Id").AsInt32().PrimaryKey("PK_Accounts").Indexed().Identity()
                .WithColumn("Title").AsString().Nullable()
                .WithColumn("FirstName").AsString().Nullable()
                .WithColumn("LastName").AsString().Nullable()
                .WithColumn("Email").AsString().Nullable()
                .WithColumn("PasswordHash").AsString().Nullable()
                .WithColumn("AcceptTerms").AsBoolean().NotNullable()
                .WithColumn("Role").AsInt32().NotNullable()
                .WithColumn("VerificationToken").AsString().Nullable()
                .WithColumn("Verified").AsDateTime2().Nullable()
                .WithColumn("ResetToken").AsString().Nullable()
                .WithColumn("ResetTokenExpires").AsDateTime2().Nullable()
                .WithColumn("PasswordReset").AsDateTime2().Nullable()
                .WithColumn("Created").AsDateTime2().NotNullable()
                .WithColumn("Updated").AsDateTime2().Nullable();

            Create.Table("RefreshToken")
                .WithColumn("Id").AsInt32().PrimaryKey("PK_RefreshToken").Indexed().Identity()
                .WithColumn("AccountId").AsInt32().NotNullable()
                .WithColumn("Token").AsString().Nullable()
                .WithColumn("Expires").AsDateTime2().NotNullable()
                .WithColumn("Created").AsDateTime2().NotNullable()
                .WithColumn("CreatedByIp").AsString().Nullable()
                .WithColumn("Revoked").AsDateTime2().Nullable()
                .WithColumn("RevokedByIp").AsString().Nullable()
                .WithColumn("ReplacedByToken").AsString().Nullable()
                ;

            Create.ForeignKey("FK_RefreshToken_Accounts_AccountId")
                  .FromTable("RefreshToken").InSchema(Schemas.Dbo).ForeignColumn("AccountId")
                  .ToTable("Accounts").InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                  .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table("RefreshToken").InSchema(Schemas.Dbo);
            Delete.Table("Accounts").InSchema(Schemas.Dbo);
        }
    }
}
