using QuickCode.DemoCms.Common.Nswag.Clients.SiteManagementModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.DemoCms.Portal.Helpers;

namespace QuickCode.DemoCms.Portal.Models.SiteManagementModule
{
    public class NavigationMenuData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public NavigationMenuDto SelectedItem { get; set; }
        public List<NavigationMenuDto> List { get; set; }
    }

    public static partial class NavigationMenuExtensions
    {
        public static string GetKey(this NavigationMenuDto dto)
        {
            return $"{dto.Id}";
        }
    }
}