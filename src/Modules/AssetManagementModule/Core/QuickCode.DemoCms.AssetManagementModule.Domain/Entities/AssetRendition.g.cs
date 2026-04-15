using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoCms.AssetManagementModule.Domain;
using QuickCode.DemoCms.Common;
using QuickCode.DemoCms.Common.Auditing;

namespace QuickCode.DemoCms.AssetManagementModule.Domain.Entities;

[Table("ASSET_RENDITIONS")]
public partial class AssetRendition : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("ORIGINAL_ASSET_ID")]
	public int OriginalAssetId { get; set; }
	
	[Column("NAME")]
	[StringLength(50)]
	public string Name { get; set; }
	
	[Column("WIDTH")]
	public int Width { get; set; }
	
	[Column("HEIGHT")]
	public int Height { get; set; }
	
	[Column("FILE_SIZE_BYTES")]
	public long FileSizeBytes { get; set; }
	
	[Column("MIME_TYPE")]
	[StringLength(50)]
	public string MimeType { get; set; }
	
	[Column("STORAGE_PATH")]
	[StringLength(1000)]
	public string StoragePath { get; set; }
	
	[ForeignKey("OriginalAssetId")]
	[InverseProperty(nameof(Asset.AssetRenditions))]
	public virtual Asset Asset { get; set; } = null!;

}

