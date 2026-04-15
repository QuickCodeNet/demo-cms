namespace QuickCode.DemoCms.ContentManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class ContentBlock
    {
        public static class Query
        {
            private const string _prefix = "ContentManagementModule.ContentBlock.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetActive => ResourceKey("GetActive.g.sql");
            public static string GetByKey => ResourceKey("GetByKey.g.sql");
            public static string SearchByKey => ResourceKey("SearchByKey.g.sql");
        }
    }
}