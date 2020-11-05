using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000047)]
    public class Migration000047_RenameBookPageNumber : Migration
    {
        public override void Up()
        {
            Rename.Column("PageNumber").OnTable(Tables.BookPage).To("SequenceNumber");
        }

        public override void Down()
        {
            Rename.Column("SequenceNumber").OnTable(Tables.BookPage).To("PageNumber");
        }
    }
}
