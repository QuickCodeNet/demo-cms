using QuickCode.DemoCms.Common.Nswag.Clients.SiteManagementModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.DemoCms.Portal.Helpers;

namespace QuickCode.DemoCms.Portal.Models.SiteManagementModule
{
    public class NavigationItemData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public NavigationItemDto SelectedItem { get; set; }
        public List<NavigationItemDto> List { get; set; }
    }

    public static partial class NavigationItemExtensions
    {
        public static string GetKey(this NavigationItemDto dto)
        {
            return $"{dto.Id}";
        }
    }
}