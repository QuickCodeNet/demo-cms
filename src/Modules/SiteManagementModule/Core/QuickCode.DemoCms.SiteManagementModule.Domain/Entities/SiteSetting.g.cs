using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoCms.SiteManagementModule.Domain;
using QuickCode.DemoCms.Common;
using QuickCode.DemoCms.Common.Auditing;

namespace QuickCode.DemoCms.SiteManagementModule.Domain.Entities;

[Table("SITE_SETTINGS")]
public partial class SiteSetting : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("SITE_ID")]
	public int SiteId { get; set; }
	
	[Column("KEY")]
	[StringLength(50)]
	public string Key { get; set; }
	
	[Column("VALUE")]
	[StringLength(1000)]
	public string Value { get; set; }
	
	[Column("IS_SECRET")]
	public bool IsSecret { get; set; }
	
	[ForeignKey("SiteId")]
	[InverseProperty(nameof(Site.SiteSettings))]
	public virtual Site Site { get; set; } = null!;

}

