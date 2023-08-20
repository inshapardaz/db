using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000089)]
    public class Migration000089_AddBookPublisher : Migration
    {
        public override void Up()
        {
            Alter.Table(Tables.Book).InSchema(Schemas.Dbo)
                .AddColumn("Publisher")
                .AsString()
                .Indexed("IDX_Book_Publisher")
                .Nullable();
        }

        public override void Down()
        {
            Delete.Index("IDX_Book_Publisher")
                  .OnTable(Tables.Book)
                  .InSchema(Schemas.Dbo)
                  .OnColumn("Publisher");
            Delete.Column("Publisher")
                .FromTable(Tables.Book)
                .InSchema(Schemas.Dbo);
        }
    }
}
