using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000051)]
    public class Migration000051_AddedLibraryUser : Migration
    {
        public override void Up()
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

        public override void Down()
        {
            Delete.Table("LibraryUser").InSchema(Schemas.Dbo);
        }
    }
}
