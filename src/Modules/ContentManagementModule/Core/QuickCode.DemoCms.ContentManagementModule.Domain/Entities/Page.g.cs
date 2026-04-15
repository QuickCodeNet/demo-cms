using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoCms.ContentManagementModule.Domain;
using QuickCode.DemoCms.Common;
using QuickCode.DemoCms.Common.Auditing;
using QuickCode.DemoCms.ContentManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.ContentManagementModule.Domain.Entities;

[Table("PAGES")]
public partial class Page : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("CONTENT_TYPE_ID")]
	public int ContentTypeId { get; set; }
	
	[Column("PARENT_PAGE_ID")]
	public int ParentPageId { get; set; }
	
	[Column("STATUS", TypeName = "nvarchar(250)")]
	public ContentStatus Status { get; set; }
	
	[Column("PUBLISH_DATE")]
	public DateTime PublishDate { get; set; }
	
	[Column("CREATED_DATE")]
	public DateTime CreatedDate { get; set; }
	
	[Column("UPDATED_DATE")]
	public DateTime UpdatedDate { get; set; }
	
	[InverseProperty(nameof(Page.ParentPage))]
	public virtual ICollection<Page> PageParentPage { get; } = new List<Page>();


	[InverseProperty(nameof(PageTranslation.Page))]
	public virtual ICollection<PageTranslation> PageTranslations { get; } = new List<PageTranslation>();


	[ForeignKey("ContentTypeId")]
	[InverseProperty(nameof(ContentType.Pages))]
	public virtual ContentType ContentType { get; set; } = null!;


	[ForeignKey("ParentPageId")]
	[InverseProperty(nameof(Page.PageParentPage))]
	public virtual Page ParentPage { get; set; } = null!;

}

