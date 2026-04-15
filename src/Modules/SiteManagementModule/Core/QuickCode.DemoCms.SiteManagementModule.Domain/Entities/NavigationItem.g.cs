using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoCms.SiteManagementModule.Domain;
using QuickCode.DemoCms.Common;
using QuickCode.DemoCms.Common.Auditing;
using QuickCode.DemoCms.SiteManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.SiteManagementModule.Domain.Entities;

[Table("NAVIGATION_ITEMS")]
public partial class NavigationItem : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("MENU_ID")]
	public int MenuId { get; set; }
	
	[Column("PARENT_ITEM_ID")]
	public int ParentItemId { get; set; }
	
	[Column("TYPE", TypeName = "nvarchar(250)")]
	public NavigationItemType Type { get; set; }
	
	[Column("LABEL")]
	[StringLength(250)]
	public string Label { get; set; }
	
	[Column("URL")]
	[StringLength(1000)]
	public string Url { get; set; }
	
	[Column("PAGE_ID")]
	public int PageId { get; set; }
	
	[Column("SORT_ORDER")]
	public int SortOrder { get; set; }
	
	[Column("IS_VISIBLE")]
	public bool IsVisible { get; set; }
	
	[InverseProperty(nameof(NavigationItem.ParentItem))]
	public virtual ICollection<NavigationItem> NavigationItemParentItem { get; } = new List<NavigationItem>();


	[ForeignKey("MenuId")]
	[InverseProperty(nameof(NavigationMenu.NavigationItems))]
	public virtual NavigationMenu NavigationMenu { get; set; } = null!;


	[ForeignKey("ParentItemId")]
	[InverseProperty(nameof(NavigationItem.NavigationItemParentItem))]
	public virtual NavigationItem ParentItem { get; set; } = null!;

}

