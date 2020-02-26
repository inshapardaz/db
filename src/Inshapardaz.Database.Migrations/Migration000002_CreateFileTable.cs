using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000002)]
    public class Migration000002_CreateFileTable : Migration
    {
        public override void Up()
        {
            Create.Table(Tables.File)
                .InSchema(Schemas.Inshapardaz)
                .WithColumn(Columns.Id).AsInt32().PrimaryKey().Identity()
                .WithColumn(Columns.DateCreated).AsDateTime2()
                .WithColumn("FileName").AsString(int.MaxValue).Nullable()
                .WithColumn("MimeType").AsString(int.MaxValue).Nullable()
                .WithColumn("FilePath").AsString(int.MaxValue).Nullable()
                .WithColumn(Columns.IsPublic).AsBoolean().WithDefaultValue(0);
        }

        public override void Down()
        {
            Delete.Table(Tables.File)
                .InSchema(Schemas.Inshapardaz);
        }
    }
}
