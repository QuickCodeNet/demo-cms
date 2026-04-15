namespace QuickCode.DemoCms.LocalizationModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class TranslationValue
    {
        public static class Query
        {
            private const string _prefix = "LocalizationModule.TranslationValue.Query";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string GetByKeyAndLanguage => ResourceKey("GetByKeyAndLanguage.g.sql");
            public static string GetTranslationsForLanguageAndNamespace => ResourceKey("GetTranslationsForLanguageAndNamespace.g.sql");
        }
    }
}