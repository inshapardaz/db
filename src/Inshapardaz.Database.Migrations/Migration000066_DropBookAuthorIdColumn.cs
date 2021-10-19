using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000066)]
    public class Migration000066_DropBookAuthorIdColumn : Migration
    {
        public override void Up()
        {
            Delete.Index("IDX_Book_1")
                .OnTable(Tables.Book)
                .InSchema(Schemas.Dbo);
            Delete.Index("IX_Book_AuthorId").OnTable("Book").InSchema(Schemas.Dbo);
            Delete.Column("AuthorId").FromTable("Book").InSchema(Schemas.Dbo);

            Create.Index("IDX_Book_1")
                .OnTable(Tables.Book)
                .OnColumn("IsPublic").Ascending()
                .OnColumn("SeriesId").Ascending()
                .WithOptions().NonClustered();

        }

        public override void Down()
        {
            Delete.Index("IDX_Book_1")
                .OnTable(Tables.Book)
                .InSchema(Schemas.Dbo);
            Alter.Table("Book").InSchema(Schemas.Dbo)
            .AddColumn("AuthorId").AsInt32().Nullable().Indexed("IX_Book_AuthorId");

            Create.Index("IDX_Book_1")
                .OnTable(Tables.Book)
                .OnColumn("AuthorId").Ascending()
                .OnColumn("IsPublic").Ascending()
                .OnColumn("SeriesId").Ascending()
                .WithOptions().NonClustered();
        }
    }
}