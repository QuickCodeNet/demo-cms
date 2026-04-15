namespace QuickCode.DemoCms.LocalizationModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class LanguageFallback
    {
        public static class Command
        {
            private const string _prefix = "LocalizationModule.LanguageFallback.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string RemoveFallback => ResourceKey("RemoveFallback.g.sql");
        }
    }
}