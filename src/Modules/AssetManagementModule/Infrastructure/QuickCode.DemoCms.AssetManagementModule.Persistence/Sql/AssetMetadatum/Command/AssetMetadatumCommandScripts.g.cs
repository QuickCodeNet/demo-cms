namespace QuickCode.DemoCms.AssetManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class AssetMetadatum
    {
        public static class Command
        {
            private const string _prefix = "AssetManagementModule.AssetMetadatum.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string UpdateMetadataValue => ResourceKey("UpdateMetadataValue.g.sql");
        }
    }
}