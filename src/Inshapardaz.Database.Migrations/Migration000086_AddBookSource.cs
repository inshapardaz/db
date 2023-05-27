using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000086)]
    public class Migration000086_AddBookSource : Migration
    {
        public override void Up()
        {
            Alter.Table(Tables.Book).InSchema(Schemas.Dbo)
                .AddColumn("Source")
                .AsString()
                .Indexed("IDX_Book_Source")
                .Nullable();
        }

        public override void Down()
        {
            Delete.Index("IDX_Book_Source")
                  .OnTable(Tables.Book)
                  .InSchema(Schemas.Dbo)
                  .OnColumn("Source");
            Delete.Column("Source")
                .FromTable(Tables.Book)
                .InSchema(Schemas.Dbo);
        }
    }
}
