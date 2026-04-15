namespace QuickCode.DemoCms.SiteManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class SiteSetting
    {
        public static class Query
        {
            private const string _prefix = "SiteManagementModule.SiteSetting.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetSettingsForSite => ResourceKey("GetSettingsForSite.g.sql");
            public static string GetSettingByKey => ResourceKey("GetSettingByKey.g.sql");
        }
    }
}