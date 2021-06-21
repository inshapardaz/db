using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000058)]
    public class Migration000058_AddCorrections : Migration
    {
        public override void Up()
        {
            Create.Table("Corrections").InSchema(Schemas.Dbo)
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("language").AsString(10).Indexed()
                .WithColumn("phrase").AsString(50)
                .WithColumn("replacement").AsString(50);
        }

        public override void Down()
        {
            Delete.Table("Corrections").InSchema(Schemas.Dbo);
        }
    }
}