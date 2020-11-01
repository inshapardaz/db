using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000046)]
    public class Migration000046_RenameBookPageUrl : Migration
    {
        public override void Up()
        {
            Rename.Column("PageUrl").OnTable(Tables.BookPage).To(Columns.ImageId);
        }

        public override void Down()
        {
            Rename.Column(Columns.ImageId).OnTable(Tables.BookPage).To("PageUrl");
        }
    }
}
