namespace QuickCode.DemoCms.AssetManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Asset
    {
        public static class Query
        {
            private const string _prefix = "AssetManagementModule.Asset.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByFolder => ResourceKey("GetByFolder.g.sql");
            public static string SearchByFilename => ResourceKey("SearchByFilename.g.sql");
            public static string GetRecentlyUploaded => ResourceKey("GetRecentlyUploaded.g.sql");
            public static string GetByKind => ResourceKey("GetByKind.g.sql");
            public static string GetAssetsWithoutFolder => ResourceKey("GetAssetsWithoutFolder.g.sql");
        }
    }
}