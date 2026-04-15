namespace QuickCode.DemoCms.AssetManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class StorageProvider
    {
        public static class Command
        {
            private const string _prefix = "AssetManagementModule.StorageProvider.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string SetAsDefault => ResourceKey("SetAsDefault.g.sql");
            public static string Deactivate => ResourceKey("Deactivate.g.sql");
        }
    }
}