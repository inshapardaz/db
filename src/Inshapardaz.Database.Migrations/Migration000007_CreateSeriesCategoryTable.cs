using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000007)]
    public class Migration000007_CreateSeriesCategoryTable : Migration
    {
        public override void Up()
        {
            Create.Table(Tables.SeriesCategory)
                .InSchema(Schemas.Library)
                .WithColumn("SeriesId").AsInt32()
                .WithColumn("CategoryId").AsInt32().Indexed("IX_SeriesCategory_CategoryId");

            Create.PrimaryKey("PK_SeriesCategory")
                .OnTable(Tables.SeriesCategory).WithSchema(Schemas.Library)
                .Columns("SeriesId", "CategoryId");
            
            Create.ForeignKey("FK_SeriesCategory_Series_SeriesId")
                .FromTable(Tables.SeriesCategory).InSchema(Schemas.Library).ForeignColumn("SeriesId")
                .ToTable(Tables.Series).InSchema(Schemas.Library).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);
            
            Create.ForeignKey("FK_SeriesCategory_Category_CategoryId")
                .FromTable(Tables.SeriesCategory).InSchema(Schemas.Library).ForeignColumn("CategoryId")
                .ToTable(Tables.Category).InSchema(Schemas.Library).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table(Tables.SeriesCategory)
                .InSchema(Schemas.Library);
        }
    }
}
