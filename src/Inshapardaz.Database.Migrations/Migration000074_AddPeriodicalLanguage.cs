using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000074)]
    public class Migration000074_AddPeriodicalLanguage : Migration
    {
        public override void Up()
        {
            Delete.Index("IX_Periodical_CategoryId")
                .OnTable(Tables.Periodical)
                .InSchema(Schemas.Dbo);
            Alter.Table(Tables.Periodical)
                .InSchema(Schemas.Dbo)
                .AddColumn(Columns.Language).AsString(10).Nullable();
            Delete.ForeignKey("FK_Periodical_PeriodicalCategory_CategoryId")
                .OnTable(Tables.Periodical).InSchema(Schemas.Dbo);
            Delete.Column("CategoryId")
                .FromTable(Tables.Periodical)
                .InSchema(Schemas.Dbo);
        }

        public override void Down()
        {
            Alter.Table(Tables.Periodical)
                .InSchema(Schemas.Dbo)
                .AddColumn("CategoryId").AsInt32().Nullable().Indexed("IX_Periodical_CategoryId");
            
            Create.ForeignKey("FK_Periodical_PeriodicalCategory_CategoryId")
                .FromTable(Tables.Periodical).InSchema(Schemas.Dbo).ForeignColumn("CategoryId")
                .ToTable(Tables.PeriodicalCategory).InSchema(Schemas.Dbo).PrimaryColumn(Columns.Id);

            Delete.Column(Columns.Language)
                .FromTable(Tables.Periodical)
                .InSchema(Schemas.Dbo);
        }
    }
}
