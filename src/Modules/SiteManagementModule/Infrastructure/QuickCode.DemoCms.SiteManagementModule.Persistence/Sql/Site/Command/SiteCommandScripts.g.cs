namespace QuickCode.DemoCms.SiteManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Site
    {
        public static class Command
        {
            private const string _prefix = "SiteManagementModule.Site.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string Deactivate => ResourceKey("Deactivate.g.sql");
            public static string Activate => ResourceKey("Activate.g.sql");
            public static string ChangeTheme => ResourceKey("ChangeTheme.g.sql");
        }
    }
}