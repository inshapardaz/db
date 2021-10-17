using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000064)]
    public class Migration000064_AddAuthorDescription : Migration
    {
        public override void Up()
        {
             Alter.Table("Author").InSchema(Schemas.Dbo)
                .AddColumn("Description").AsString(int.MaxValue).Nullable();
        }

        public override void Down()
        {
            Delete.Column("Description").FromTable("Author").InSchema(Schemas.Dbo);
        }
    }
}