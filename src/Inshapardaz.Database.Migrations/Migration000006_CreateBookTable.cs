using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000006)]
    public class Migration000006_CreateBookTable : Migration
    {
        public override void Up()
        {
            Create.Table(Tables.Book)
                .InSchema(Schemas.Library)
                .WithColumn(Columns.Id).AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(int.MaxValue).NotNullable()
                // TODO : Add Index 
                //.Indexed("IDX_Title")
                .WithColumn(Columns.Description).AsString(int.MaxValue).Nullable()
                .WithColumn("AuthorId").AsInt32().NotNullable().Indexed("IX_Book_AuthorId")
                .WithColumn(Columns.ImageId).AsInt32().Nullable()
                .WithColumn(Columns.IsPublic).AsBoolean()
                // TODO : Add Default Value
                //.WithDefaultValue(false)
                .WithColumn("IsPublished").AsBoolean().NotNullable().WithDefaultValue(0)
                // TODO : Add Default Value
                //.WithDefaultValue(false)
                .WithColumn("Language").AsInt32()
                .WithColumn("Status").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("SeriesId").AsInt32().Nullable().Indexed("IX_Book_SeriesId")
                .WithColumn("SeriesIndex").AsInt32().Nullable()
                .WithColumn("Copyrights").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("YearPublished").AsInt32().Nullable()        
                .WithColumn("DateAdded").AsDateTime2().NotNullable().WithDefaultValue("0001-01-01T00:00:00.000")
                .WithColumn("DateUpdated").AsDateTime2().NotNullable().WithDefaultValue("0001-01-01T00:00:00.000");

            Create.ForeignKey("FK_Book_Author_AuthorId")
                .FromTable(Tables.Book).InSchema(Schemas.Library).ForeignColumn("AuthorId")
                .ToTable(Tables.Author).InSchema(Schemas.Library).PrimaryColumn(Columns.Id)
                // TODO : Make it not delete
                .OnDelete(System.Data.Rule.Cascade);

            Create.ForeignKey("FK_Book_Series_SeriesId")
                .FromTable(Tables.Book).InSchema(Schemas.Library).ForeignColumn("SeriesId")
                .ToTable(Tables.Series).InSchema(Schemas.Library).PrimaryColumn(Columns.Id)
                .OnDelete(System.Data.Rule.SetNull);

            // TODO : Add reference
            // Create.ForeignKey("FK_Book_ImageId_File_Id")
            //     .FromTable("Book").InSchema(Schemas.Library).ForeignColumn("ImageId")
            //     .ToTable(Tables.File).InSchema(Schemas.Library).PrimaryColumn(Columns.Id)
            //     .OnDelete(System.Data.Rule.SetDefault);
        }

        public override void Down()
        {
            Delete.Table(Tables.Book)
                .InSchema(Schemas.Library);
        }
    }
}
