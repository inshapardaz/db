using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000075)]
    public class Migration000075_ChangePeriodicalCategoryTable : Migration
    {
        public override void Up()
        {
            Delete.Table(Tables.PeriodicalCategory)
                .InSchema(Schemas.Dbo);
            Create.Table(Tables.PeriodicalCategory)
                .InSchema(Schemas.Dbo)
                .WithColumn("PeriodicalId").AsInt32()
                .WithColumn("CategoryId").AsInt32().Indexed("IX_PeriodicalCategory_CategoryId");

            Create.PrimaryKey("PK_PeriodicalCategory")
                .OnTable(Tables.PeriodicalCategory).WithSchema(Schemas.Dbo)
                .Columns("PeriodicalId", "CategoryId");
            Create.ForeignKey("FK_PeriodicalCategory_Category_CategoryId")
                .FromTable(Tables.PeriodicalCategory).InSchema(Schemas.Dbo).ForeignColumn("CategoryId")
                .ToTable(Tables.Category).InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);
            Create.ForeignKey("FK_PeriodicalCategory_Periodical_PeriodicalId")
                .FromTable(Tables.PeriodicalCategory).InSchema(Schemas.Dbo).ForeignColumn("PeriodicalId")
                .ToTable(Tables.Periodical).InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.Cascade);
        }

        public override void Down()
        {
            Delete.Table(Tables.PeriodicalCategory)
                .InSchema(Schemas.Dbo);
            Create.Table(Tables.PeriodicalCategory)
                .InSchema(Schemas.Dbo)
                .WithColumn(Columns.Id).AsInt32().PrimaryKey().Identity()
                .WithColumn(Columns.Name).AsString(int.MaxValue).NotNullable();
        }
    }
}
