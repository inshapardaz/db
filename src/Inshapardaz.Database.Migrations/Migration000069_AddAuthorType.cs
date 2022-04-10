using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000069)]
    public class Migration000069_AddAuthorType : Migration
    {
        public override void Up()
        {
            Alter.Table(Tables.Author).InSchema(Schemas.Dbo)
                .AddColumn("AuthorType").AsInt32().WithDefaultValue(0).Nullable();
        }

        public override void Down()
        {
            Delete.Column("AuthorType").FromTable(Tables.Author).InSchema(Schemas.Dbo);
        }
    }
}