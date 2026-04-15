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

[Table("SITES")]
public partial class Site : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("NAME")]
	[StringLength(250)]
	public string Name { get; set; }
	
	[Column("DEFAULT_LANGUAGE_ID")]
	public int DefaultLanguageId { get; set; }
	
	[Column("THEME_ID")]
	public int ThemeId { get; set; }
	
	[Column("IS_ACTIVE")]
	public bool IsActive { get; set; }
	
	[Column("CREATED_DATE")]
	public DateTime CreatedDate { get; set; }
	
	[InverseProperty(nameof(Domain.Site))]
	public virtual ICollection<Domain> Domains { get; } = new List<Domain>();


	[InverseProperty(nameof(SiteSetting.Site))]
	public virtual ICollection<SiteSetting> SiteSettings { get; } = new List<SiteSetting>();


	[InverseProperty(nameof(SiteLanguage.Site))]
	public virtual ICollection<SiteLanguage> SiteLanguages { get; } = new List<SiteLanguage>();


	[InverseProperty(nameof(NavigationMenu.Site))]
	public virtual ICollection<NavigationMenu> NavigationMenus { get; } = new List<NavigationMenu>();


	[ForeignKey("ThemeId")]
	[InverseProperty(nameof(Theme.Sites))]
	public virtual Theme Theme { get; set; } = null!;

}

