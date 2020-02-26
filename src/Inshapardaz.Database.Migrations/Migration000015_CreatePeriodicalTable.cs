using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000015)]
    public class Migration000015_CreatePeriodicalTable : Migration
    {
        public override void Up()
        {
            Create.Table(Tables.Periodical)
                .InSchema(Schemas.Library)
                .WithColumn(Columns.Id).AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(int.MaxValue).NotNullable()
                .WithColumn(Columns.Description).AsString(int.MaxValue).Nullable()
                .WithColumn("CategoryId").AsInt32().Nullable().Indexed("IX_Periodical_CategoryId")
                .WithColumn(Columns.ImageId).AsInt32().Nullable();
            
            Create.ForeignKey("FK_Periodical_PeriodicalCategory_CategoryId")
                .FromTable(Tables.Periodical).InSchema(Schemas.Library).ForeignColumn("CategoryId")
                .ToTable(Tables.PeriodicalCategory).InSchema(Schemas.Library).PrimaryColumn(Columns.Id);
        }

        public override void Down()
        {
            Delete.Table(Tables.Periodical)
                .InSchema(Schemas.Library);
        }
    }
}