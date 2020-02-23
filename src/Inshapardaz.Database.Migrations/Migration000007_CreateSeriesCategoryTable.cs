using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000007)]
    public class Migration000007_CreateSeriesCategoryTable : Migration
    {
        public override void Up()
        {
            Create.Table("SeriesCategory")
                .InSchema("Library")
                .WithColumn("SeriesId").AsInt32()
                .WithColumn("CategoryId").AsInt32().Indexed("IX_SeriesCategory_CategoryId");

            Create.PrimaryKey("PK_SeriesCategory")
                .OnTable("SeriesCategory").WithSchema("Library")
                .Columns("SeriesId", "CategoryId");
            
            Create.ForeignKey("FK_SeriesCategory_Series_SeriesId")
                .FromTable("SeriesCategory").InSchema("Library").ForeignColumn("SeriesId")
                .ToTable("Series").InSchema("Library").PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade);
            
            Create.ForeignKey("FK_SeriesCategory_Category_CategoryId")
                .FromTable("SeriesCategory").InSchema("Library").ForeignColumn("CategoryId")
                .ToTable("Category").InSchema("Library").PrimaryColumn("Id")
                .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table("SeriesCategory")
                .InSchema("Library");
        }
    }
}
