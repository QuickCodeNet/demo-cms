namespace QuickCode.DemoCms.LocalizationModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class TranslationKey
    {
        public static class Query
        {
            private const string _prefix = "LocalizationModule.TranslationKey.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByNamespace => ResourceKey("GetByNamespace.g.sql");
            public static string SearchByKey => ResourceKey("SearchByKey.g.sql");
            public static string GetUntranslatedKeysForLanguage => ResourceKey("GetUntranslatedKeysForLanguage.g.sql");
        }
    }
}