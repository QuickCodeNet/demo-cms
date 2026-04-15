using QuickCode.DemoCms.Common.Nswag.Clients.SiteManagementModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.DemoCms.Portal.Helpers;

namespace QuickCode.DemoCms.Portal.Models.SiteManagementModule
{
    public class SiteSettingData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public SiteSettingDto SelectedItem { get; set; }
        public List<SiteSettingDto> List { get; set; }
    }

    public static partial class SiteSettingExtensions
    {
        public static string GetKey(this SiteSettingDto dto)
        {
            return $"{dto.Id}";
        }
    }
}