namespace QuickCode.DemoCms.ContentManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Post
    {
        public static class Command
        {
            private const string _prefix = "ContentManagementModule.Post.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string Publish => ResourceKey("Publish.g.sql");
            public static string Archive => ResourceKey("Archive.g.sql");
            public static string RevertToDraft => ResourceKey("RevertToDraft.g.sql");
        }
    }
}