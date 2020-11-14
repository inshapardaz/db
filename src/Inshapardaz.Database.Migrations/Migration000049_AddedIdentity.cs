using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000049)]
    public class Migration000049_AddedIdentity : Migration
    {
        public override void Up()
        {
            Create.Table("AspNetRoles").InSchema(Schemas.Dbo)
                  .WithColumn("Id").AsString().PrimaryKey("PK_AspNetRoles")
                  .WithColumn("Name").AsString(256).Nullable()
                  .WithColumn("NormalizedName").AsString(256).Nullable()
                  .WithColumn("ConcurrencyStamp").AsDateTime2().Nullable();

            Create.Table("AspNetUsers").InSchema(Schemas.Dbo)
                  .WithColumn("Id").AsString().PrimaryKey("PK_AspNetUsers")
                  .WithColumn("UserName").AsString(256).Nullable()
                  .WithColumn("NormalizedUserName").AsString(256).Nullable()
                  .WithColumn("Email").AsString(256).Nullable()
                  .WithColumn("NormalizedEmail").AsString(256).Nullable()
                  .WithColumn("EmailConfirmed").AsBoolean().NotNullable()
                  .WithColumn("PasswordHash").AsString().Nullable()
                  .WithColumn("SecurityStamp").AsString().Nullable()
                  .WithColumn("ConcurrencyStamp").AsString().Nullable()
                  .WithColumn("PhoneNumber").AsString().Nullable()
                  .WithColumn("PhoneNumberConfirmed").AsBoolean().NotNullable()
                  .WithColumn("TwoFactorEnabled").AsBoolean().NotNullable()
                  .WithColumn("LockoutEnd").AsDateTime2().Nullable()
                  .WithColumn("LockoutEnabled").AsBoolean().NotNullable()
                  .WithColumn("AccessFailedCount").AsInt32().NotNullable();

            Create.Table("DeviceCodes").InSchema(Schemas.Dbo)
                  .WithColumn("UserCode").AsString(200).PrimaryKey("PK_DeviceCodes")
                  .WithColumn("DeviceCode").AsString(200).NotNullable()
                  .WithColumn("SubjectId").AsString(200).Nullable()
                  .WithColumn("ClientId").AsString(200).NotNullable()
                  .WithColumn("CreationTime").AsDateTime2().NotNullable()
                  .WithColumn("Expiration").AsDateTime2().NotNullable()
                  .WithColumn("Data").AsString(50000).NotNullable();

            Create.Table("PersistedGrants").InSchema(Schemas.Dbo)
                  .WithColumn("Key").AsString(200).PrimaryKey("PK_PersistedGrants")
                  .WithColumn("Type").AsString(50).NotNullable()
                  .WithColumn("SubjectId").AsString(200).Nullable()
                  .WithColumn("ClientId").AsString(200).NotNullable()
                  .WithColumn("CreationTime").AsDateTime2().NotNullable()
                  .WithColumn("Expiration").AsDateTime2().Nullable()
                  .WithColumn("Data").AsString(50000).NotNullable();

            Create.Table("AspNetRoleClaims").InSchema(Schemas.Dbo)
                  .WithColumn("Id").AsInt32().PrimaryKey("PK_AspNetRoleClaims").Identity()
                  .WithColumn("RoleId").AsString().NotNullable()
                  .WithColumn("ClaimType").AsString().Nullable()
                  .WithColumn("ClaimValue").AsString().Nullable();

            Create.ForeignKey("FK_AspNetRoleClaims_AspNetRoles_RoleId")
                .FromTable("AspNetRoleClaims").InSchema(Schemas.Dbo).ForeignColumn("RoleId")
                .ToTable("AspNetRoles").InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);

            Create.Table("AspNetUserClaims").InSchema(Schemas.Dbo)
                  .WithColumn("Id").AsInt32().PrimaryKey("PK_AspNetUserClaims").Identity()
                  .WithColumn("UserId").AsString().NotNullable()
                  .WithColumn("ClaimType").AsString().Nullable()
                  .WithColumn("ClaimValue").AsString().Nullable();

            Create.ForeignKey("FK_AspNetUserClaims_AspNetUsers_UserId")
                .FromTable("AspNetUserClaims").InSchema(Schemas.Dbo).ForeignColumn("UserId")
                .ToTable("AspNetUsers").InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);

            Create.Table("AspNetUserLogins").InSchema(Schemas.Dbo)
                  .WithColumn("LoginProvider").AsString(128)
                  .WithColumn("ProviderKey").AsString(128)
                  .WithColumn("ProviderDisplayName").AsString().Nullable()
                  .WithColumn("UserId").AsString().NotNullable();

            Create.PrimaryKey("PK_AspNetUserLogins")
                  .OnTable("AspNetUserLogins")
                  .Columns("LoginProvider", "ProviderKey");

            Create.ForeignKey("FK_AspNetUserLogins_AspNetUsers_UserId")
                .FromTable("AspNetUserLogins").InSchema(Schemas.Dbo).ForeignColumn("UserId")
                .ToTable("AspNetUsers").InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);

            Create.Table("AspNetUserRoles").InSchema(Schemas.Dbo)
                  .WithColumn("UserId").AsString().NotNullable()
                  .WithColumn("RoleId").AsString().NotNullable();

            Create.PrimaryKey("PK_AspNetUserRoles")
                  .OnTable("AspNetUserRoles")
                  .Columns("UserId", "RoleId");

            Create.ForeignKey("FK_AspNetUserRoles_AspNetRoles_RoleId")
                .FromTable("AspNetUserRoles").InSchema(Schemas.Dbo).ForeignColumn("RoleId")
                .ToTable("AspNetRoles").InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);
            Create.ForeignKey("FK_AspNetUserRoles_AspNetUsers_UserId")
                .FromTable("AspNetUserRoles").InSchema(Schemas.Dbo).ForeignColumn("UserId")
                .ToTable("AspNetUsers").InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);

            Create.Table("AspNetUserTokens").InSchema(Schemas.Dbo)
                .WithColumn("UserId").AsString()
                .WithColumn("LoginProvider").AsString(128)
                .WithColumn("Name").AsString(128).NotNullable()
                .WithColumn("Value").AsString().Nullable();

            Create.PrimaryKey("PK_AspNetUserTokens")
                  .OnTable("AspNetUserTokens")
                  .Columns("UserId", "LoginProvider", "Name");

            Create.ForeignKey("FK_AspNetUserTokens_AspNetUsers_UserId")
                .FromTable("AspNetUserTokens").InSchema(Schemas.Dbo).ForeignColumn("UserId")
                .ToTable("AspNetUsers").InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);

            Create.Index("IX_AspNetRoleClaims_RoleId").OnTable("AspNetRoleClaims").InSchema(Schemas.Dbo).OnColumn("RoleId");
            Create.Index("RoleNameIndex").OnTable("AspNetRoles").InSchema(Schemas.Dbo).OnColumn("NormalizedName").Unique();
            Create.Index("IX_AspNetUserClaims_UserId").OnTable("AspNetUserClaims").InSchema(Schemas.Dbo).OnColumn("UserId");
            Create.Index("IX_AspNetUserLogins_UserId").OnTable("AspNetUserLogins").InSchema(Schemas.Dbo).OnColumn("UserId");
            Create.Index("IX_AspNetUserRoles_RoleId").OnTable("AspNetUserRoles").InSchema(Schemas.Dbo).OnColumn("RoleId");
            Create.Index("EmailIndex").OnTable("AspNetUsers").InSchema(Schemas.Dbo).OnColumn("NormalizedEmail");
            Create.Index("UserNameIndex").OnTable("AspNetUsers").InSchema(Schemas.Dbo).OnColumn("NormalizedUserName").Unique();
            Create.Index("IX_DeviceCodes_DeviceCode").OnTable("DeviceCodes").InSchema(Schemas.Dbo).OnColumn("DeviceCode").Unique();
            Create.Index("IX_DeviceCodes_Expiration").OnTable("DeviceCodes").InSchema(Schemas.Dbo).OnColumn("Expiration");
            Create.Index("IX_PersistedGrants_Expiration").OnTable("PersistedGrants").InSchema(Schemas.Dbo).OnColumn("Expiration");
            Create.Index("IX_PersistedGrants_SubjectId_ClientId_Type").OnTable("PersistedGrants").InSchema(Schemas.Dbo)
                  .OnColumn("SubjectId").Ascending()
                  .OnColumn("ClientId").Ascending()
                  .OnColumn("Type").Ascending();
        }

        public override void Down()
        {
            Delete.Table("AspNetRoleClaims");
            Delete.Table("AspNetUserClaims");
            Delete.Table("AspNetUserLogins");
            Delete.Table("AspNetUserRoles");
            Delete.Table("AspNetUserTokens");
            Delete.Table("DeviceCodes");
            Delete.Table("PersistedGrants");
            Delete.Table("AspNetRoles");
            Delete.Table("AspNetUsers");
        }
    }
}
