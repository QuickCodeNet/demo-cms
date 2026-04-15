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

[Table("BLOCK_TRANSLATIONS")]
public partial class BlockTranslation : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("BLOCK_ID")]
	public int BlockId { get; set; }
	
	[Column("LANGUAGE_CODE")]
	[StringLength(50)]
	public string LanguageCode { get; set; }
	
	[Column("CONTENT")]
	[StringLength(int.MaxValue)]
	public string Content { get; set; }
	
	[ForeignKey("BlockId")]
	[InverseProperty(nameof(ContentBlock.BlockTranslations))]
	public virtual ContentBlock ContentBlock { get; set; } = null!;

}

