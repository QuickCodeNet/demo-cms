namespace QuickCode.DemoCms.ContentManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class ContentVersion
    {
        public static class Query
        {
            private const string _prefix = "ContentManagementModule.ContentVersion.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetVersionsForContent => ResourceKey("GetVersionsForContent.g.sql");
            public static string GetSpecificVersion => ResourceKey("GetSpecificVersion.g.sql");
        }
    }
}