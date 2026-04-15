namespace QuickCode.DemoCms.ContentManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class ContentTag
    {
        public static class Command
        {
            private const string _prefix = "ContentManagementModule.ContentTag.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string RemoveTagFromContent => ResourceKey("RemoveTagFromContent.g.sql");
            public static string RemoveAllTagsFromContent => ResourceKey("RemoveAllTagsFromContent.g.sql");
        }
    }
}