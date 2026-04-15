namespace QuickCode.DemoCms.SiteManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Theme
    {
        public static class Command
        {
            private const string _prefix = "SiteManagementModule.Theme.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string Deactivate => ResourceKey("Deactivate.g.sql");
        }
    }
}