using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000038)]
    public class Migration000038_AddedBookContentLanguage : Migration
    {
        public override void Up()
        {
            Rename.Table(Tables.BookFile).InSchema(Schemas.Library)
                .To(Tables.BookContent);
            Alter.Table(Tables.BookContent).InSchema(Schemas.Library)
                .AddColumn("Language").AsString().Nullable();
        }

        public override void Down()
        {
            Delete.Column("Language")
                .FromTable(Tables.BookContent).InSchema(Schemas.Library);

            Rename.Table(Tables.BookContent).InSchema(Schemas.Library)
                .To(Tables.BookFile);
        }
    }
}