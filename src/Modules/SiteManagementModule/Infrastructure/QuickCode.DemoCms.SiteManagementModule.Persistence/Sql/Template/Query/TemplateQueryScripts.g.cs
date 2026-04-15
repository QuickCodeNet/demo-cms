namespace QuickCode.DemoCms.SiteManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Template
    {
        public static class Query
        {
            private const string _prefix = "SiteManagementModule.Template.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByThemeId => ResourceKey("GetByThemeId.g.sql");
            public static string GetByKey => ResourceKey("GetByKey.g.sql");
        }
    }
}