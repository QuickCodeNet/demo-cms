namespace QuickCode.DemoCms.AssetManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class StorageProvider
    {
        public static class Query
        {
            private const string _prefix = "AssetManagementModule.StorageProvider.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetActive => ResourceKey("GetActive.g.sql");
            public static string GetDefault => ResourceKey("GetDefault.g.sql");
        }
    }
}