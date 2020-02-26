using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000001)]
    public class Migration000001_CreateLibrarySchema : Migration
    {
        public override void Up()
        {
            Create.Schema(Schemas.Library);
            Create.Schema(Schemas.Inshapardaz);
        }

        public override void Down()
        {
            Delete.Schema(Schemas.Library);
            Delete.Schema(Schemas.Inshapardaz);
        }
    }
}
