using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000071)]
    public class Migration000071_AddedChapterAssignment : Migration
    {
        public override void Up()
        {
            Alter.Table(Tables.Chapter).
                InSchema(Schemas.Dbo)
                .AddColumn("Status").AsInt32().WithDefaultValue(0)
                .AddColumn("WriterAccountId").AsGuid().Nullable()
                .AddColumn("WriterAssignTimeStamp").AsDateTime2().Nullable()
                .AddColumn("ReviewerAccountId").AsInt32().Nullable()
                .AddColumn("ReviewerAssignTimeStamp").AsDateTime2().Nullable();
            
        }

        public override void Down()
        {
            Delete.Column("Status").FromTable(Tables.Chapter).InSchema(Schemas.Dbo);
            Delete.Column("WriterAccountId").FromTable(Tables.Chapter).InSchema(Schemas.Dbo);
            Delete.Column("WriterAssignTimeStamp").FromTable(Tables.Chapter).InSchema(Schemas.Dbo);
            Delete.Column("ReviewerAccountId").FromTable(Tables.Chapter).InSchema(Schemas.Dbo);
            Delete.Column("ReviewerAssignTimeStamp").FromTable(Tables.Chapter).InSchema(Schemas.Dbo);
        }
    }
}
