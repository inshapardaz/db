using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000004)]
    public class Migration000004_CreateSeriesTable : Migration
    {
        public override void Up()
        {
            Create.Table("Series")
                .InSchema("Library")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(int.MaxValue).NotNullable()
                // TODO : Add index
                //.Indexed("IDX_Name")
                .WithColumn("Description").AsString(int.MaxValue).Nullable()
                .WithColumn("ImageId").AsInt32().Nullable();

            // TODO : Add Foreign key
            // Create.ForeignKey()
            //     .FromTable("Series").InSchema("Library").ForeignColumn("ImageId")
            //     .ToTable("File").InSchema("Library").PrimaryColumn("Id")
            //     .OnDelete(System.Data.Rule.SetDefault);
        }

        public override void Down()
        {
            Delete.Table("Series")
                .InSchema("Library");
        }
    }
}
