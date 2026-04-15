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

[PrimaryKey("SiteId", "LanguageId")]
[Table("SITE_LANGUAGES")]
public partial class SiteLanguage : IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	[Column("SITE_ID")]
	public int SiteId { get; set; }
	
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	[Column("LANGUAGE_ID")]
	public int LanguageId { get; set; }
	
	[Column("IS_ENABLED")]
	public bool IsEnabled { get; set; }
	
	[ForeignKey("SiteId")]
	[InverseProperty(nameof(Site.SiteLanguages))]
	public virtual Site Site { get; set; } = null!;

}

