namespace QuickCode.DemoCms.SiteManagementModule.Persistence.Sql;
public static partial class SqlScripts
{
    public static partial class Domain
    {
        public static class Command
        {
            private const string _prefix = "SiteManagementModule.Domain.Command";
            private static string ResourceKey(string sqlName) => $"{_prefix}.{sqlName}";
            public static string SetAsPrimary => ResourceKey("SetAsPrimary.g.sql");
            public static string Deactivate => ResourceKey("Deactivate.g.sql");
        }
    }
}