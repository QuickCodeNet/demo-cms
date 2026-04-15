namespace QuickCode.DemoCms.LocalizationModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Language
    {
        public static class Query
        {
            private const string _prefix = "LocalizationModule.Language.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetActive => ResourceKey("GetActive.g.sql");
            public static string GetDefault => ResourceKey("GetDefault.g.sql");
            public static string GetByCode => ResourceKey("GetByCode.g.sql");
        }
    }
}