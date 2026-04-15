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

[Table("STORAGE_PROVIDERS")]
public partial class StorageProvider : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("NAME")]
	[StringLength(250)]
	public string Name { get; set; }
	
	[Column("TYPE", TypeName = "nvarchar(250)")]
	public StorageProviderType Type { get; set; }
	
	[Column("CONFIGURATION")]
	[StringLength(int.MaxValue)]
	public string Configuration { get; set; }
	
	[Column("IS_DEFAULT")]
	public bool IsDefault { get; set; }
	
	[Column("IS_ACTIVE")]
	public bool IsActive { get; set; }
	
	[InverseProperty(nameof(Asset.StorageProvider))]
	public virtual ICollection<Asset> Assets { get; } = new List<Asset>();

}

