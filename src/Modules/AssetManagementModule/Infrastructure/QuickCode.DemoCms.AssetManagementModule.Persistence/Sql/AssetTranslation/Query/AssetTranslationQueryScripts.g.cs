namespace QuickCode.DemoCms.AssetManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class AssetTranslation
    {
        public static class Query
        {
            private const string _prefix = "AssetManagementModule.AssetTranslation.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByAssetId => ResourceKey("GetByAssetId.g.sql");
            public static string GetByAssetAndLanguage => ResourceKey("GetByAssetAndLanguage.g.sql");
        }
    }
}