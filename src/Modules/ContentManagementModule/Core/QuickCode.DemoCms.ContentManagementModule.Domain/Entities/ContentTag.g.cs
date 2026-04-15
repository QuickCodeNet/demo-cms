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

[PrimaryKey("ContentTypeKind", "ContentId", "TagId")]
[Table("CONTENT_TAGS")]
public partial class ContentTag : IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	[Column("CONTENT_TYPE_KIND", TypeName = "nvarchar(250)")]
	public ContentKind ContentTypeKind { get; set; }
	
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	[Column("CONTENT_ID")]
	public int ContentId { get; set; }
	
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	[Column("TAG_ID")]
	public int TagId { get; set; }
	
	[ForeignKey("TagId")]
	[InverseProperty(nameof(Tag.ContentTags))]
	public virtual Tag Tag { get; set; } = null!;

}

