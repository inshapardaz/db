using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000044)]
    public class Migration000044_AddedFileData : Migration
    {
        public override void Up()
        {
            Create.Table("FileData")
            .InSchema(Schemas.Dbo)
            .WithColumn("Path").AsString().PrimaryKey()
            .WithColumn("Content").AsByte();
        }

        public override void Down()
        {
            Delete.Table("FileData").InSchema(Schemas.Dbo);
        }
    }
}
