namespace QuickCode.DemoCms.SiteManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class NavigationItem
    {
        public static class Query
        {
            private const string _prefix = "SiteManagementModule.NavigationItem.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByMenuId => ResourceKey("GetByMenuId.g.sql");
            public static string GetRootItems => ResourceKey("GetRootItems.g.sql");
            public static string GetChildItems => ResourceKey("GetChildItems.g.sql");
        }
    }
}