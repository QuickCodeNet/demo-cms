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

[Table("ASSET_METADATAS")]
public partial class AssetMetadata : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("ASSET_ID")]
	public int AssetId { get; set; }
	
	[Column("KEY")]
	[StringLength(50)]
	public string Key { get; set; }
	
	[Column("VALUE")]
	[StringLength(1000)]
	public string Value { get; set; }
	
	[ForeignKey("AssetId")]
	[InverseProperty(nameof(Asset.AssetMetadataItems))]
	public virtual Asset Asset { get; set; } = null!;

}

