using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000022)]
    public class Migration000022_CreateBookConstraints : Migration
    {
        public override void Up()
        {
            Alter.Column("Title").OnTable(Tables.Book).InSchema(Schemas.Library)
                 .AsString(512);
            Alter.Column("Title").OnTable(Tables.Book).InSchema(Schemas.Library)
                 .AsString(512)
                 .Indexed("IDX_Book_Title");

            Alter.Column(Columns.IsPublic).OnTable(Tables.Book).InSchema(Schemas.Library)
                 .AsBoolean()
                 .WithDefaultValue(0);

            Create.ForeignKey("FK_Book_Image")
                  .FromTable(Tables.Book).InSchema(Schemas.Library).ForeignColumn(Columns.ImageId)
                  .ToTable(Tables.File).InSchema(Schemas.Inshapardaz).PrimaryColumn(Columns.Id)
                  .OnDelete(System.Data.Rule.SetDefault);
        }

        public override void Down()
        {
            Delete.Index("IDX_Book_Title").OnTable(Tables.Book).InSchema(Schemas.Library)
                  .OnColumn("Name");

            Alter.Column("Title").OnTable(Tables.Book).InSchema(Schemas.Library)
                 .AsString(int.MaxValue);
            Delete.DefaultConstraint().OnTable(Tables.Book).InSchema(Schemas.Library)
                  .OnColumn(Columns.IsPublic);
            Delete.ForeignKey("FK_Book_Image").OnTable(Tables.Book).InSchema(Schemas.Library);
        }
    }
}
