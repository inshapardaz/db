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
            .WithColumn("Language").AsString().Indexed("IDX_CORRECTION_LANGUAGE")
            .WithColumn("AutoCorrect").AsBoolean().WithDefaultValue(false)
            .WithColumn("Punctuation").AsBoolean().WithDefaultValue(false)
            .WithColumn("IncorrectText").AsString().NotNullable()
            .WithColumn("CorrectText").AsString().NotNullable()
            .WithColumn("Usage").AsInt64().WithDefaultValue(0);

            Create.PrimaryKey("PK_Corrections").OnTable(Tables.Corrections).WithSchema(Schemas.Dbo)
                .Columns("Language", "AutoCorrect", "Punctuation", "IncorrectText");
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