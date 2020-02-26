using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000003)]
    public class Migration000003_CreateAuthorsTable : Migration
    {
        public override void Up()
        {
            Create.Table(Tables.Author)
                .InSchema(Schemas.Library)
                .WithColumn(Columns.Id).AsInt32().PrimaryKey().Identity()
                .WithColumn(Columns.Name).AsString(int.MaxValue).NotNullable() 
                .WithColumn(Columns.ImageId).AsInt32().Nullable();
        }

        public override void Down()
        {
            Delete.Table(Tables.Author)
                .InSchema(Schemas.Library);
        }
    }
}
