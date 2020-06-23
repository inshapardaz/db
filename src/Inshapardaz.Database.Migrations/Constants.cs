namespace Inshapardaz.Database.Migrations
{
    public static class Schemas
    {
        public static string Library => "Library";
        public static string Inshapardaz => "Inshapardaz";

        public static string Dbo => "dbo";
    }

    public static class Tables
    {
        public static string Author => "Author";
        public static string File => "File";
        public static string Series => "Series";
        public static string Category => "Category";
        public static string Book => "Book";
        public static string SeriesCategory => "SeriesCategory";
        public static string BookCategory => "BookCategory";
        public static string Chapter => "Chapter";
        public static string ChapterContent => "ChapterContent";
        public static string BookFile => "BookFile";
        public static string BookContent => "BookContent";
        public static string RecentBooks => "RecentBooks";
        public static string FavoriteBooks => "FavoriteBooks";
        public static string PeriodicalCategory => "PeriodicalCategory";
        public static string Periodical => "Periodical";
        public static string Issue => "Issue";
        public static string Article => "Article";
        public static string ArticleText => "ArticleText";
        public static string BookPage => "BookPage";
        public static string Library => "Library";
        public static string BookShelf => "BookShelf";
        public static string BookShelfBook => "BookShelfBook";
    }

    public static class Columns
    {
        public static string Id => "Id";
        public static string Name => "Name";
        public static string Description => "Description";
        public static string DateCreated => "DateCreated";
        public static string BookId => "BookId";
        public static string ImageId => "ImageId";
        public static string FileId => "FileId";
        public static string IsPublic => "IsPublic";

        public static string Language => "Language";
    }
}