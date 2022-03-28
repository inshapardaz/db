using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000067)]
    public class Migration000067_AddPageReviewer : Migration
    {
        public override void Up()
        {
            Alter.Table(Tables.BookPage).InSchema(Schemas.Dbo)
                .AddColumn("ReviewerAccoutId").AsGuid().Nullable()
                .AddColumn("ReviewerAssignTimeStamp").AsDateTime2().Nullable();

            Rename.Column("AccountId").OnTable(Tables.BookPage).InSchema(Schemas.Dbo)
                  .To("WriterAccountId");
            Rename.Column("AssignTimeStamp").OnTable(Tables.BookPage).InSchema(Schemas.Dbo)
                  .To("WriterAssignTimeStamp");
        }

        public override void Down()
        {
            Delete.Column("ReviewerAccoutId").FromTable(Tables.BookPage).InSchema(Schemas.Dbo);
            Delete.Column("ReviewerAssignTimeStamp").FromTable(Tables.BookPage).InSchema(Schemas.Dbo);
            Rename.Column("WriterAccountId").OnTable(Tables.BookPage).InSchema(Schemas.Dbo)
                 .To("AccountId");
            Rename.Column("WriterAssignTimeStamp").OnTable(Tables.BookPage).InSchema(Schemas.Dbo)
                  .To("AssignTimeStamp");
        }
    }
}