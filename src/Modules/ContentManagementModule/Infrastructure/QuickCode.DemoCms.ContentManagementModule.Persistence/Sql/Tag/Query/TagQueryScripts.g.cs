namespace QuickCode.DemoCms.ContentManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Tag
    {
        public static class Query
        {
            private const string _prefix = "ContentManagementModule.Tag.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string SearchByName => ResourceKey("SearchByName.g.sql");
            public static string GetBySlug => ResourceKey("GetBySlug.g.sql");
        }
    }
}