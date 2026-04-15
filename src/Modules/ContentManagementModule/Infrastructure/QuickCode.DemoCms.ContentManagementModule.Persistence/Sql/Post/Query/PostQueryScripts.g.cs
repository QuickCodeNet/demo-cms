namespace QuickCode.DemoCms.ContentManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Post
    {
        public static class Query
        {
            private const string _prefix = "ContentManagementModule.Post.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetPublishedPosts => ResourceKey("GetPublishedPosts.g.sql");
            public static string GetPostsByAuthor => ResourceKey("GetPostsByAuthor.g.sql");
            public static string GetRecentPosts => ResourceKey("GetRecentPosts.g.sql");
        }
    }
}