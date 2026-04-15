namespace QuickCode.DemoCms.ContentManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class ContentType
    {
        public static class Query
        {
            private const string _prefix = "ContentManagementModule.ContentType.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetActive => ResourceKey("GetActive.g.sql");
            public static string GetByKind => ResourceKey("GetByKind.g.sql");
            public static string SearchByName => ResourceKey("SearchByName.g.sql");
            public static string GetByApiKey => ResourceKey("GetByApiKey.g.sql");
        }
    }
}