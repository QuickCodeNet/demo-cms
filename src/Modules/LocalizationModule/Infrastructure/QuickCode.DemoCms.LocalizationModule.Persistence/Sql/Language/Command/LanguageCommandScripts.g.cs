namespace QuickCode.DemoCms.LocalizationModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Language
    {
        public static class Command
        {
            private const string _prefix = "LocalizationModule.Language.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string SetDefault => ResourceKey("SetDefault.g.sql");
            public static string Deactivate => ResourceKey("Deactivate.g.sql");
        }
    }
}