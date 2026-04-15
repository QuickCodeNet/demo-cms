using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoCms.AssetManagementModule.Domain;
using QuickCode.DemoCms.Common;
using QuickCode.DemoCms.Common.Auditing;
using QuickCode.DemoCms.AssetManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.AssetManagementModule.Domain.Entities;

[Table("ASSETS")]
public partial class Asset : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("FOLDER_ID")]
	public int FolderId { get; set; }
	
	[Column("FILENAME")]
	[StringLength(250)]
	public string Filename { get; set; }
	
	[Column("FILE_SIZE_BYTES")]
	public long FileSizeBytes { get; set; }
	
	[Column("MIME_TYPE")]
	[StringLength(50)]
	public string MimeType { get; set; }
	
	[Column("KIND", TypeName = "nvarchar(250)")]
	public AssetKind Kind { get; set; }
	
	[Column("STORAGE_PROVIDER_ID")]
	public int StorageProviderId { get; set; }
	
	[Column("STORAGE_PATH")]
	[StringLength(1000)]
	public string StoragePath { get; set; }
	
	[Column("CREATED_DATE")]
	public DateTime CreatedDate { get; set; }
	
	[InverseProperty(nameof(AssetTranslation.Asset))]
	public virtual ICollection<AssetTranslation> AssetTranslations { get; } = new List<AssetTranslation>();


	[InverseProperty(nameof(AssetMetadata.Asset))]
	public virtual ICollection<AssetMetadata> AssetMetadataItems { get; } = new List<AssetMetadata>();


	[InverseProperty(nameof(AssetRendition.Asset))]
	public virtual ICollection<AssetRendition> AssetRenditions { get; } = new List<AssetRendition>();


	[ForeignKey("FolderId")]
	[InverseProperty(nameof(AssetFolder.Assets))]
	public virtual AssetFolder AssetFolder { get; set; } = null!;


	[ForeignKey("StorageProviderId")]
	[InverseProperty(nameof(StorageProvider.Assets))]
	public virtual StorageProvider StorageProvider { get; set; } = null!;

}

