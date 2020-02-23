using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000001)]
    public class Migration000001_CreateLibrarySchema : Migration
    {
        public override void Up()
        {
            Create.Schema("Library");
            Create.Schema("Inshapardaz");
        }

        public override void Down()
        {
            Delete.Schema("Library");
            Delete.Schema("Inshapardaz");
        }
    }
}
