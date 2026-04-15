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

[Table("CONTENT_TYPES")]
public partial class ContentType : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("NAME")]
	[StringLength(250)]
	public string Name { get; set; }
	
	[Column("API_KEY")]
	[StringLength(50)]
	public string ApiKey { get; set; }
	
	[Column("KIND", TypeName = "nvarchar(250)")]
	public ContentKind Kind { get; set; }
	
	[Column("DESCRIPTION")]
	[StringLength(1000)]
	public string Description { get; set; }
	
	[Column("IS_ACTIVE")]
	public bool IsActive { get; set; }
	
	[InverseProperty(nameof(Page.ContentType))]
	public virtual ICollection<Page> Pages { get; } = new List<Page>();


	[InverseProperty(nameof(Post.ContentType))]
	public virtual ICollection<Post> Posts { get; } = new List<Post>();


	[InverseProperty(nameof(ContentBlock.ContentType))]
	public virtual ICollection<ContentBlock> ContentBlocks { get; } = new List<ContentBlock>();

}

