using FluentMigrator;

namespace Inshapardaz.Database.Migrations
{
    [Migration(000039)]
    public class Migration000039_RemoveAllSchemas : Migration
    {
        public override void Up()
        {
            Alter.Table(Tables.File).InSchema(Schemas.Inshapardaz).ToSchema(Schemas.Dbo);
            Alter.Table(Tables.Article).InSchema(Schemas.Library).ToSchema(Schemas.Dbo);
            Alter.Table(Tables.ArticleText).InSchema(Schemas.Library).ToSchema(Schemas.Dbo);
            Alter.Table(Tables.Author).InSchema(Schemas.Library).ToSchema(Schemas.Dbo);
            Alter.Table(Tables.Book).InSchema(Schemas.Library).ToSchema(Schemas.Dbo);
            Alter.Table(Tables.BookCategory).InSchema(Schemas.Library).ToSchema(Schemas.Dbo);
            Alter.Table(Tables.BookContent).InSchema(Schemas.Library).ToSchema(Schemas.Dbo);
            Alter.Table(Tables.BookPage).InSchema(Schemas.Library).ToSchema(Schemas.Dbo);
            Alter.Table(Tables.BookShelf).InSchema(Schemas.Library).ToSchema(Schemas.Dbo);
            Alter.Table(Tables.BookShelfBook).InSchema(Schemas.Library).ToSchema(Schemas.Dbo);
            Alter.Table(Tables.Category).InSchema(Schemas.Library).ToSchema(Schemas.Dbo);
            Alter.Table(Tables.Chapter).InSchema(Schemas.Library).ToSchema(Schemas.Dbo);
            Alter.Table(Tables.ChapterContent).InSchema(Schemas.Library).ToSchema(Schemas.Dbo);
            Alter.Table(Tables.FavoriteBooks).InSchema(Schemas.Library).ToSchema(Schemas.Dbo);
            Alter.Table(Tables.Issue).InSchema(Schemas.Library).ToSchema(Schemas.Dbo);
            Alter.Table(Tables.Library).InSchema(Schemas.Library).ToSchema(Schemas.Dbo);
            Alter.Table(Tables.Periodical).InSchema(Schemas.Library).ToSchema(Schemas.Dbo);
            Alter.Table(Tables.PeriodicalCategory).InSchema(Schemas.Library).ToSchema(Schemas.Dbo);
            Alter.Table(Tables.RecentBooks).InSchema(Schemas.Library).ToSchema(Schemas.Dbo);
            Alter.Table(Tables.Series).InSchema(Schemas.Library).ToSchema(Schemas.Dbo);
            Alter.Table(Tables.SeriesCategory).InSchema(Schemas.Library).ToSchema(Schemas.Dbo);
        }

        public override void Down()
        {
            Alter.Table(Tables.File).InSchema(Schemas.Dbo).ToSchema(Schemas.Inshapardaz);
            Alter.Table(Tables.Article).InSchema(Schemas.Dbo).ToSchema(Schemas.Library);
            Alter.Table(Tables.ArticleText).InSchema(Schemas.Dbo).ToSchema(Schemas.Library);
            Alter.Table(Tables.Author).InSchema(Schemas.Dbo).ToSchema(Schemas.Library);
            Alter.Table(Tables.Book).InSchema(Schemas.Dbo).ToSchema(Schemas.Library);
            Alter.Table(Tables.BookCategory).InSchema(Schemas.Dbo).ToSchema(Schemas.Library);
            Alter.Table(Tables.BookContent).InSchema(Schemas.Dbo).ToSchema(Schemas.Library);
            Alter.Table(Tables.BookPage).InSchema(Schemas.Dbo).ToSchema(Schemas.Library);
            Alter.Table(Tables.BookShelf).InSchema(Schemas.Dbo).ToSchema(Schemas.Library);
            Alter.Table(Tables.BookShelfBook).InSchema(Schemas.Dbo).ToSchema(Schemas.Library);
            Alter.Table(Tables.Category).InSchema(Schemas.Dbo).ToSchema(Schemas.Library);
            Alter.Table(Tables.Chapter).InSchema(Schemas.Dbo).ToSchema(Schemas.Library);
            Alter.Table(Tables.ChapterContent).InSchema(Schemas.Dbo).ToSchema(Schemas.Library);
            Alter.Table(Tables.FavoriteBooks).InSchema(Schemas.Dbo).ToSchema(Schemas.Library);
            Alter.Table(Tables.Issue).InSchema(Schemas.Dbo).ToSchema(Schemas.Library);
            Alter.Table(Tables.Library).InSchema(Schemas.Dbo).ToSchema(Schemas.Library);
            Alter.Table(Tables.Periodical).InSchema(Schemas.Dbo).ToSchema(Schemas.Library);
            Alter.Table(Tables.PeriodicalCategory).InSchema(Schemas.Dbo).ToSchema(Schemas.Library);
            Alter.Table(Tables.RecentBooks).InSchema(Schemas.Dbo).ToSchema(Schemas.Library);
            Alter.Table(Tables.Series).InSchema(Schemas.Dbo).ToSchema(Schemas.Library);
            Alter.Table(Tables.SeriesCategory).InSchema(Schemas.Dbo).ToSchema(Schemas.Library);
        }
    }
}