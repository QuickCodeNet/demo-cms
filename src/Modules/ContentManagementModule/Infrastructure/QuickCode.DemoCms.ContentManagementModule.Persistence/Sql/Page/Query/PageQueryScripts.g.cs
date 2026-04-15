namespace QuickCode.DemoCms.ContentManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Page
    {
        public static class Query
        {
            private const string _prefix = "ContentManagementModule.Page.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetPublished => ResourceKey("GetPublished.g.sql");
            public static string GetDrafts => ResourceKey("GetDrafts.g.sql");
            public static string GetPendingReview => ResourceKey("GetPendingReview.g.sql");
            public static string GetChildPages => ResourceKey("GetChildPages.g.sql");
        }
    }
}