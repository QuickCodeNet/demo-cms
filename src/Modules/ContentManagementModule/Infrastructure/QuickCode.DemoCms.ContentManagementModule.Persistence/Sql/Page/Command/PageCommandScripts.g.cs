namespace QuickCode.DemoCms.ContentManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Page
    {
        public static class Command
        {
            private const string _prefix = "ContentManagementModule.Page.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string Publish => ResourceKey("Publish.g.sql");
            public static string Archive => ResourceKey("Archive.g.sql");
            public static string RevertToDraft => ResourceKey("RevertToDraft.g.sql");
            public static string RequestReview => ResourceKey("RequestReview.g.sql");
        }
    }
}