namespace QuickCode.DemoCms.SiteManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class SiteSetting
    {
        public static class Command
        {
            private const string _prefix = "SiteManagementModule.SiteSetting.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string UpdateValue => ResourceKey("UpdateValue.g.sql");
        }
    }
}