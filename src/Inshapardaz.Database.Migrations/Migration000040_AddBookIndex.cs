using FluentMigrator;
using System.IO;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000040)]
    public class Migration000040_AddBookIndex : Migration
    {
        public override void Up()
        {
            Create.Index("IDX_Book_1")
                .OnTable(Tables.Book)
                .OnColumn("AuthorId").Ascending()
                .OnColumn("IsPublic").Ascending()
                .OnColumn("SeriesId").Ascending()
                .WithOptions().NonClustered();
        }

        public override void Down()
        {
            Delete.Index("IDX_Book_1").OnTable(Tables.Book);
        }
    }
}