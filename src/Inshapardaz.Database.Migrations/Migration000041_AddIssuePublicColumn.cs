using FluentMigrator;
using System.IO;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000041)]
    public class Migration000041_AddIssuePublicColumn : Migration
    {
        public override void Up()
        {
            Alter.Table(Tables.Issue).InSchema(Schemas.Dbo)
                .AddColumn("IsPublic").AsBoolean().WithDefaultValue(true);
        }

        public override void Down()
        {
            Delete.Column("IsPublic")
                .FromTable(Tables.Issue).InSchema(Schemas.Dbo);
        }
    }
}