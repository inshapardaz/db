using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000068)]
    public class Migration000068_AddCorrections : Migration
    {
        public override void Up()
        {
            Delete.Table(Tables.Corrections);
            Create.Table(Tables.Corrections).InSchema(Schemas.Dbo)
                .WithColumn("Id").AsInt64().Identity().PrimaryKey()
                .WithColumn("Language").AsString().Indexed("IDX_CORRECTION_LANGUAGE")
                .WithColumn("Profile").AsString().Indexed("IDX_PROFILE")
                .WithColumn("IncorrectText").AsString().NotNullable()
                .WithColumn("CorrectText").AsString().NotNullable()
                .WithColumn("Usage").AsInt64().WithDefaultValue(0);

        }

        public override void Down()
        {
            Delete.Table(Tables.Corrections).InSchema(Schemas.Dbo);
            Create.Table(Tables.Corrections).InSchema(Schemas.Dbo)
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("language").AsString(10).Indexed()
                .WithColumn("phrase").AsString(50)
                .WithColumn("replacement").AsString(50);
        }
    }
}