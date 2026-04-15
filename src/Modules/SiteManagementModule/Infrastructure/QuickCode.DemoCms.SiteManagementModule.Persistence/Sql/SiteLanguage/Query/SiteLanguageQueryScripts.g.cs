namespace QuickCode.DemoCms.SiteManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class SiteLanguage
    {
        public static class Query
        {
            private const string _prefix = "SiteManagementModule.SiteLanguage.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetLanguagesForSite => ResourceKey("GetLanguagesForSite.g.sql");
        }
    }
}