using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000061)]
    public class Migration000061_RemovedLibraryUser : Migration
    {
        public override void Up()
        {
            Delete.ForeignKey("FK_LibraryUser_Library_LibraryId").OnTable("LibraryUser").InSchema(Schemas.Dbo);
            Delete.ForeignKey("FK_LibraryUser_Accounts_AccountId").OnTable("LibraryUser").InSchema(Schemas.Dbo);
            Delete.Table("LibraryUser").InSchema(Schemas.Dbo);
        }

        public override void Down()
        {
            Create.Table("LibraryUser").
                InSchema(Schemas.Dbo)
                .WithColumn("LibraryId").AsInt32().NotNullable()
                .WithColumn("AccountId").AsInt32().NotNullable();

            Create.PrimaryKey("PK_LibraryUser").OnTable("LibraryUser").WithSchema(Schemas.Dbo)
                .Columns("LibraryId", "AccountId");

            Create.ForeignKey("FK_LibraryUser_Library_LibraryId")
                              .FromTable("LibraryUser").InSchema(Schemas.Dbo).ForeignColumn("LibraryId")
                              .ToTable(Tables.Library).InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                              .OnDelete(System.Data.Rule.Cascade);

            Create.ForeignKey("FK_LibraryUser_Accounts_AccountId")
                  .FromTable("LibraryUser").InSchema(Schemas.Dbo).ForeignColumn("AccountId")
                  .ToTable("Accounts").InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                  .OnDelete(System.Data.Rule.Cascade);
        }
    }
}