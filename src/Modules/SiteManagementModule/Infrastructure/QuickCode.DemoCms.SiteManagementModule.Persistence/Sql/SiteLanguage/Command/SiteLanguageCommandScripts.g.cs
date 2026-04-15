namespace QuickCode.DemoCms.SiteManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class SiteLanguage
    {
        public static class Command
        {
            private const string _prefix = "SiteManagementModule.SiteLanguage.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string EnableLanguage => ResourceKey("EnableLanguage.g.sql");
            public static string DisableLanguage => ResourceKey("DisableLanguage.g.sql");
        }
    }
}