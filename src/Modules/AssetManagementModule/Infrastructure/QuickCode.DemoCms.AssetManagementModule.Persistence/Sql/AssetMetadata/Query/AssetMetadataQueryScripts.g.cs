namespace QuickCode.DemoCms.AssetManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class AssetMetadata
    {
        public static class Query
        {
            private const string _prefix = "AssetManagementModule.AssetMetadata.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetMetadataForAsset => ResourceKey("GetMetadataForAsset.g.sql");
            public static string GetAssetsByMetadata => ResourceKey("GetAssetsByMetadata.g.sql");
        }
    }
}