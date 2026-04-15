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

[Table("TEMPLATES")]
public partial class Template : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("THEME_ID")]
	public int ThemeId { get; set; }
	
	[Column("NAME")]
	[StringLength(250)]
	public string Name { get; set; }
	
	[Column("KEY")]
	[StringLength(50)]
	public string Key { get; set; }
	
	[Column("DESCRIPTION")]
	[StringLength(1000)]
	public string Description { get; set; }
	
	[Column("FILE_PATH")]
	[StringLength(1000)]
	public string FilePath { get; set; }
	
	[ForeignKey("ThemeId")]
	[InverseProperty(nameof(Theme.Templates))]
	public virtual Theme Theme { get; set; } = null!;

}

