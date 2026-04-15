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

[Table("NAVIGATION_MENUS")]
public partial class NavigationMenu : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("SITE_ID")]
	public int SiteId { get; set; }
	
	[Column("NAME")]
	[StringLength(250)]
	public string Name { get; set; }
	
	[Column("LOCATION_KEY")]
	[StringLength(50)]
	public string LocationKey { get; set; }
	
	[InverseProperty(nameof(NavigationItem.NavigationMenu))]
	public virtual ICollection<NavigationItem> NavigationItems { get; } = new List<NavigationItem>();


	[ForeignKey("SiteId")]
	[InverseProperty(nameof(Site.NavigationMenus))]
	public virtual Site Site { get; set; } = null!;

}

