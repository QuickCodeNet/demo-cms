namespace QuickCode.DemoCms.ContentManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class ContentTag
    {
        public static class Query
        {
            private const string _prefix = "ContentManagementModule.ContentTag.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetTagsForContent => ResourceKey("GetTagsForContent.g.sql");
            public static string GetContentForTag => ResourceKey("GetContentForTag.g.sql");
        }
    }
}