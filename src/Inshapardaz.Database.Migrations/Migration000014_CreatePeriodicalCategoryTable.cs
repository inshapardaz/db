using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000014)]
    public class Migration000014_CreatePeriodicalCategoryTable : Migration
    {
        public override void Up()
        {
            Create.Table("PeriodicalCategory")
                .InSchema("Library")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(int.MaxValue).NotNullable();
        }

        public override void Down()
        {
            Delete.Table("PeriodicalCategory")
                .InSchema("Library");
        }
    }
}