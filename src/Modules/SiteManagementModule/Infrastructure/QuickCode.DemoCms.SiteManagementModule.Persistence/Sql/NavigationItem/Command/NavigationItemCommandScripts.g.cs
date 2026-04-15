namespace QuickCode.DemoCms.SiteManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class NavigationItem
    {
        public static class Command
        {
            private const string _prefix = "SiteManagementModule.NavigationItem.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string UpdateSortOrder => ResourceKey("UpdateSortOrder.g.sql");
        }
    }
}