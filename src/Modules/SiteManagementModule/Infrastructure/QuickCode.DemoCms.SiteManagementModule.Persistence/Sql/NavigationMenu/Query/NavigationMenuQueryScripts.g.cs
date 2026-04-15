namespace QuickCode.DemoCms.SiteManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class NavigationMenu
    {
        public static class Query
        {
            private const string _prefix = "SiteManagementModule.NavigationMenu.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetBySiteId => ResourceKey("GetBySiteId.g.sql");
            public static string GetByLocation => ResourceKey("GetByLocation.g.sql");
        }
    }
}