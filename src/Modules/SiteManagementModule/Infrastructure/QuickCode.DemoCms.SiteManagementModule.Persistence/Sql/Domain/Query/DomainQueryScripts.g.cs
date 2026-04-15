namespace QuickCode.DemoCms.SiteManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Domain
    {
        public static class Query
        {
            private const string _prefix = "SiteManagementModule.Domain.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetBySiteId => ResourceKey("GetBySiteId.g.sql");
            public static string GetSiteByHostname => ResourceKey("GetSiteByHostname.g.sql");
        }
    }
}