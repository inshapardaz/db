using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000020)]
    public class Migration000020_CreateAuthorConstraints : Migration
    {
        public override void Up()
        {
            Alter.Column(Columns.Name).OnTable(Tables.Author).InSchema(Schemas.Library)
                 .AsString(256);
            Alter.Column(Columns.Name).OnTable(Tables.Author).InSchema(Schemas.Library)
                 .AsString(256)
                 .Indexed("IDX_AuthorName");

            Create.ForeignKey("FK_Author_Image")
                  .FromTable(Tables.Author).InSchema(Schemas.Library).ForeignColumn(Columns.ImageId)
                  .ToTable(Tables.File).InSchema(Schemas.Inshapardaz).PrimaryColumn(Columns.Id)
                  .OnDelete(System.Data.Rule.SetDefault);
        }

        public override void Down()
        {
            Delete.Index("IDX_AuthorName").OnTable(Tables.Author).InSchema(Schemas.Library)
                  .OnColumn("Name");

            Alter.Column(Columns.Name).OnTable(Tables.Author).InSchema(Schemas.Library)
                 .AsString(int.MaxValue);

            Delete.ForeignKey("FK_Author_Image").OnTable(Tables.Author).InSchema(Schemas.Library);
        }
    }
}
