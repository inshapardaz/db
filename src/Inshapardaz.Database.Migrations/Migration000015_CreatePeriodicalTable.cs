using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000015)]
    public class Migration000015_CreatePeriodicalTable : Migration
    {
        public override void Up()
        {
            Create.Table("Periodical")
                .InSchema("Library")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(int.MaxValue).NotNullable()
                .WithColumn("Description").AsString(int.MaxValue).Nullable()
                .WithColumn("CategoryId").AsInt32().Nullable().Indexed("IX_Periodical_CategoryId")
                .WithColumn("ImageId").AsInt32().Nullable();
            
            Create.ForeignKey("FK_Periodical_PeriodicalCategory_CategoryId")
                .FromTable("Periodical").InSchema("Library").ForeignColumn("CategoryId")
                .ToTable("PeriodicalCategory").InSchema("Library").PrimaryColumn("Id");
        }

        public override void Down()
        {
            Delete.Table("Periodical")
                .InSchema("Library");
        }
    }
}