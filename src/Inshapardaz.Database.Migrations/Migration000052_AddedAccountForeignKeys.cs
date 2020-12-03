using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000052)]
    public class Migration000052_AddedAccountForeignKeys : Migration
    {
        public override void Up()
        {
            Rename.Column("UserId").OnTable(Tables.RecentBooks).InSchema(Schemas.Dbo)
                  .To("AccountId");
            Create.ForeignKey("FK_RecentBooks_Accounts_AccountId")
                .FromTable(Tables.RecentBooks).InSchema(Schemas.Dbo).ForeignColumn("AccountId")
                .ToTable("Accounts").InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);

            Rename.Column("UserId").OnTable(Tables.FavoriteBooks).InSchema(Schemas.Dbo)
                  .To("AccountId");
            Create.ForeignKey("FK_FavoriteBooks_Accounts_AccountId")
                .FromTable(Tables.FavoriteBooks).InSchema(Schemas.Dbo).ForeignColumn("AccountId")
                .ToTable("Accounts").InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);

            Rename.Column("UserId").OnTable(Tables.BookShelf).InSchema(Schemas.Dbo)
                             .To("AccountId");

            Create.ForeignKey("FK_BookShelf_Accounts_AccountId")
                .FromTable(Tables.BookShelf).InSchema(Schemas.Dbo).ForeignColumn("AccountId")
                .ToTable("Accounts").InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);


            Rename.Column("UserId").OnTable(Tables.BookPage).InSchema(Schemas.Dbo)
                             .To("AccountId");

            Create.ForeignKey("FK_BookPage_Accounts_AccountId")
                .FromTable(Tables.BookPage).InSchema(Schemas.Dbo).ForeignColumn("AccountId")
                .ToTable("Accounts").InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.ForeignKey("FK_RecentBooks_Accounts_AccountId").OnTable(Tables.RecentBooks).InSchema(Schemas.Dbo);
            Delete.ForeignKey("FK_FavoriteBooks_Accounts_AccountId").OnTable(Tables.FavoriteBooks).InSchema(Schemas.Dbo);
            Delete.ForeignKey("FK_BookShelf_Accounts_AccountId").OnTable(Tables.BookShelf).InSchema(Schemas.Dbo);
            Delete.ForeignKey("FK_BookPage_Accounts_AccountId").OnTable(Tables.BookPage).InSchema(Schemas.Dbo);

            Rename.Column("AccountId").OnTable(Tables.RecentBooks).InSchema(Schemas.Dbo)
                 .To("UserId");
            Rename.Column("AccountId").OnTable(Tables.FavoriteBooks).InSchema(Schemas.Dbo)
            .To("UserId");
            Rename.Column("AccountId").OnTable(Tables.BookShelf).InSchema(Schemas.Dbo)
                 .To("UserId");
            Rename.Column("AccountId").OnTable(Tables.BookPage).InSchema(Schemas.Dbo)
            .To("UserId");
        }
    }
}
