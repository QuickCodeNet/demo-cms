namespace QuickCode.DemoCms.LocalizationModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class LanguageFallback
    {
        public static class Query
        {
            private const string _prefix = "LocalizationModule.LanguageFallback.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetFallbacksForLanguage => ResourceKey("GetFallbacksForLanguage.g.sql");
        }
    }
}