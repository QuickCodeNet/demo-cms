namespace QuickCode.DemoCms.AssetManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class AssetFolder
    {
        public static class Query
        {
            private const string _prefix = "AssetManagementModule.AssetFolder.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetRootFolders => ResourceKey("GetRootFolders.g.sql");
            public static string GetSubfolders => ResourceKey("GetSubfolders.g.sql");
            public static string SearchByName => ResourceKey("SearchByName.g.sql");
            public static string GetByPath => ResourceKey("GetByPath.g.sql");
        }
    }
}