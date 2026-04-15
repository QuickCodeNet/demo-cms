namespace QuickCode.DemoCms.ContentManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class PostTranslation
    {
        public static class Query
        {
            private const string _prefix = "ContentManagementModule.PostTranslation.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByPostId => ResourceKey("GetByPostId.g.sql");
            public static string GetByPostAndLanguage => ResourceKey("GetByPostAndLanguage.g.sql");
            public static string SearchPublishedPosts => ResourceKey("SearchPublishedPosts.g.sql");
        }
    }
}