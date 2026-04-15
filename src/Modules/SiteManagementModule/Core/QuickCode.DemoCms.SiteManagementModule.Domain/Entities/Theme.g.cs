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

[Table("THEMES")]
public partial class Theme : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("NAME")]
	[StringLength(250)]
	public string Name { get; set; }
	
	[Column("VERSION")]
	[StringLength(50)]
	public string Version { get; set; }
	
	[Column("DEVELOPER")]
	[StringLength(250)]
	public string Developer { get; set; }
	
	[Column("REPOSITORY_URL")]
	[StringLength(1000)]
	public string RepositoryUrl { get; set; }
	
	[Column("IS_ACTIVE")]
	public bool IsActive { get; set; }
	
	[InverseProperty(nameof(Site.Theme))]
	public virtual ICollection<Site> Sites { get; } = new List<Site>();


	[InverseProperty(nameof(Template.Theme))]
	public virtual ICollection<Template> Templates { get; } = new List<Template>();

}

