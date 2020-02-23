using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000003)]
    public class Migration000003_CreateAuthorsTable : Migration
    {
        public override void Up()
        {
            Create.Table("Author")
                .InSchema("Library")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(int.MaxValue).NotNullable() 
                // TODO :  Add index
                //.Indexed("IDX_AuthorName")
                .WithColumn("ImageId").AsInt32().Nullable();
            // TODO : Add foreign key
            // Create.ForeignKey()
            //     .FromTable("Author").InSchema("Library").ForeignColumn("ImageId")
            //     .ToTable("File").InSchema("Library").PrimaryColumn("Id")
            //     .OnDelete(System.Data.Rule.SetDefault);
        }

        public override void Down()
        {
            Delete.Table("Author")
                .InSchema("Library");
        }
    }
}
