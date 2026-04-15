namespace QuickCode.DemoCms.LocalizationModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class TranslationValue
    {
        public static class Command
        {
            private const string _prefix = "LocalizationModule.TranslationValue.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string BulkUpsert => ResourceKey("BulkUpsert.g.sql");
        }
    }
}