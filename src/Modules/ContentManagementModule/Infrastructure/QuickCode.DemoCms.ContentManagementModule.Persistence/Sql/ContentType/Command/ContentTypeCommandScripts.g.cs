namespace QuickCode.DemoCms.ContentManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class ContentType
    {
        public static class Command
        {
            private const string _prefix = "ContentManagementModule.ContentType.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string Deactivate => ResourceKey("Deactivate.g.sql");
        }
    }
}