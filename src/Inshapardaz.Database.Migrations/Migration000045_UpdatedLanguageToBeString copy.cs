using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000045)]
    public class Migration000045_UpdatedLanguageToBeString : Migration
    {
        public override void Up()
        {
            Alter.Table(Tables.Book)
            .InSchema(Schemas.Dbo)
            .AlterColumn(Columns.Language).AsString(10);
        }

        public override void Down()
        {
            Alter.Table(Tables.Book)
            .InSchema(Schemas.Dbo)
            .AlterColumn(Columns.Language).AsInt32();
        }
    }
}
