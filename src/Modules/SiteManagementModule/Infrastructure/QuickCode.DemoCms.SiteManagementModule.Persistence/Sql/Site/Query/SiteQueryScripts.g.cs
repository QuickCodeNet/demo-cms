namespace QuickCode.DemoCms.SiteManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Site
    {
        public static class Query
        {
            private const string _prefix = "SiteManagementModule.Site.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetActive => ResourceKey("GetActive.g.sql");
            public static string SearchByName => ResourceKey("SearchByName.g.sql");
        }
    }
}