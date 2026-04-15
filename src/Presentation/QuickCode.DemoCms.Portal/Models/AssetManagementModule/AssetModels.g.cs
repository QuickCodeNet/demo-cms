using QuickCode.DemoCms.Common.Nswag.Clients.AssetManagementModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.DemoCms.Portal.Helpers;

namespace QuickCode.DemoCms.Portal.Models.AssetManagementModule
{
    public class AssetData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public AssetDto SelectedItem { get; set; }
        public List<AssetDto> List { get; set; }
    }

    public static partial class AssetExtensions
    {
        public static string GetKey(this AssetDto dto)
        {
            return $"{dto.Id}";
        }
    }
}