using QuickCode.DemoCms.Common.Nswag.Clients.IdentityModuleApi.Contracts;

namespace QuickCode.DemoCms.Gateway.Models;

public class GroupHttpMethodPath
{
    public string? PermissionGroupName { get; set; }
    public HttpMethodType HttpMethod { get; set; }
    public string Path { get; set; } = null!;
}