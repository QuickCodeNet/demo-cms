namespace QuickCode.DemoCms.LocalizationModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class ResourceFile
    {
        public static class Query
        {
            private const string _prefix = "LocalizationModule.ResourceFile.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetPendingImports => ResourceKey("GetPendingImports.g.sql");
            public static string GetImportHistory => ResourceKey("GetImportHistory.g.sql");
        }
    }
}