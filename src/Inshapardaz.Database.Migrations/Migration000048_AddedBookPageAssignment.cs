using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000048)]
    public class Migration000048_AddedBookPageAssignment : Migration
    {
        public override void Up()
        {
            Alter.Table(Tables.BookPage).
                InSchema(Schemas.Dbo)
                .AddColumn("Status").AsInt32().WithDefaultValue(0)
                .AddColumn("UserId").AsGuid().Nullable()
                .AddColumn("AssignTimeStamp").AsDateTime2().Nullable();
        }

        public override void Down()
        {
            Delete.Column("Status").FromTable(Tables.BookPage).InSchema(Schemas.Dbo);
            Delete.Column("UserId").FromTable(Tables.BookPage).InSchema(Schemas.Dbo);
            Delete.Column("AssignTimeStamp").FromTable(Tables.BookPage).InSchema(Schemas.Dbo);
        }
    }
}
