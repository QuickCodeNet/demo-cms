namespace QuickCode.DemoCms.LocalizationModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class ResourceFile
    {
        public static class Command
        {
            private const string _prefix = "LocalizationModule.ResourceFile.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string MarkAsProcessed => ResourceKey("MarkAsProcessed.g.sql");
            public static string MarkAsFailed => ResourceKey("MarkAsFailed.g.sql");
        }
    }
}