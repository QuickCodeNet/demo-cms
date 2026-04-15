using QuickCode.DemoCms.Common.Nswag.Clients.SiteManagementModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.DemoCms.Portal.Helpers;

namespace QuickCode.DemoCms.Portal.Models.SiteManagementModule
{
    public class TemplateData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public TemplateDto SelectedItem { get; set; }
        public List<TemplateDto> List { get; set; }
    }

    public static partial class TemplateExtensions
    {
        public static string GetKey(this TemplateDto dto)
        {
            return $"{dto.Id}";
        }
    }
}