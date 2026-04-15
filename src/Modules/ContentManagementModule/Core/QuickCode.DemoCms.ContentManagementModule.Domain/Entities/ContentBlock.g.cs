using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoCms.ContentManagementModule.Domain;
using QuickCode.DemoCms.Common;
using QuickCode.DemoCms.Common.Auditing;

namespace QuickCode.DemoCms.ContentManagementModule.Domain.Entities;

[Table("CONTENT_BLOCKS")]
public partial class ContentBlock : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("CONTENT_TYPE_ID")]
	public int ContentTypeId { get; set; }
	
	[Column("KEY")]
	[StringLength(50)]
	public string Key { get; set; }
	
	[Column("DESCRIPTION")]
	[StringLength(1000)]
	public string Description { get; set; }
	
	[Column("IS_ACTIVE")]
	public bool IsActive { get; set; }
	
	[InverseProperty(nameof(BlockTranslation.ContentBlock))]
	public virtual ICollection<BlockTranslation> BlockTranslations { get; } = new List<BlockTranslation>();


	[ForeignKey("ContentTypeId")]
	[InverseProperty(nameof(ContentType.ContentBlocks))]
	public virtual ContentType ContentType { get; set; } = null!;

}

