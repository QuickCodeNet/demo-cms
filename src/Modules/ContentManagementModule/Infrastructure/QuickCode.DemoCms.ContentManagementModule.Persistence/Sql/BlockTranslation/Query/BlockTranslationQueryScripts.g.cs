namespace QuickCode.DemoCms.ContentManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class BlockTranslation
    {
        public static class Query
        {
            private const string _prefix = "ContentManagementModule.BlockTranslation.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByBlockId => ResourceKey("GetByBlockId.g.sql");
            public static string GetByBlockAndLanguage => ResourceKey("GetByBlockAndLanguage.g.sql");
        }
    }
}