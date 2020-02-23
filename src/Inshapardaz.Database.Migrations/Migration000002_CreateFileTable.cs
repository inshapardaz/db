using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000002)]
    public class Migration000002_CreateFileTable : Migration
    {
        public override void Up()
        {
            Create.Table("File")
                .InSchema("Inshapardaz")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("DateCreated").AsDateTime2()
                .WithColumn("FileName").AsString(int.MaxValue).Nullable()
                .WithColumn("MimeType").AsString(int.MaxValue).Nullable()
                .WithColumn("FilePath").AsString(int.MaxValue).Nullable()
                .WithColumn("IsPublic").AsBoolean().WithDefaultValue(0);
        }

        public override void Down()
        {
            Delete.Table("File")
                .InSchema("Inshapardaz");
        }
    }
}
