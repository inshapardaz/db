using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000085)]
    public class Migration000085_AddBookShelfPublic : Migration
    {
        public override void Up()
        {
            Alter.Table(Tables.BookShelf).InSchema(Schemas.Dbo)
                .AddColumn(Columns.Name)
                .AsString()
                .AddColumn(Columns.Description)
                .AsString().Nullable()
                .AddColumn(Columns.IsPublic)
                .AsBoolean().Nullable()
                .AddColumn(Columns.ImageId)
                .AsInt32().Nullable(); ;
            Alter.Table(Tables.BookShelfBook).InSchema(Schemas.Dbo)
                .AddColumn("Index")
                .AsInt32().Nullable();
        }

        public override void Down()
        {
            Delete.Column(Columns.IsPublic)
                .Column(Columns.Name)
                .Column(Columns.Description)
                .Column(Columns.ImageId)
                .FromTable(Tables.BookShelf)
                .InSchema(Schemas.Dbo);
            Delete.Column("Index")
                .FromTable(Tables.BookShelfBook)
                .InSchema(Schemas.Dbo);
        }
    }
}
