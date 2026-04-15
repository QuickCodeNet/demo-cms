namespace QuickCode.DemoCms.AssetManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class AssetRendition
    {
        public static class Query
        {
            private const string _prefix = "AssetManagementModule.AssetRendition.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetRenditionsForAsset => ResourceKey("GetRenditionsForAsset.g.sql");
            public static string GetRenditionByName => ResourceKey("GetRenditionByName.g.sql");
        }
    }
}