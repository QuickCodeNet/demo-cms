using QuickCode.DemoCms.Common.Nswag.Clients.ContentManagementModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.DemoCms.Portal.Helpers;

namespace QuickCode.DemoCms.Portal.Models.ContentManagementModule
{
    public class ContentTypeData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public ContentTypeDto SelectedItem { get; set; }
        public List<ContentTypeDto> List { get; set; }
    }

    public static partial class ContentTypeExtensions
    {
        public static string GetKey(this ContentTypeDto dto)
        {
            return $"{dto.Id}";
        }
    }
}