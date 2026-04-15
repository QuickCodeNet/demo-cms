namespace QuickCode.DemoCms.ContentManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class PageTranslation
    {
        public static class Query
        {
            private const string _prefix = "ContentManagementModule.PageTranslation.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByPageId => ResourceKey("GetByPageId.g.sql");
            public static string GetByPageAndLanguage => ResourceKey("GetByPageAndLanguage.g.sql");
            public static string GetBySlugAndLanguage => ResourceKey("GetBySlugAndLanguage.g.sql");
            public static string CheckSlugExists => ResourceKey("CheckSlugExists.g.sql");
        }
    }
}