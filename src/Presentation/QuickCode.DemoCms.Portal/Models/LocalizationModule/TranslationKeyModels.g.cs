using QuickCode.DemoCms.Common.Nswag.Clients.LocalizationModuleApi.Contracts;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using QuickCode.DemoCms.Portal.Helpers;

namespace QuickCode.DemoCms.Portal.Models.LocalizationModule
{
    public class TranslationKeyData : BaseComboBoxModel
    {
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int NumberOfRecord { get; set; }
        public string SelectedKey { get; set; }
        public TranslationKeyDto SelectedItem { get; set; }
        public List<TranslationKeyDto> List { get; set; }
    }

    public static partial class TranslationKeyExtensions
    {
        public static string GetKey(this TranslationKeyDto dto)
        {
            return $"{dto.Id}";
        }
    }
}