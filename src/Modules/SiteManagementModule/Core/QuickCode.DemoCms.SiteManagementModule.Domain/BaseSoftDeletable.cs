using System;
using System.ComponentModel.DataAnnotations.Schema;
using QuickCode.DemoCms.Common;

namespace QuickCode.DemoCms.SiteManagementModule.Domain;

public class BaseSoftDeletable : ISoftDeletable
{
    [Column("IsDeleted")]
    public bool IsDeleted { get; set; }
    
    [Column("DeletedOnUtc")]
    public DateTime? DeletedOnUtc { get; set; }
}