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

[Table("ASSET_FOLDERS")]
public partial class AssetFolder : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("PARENT_FOLDER_ID")]
	public int ParentFolderId { get; set; }
	
	[Column("NAME")]
	[StringLength(250)]
	public string Name { get; set; }
	
	[Column("PATH")]
	[StringLength(1000)]
	public string Path { get; set; }
	
	[Column("CREATED_DATE")]
	public DateTime CreatedDate { get; set; }
	
	[InverseProperty(nameof(AssetFolder.ParentFolder))]
	public virtual ICollection<AssetFolder> AssetFolderParentFolder { get; } = new List<AssetFolder>();


	[InverseProperty(nameof(Asset.AssetFolder))]
	public virtual ICollection<Asset> Assets { get; } = new List<Asset>();


	[ForeignKey("ParentFolderId")]
	[InverseProperty(nameof(AssetFolder.AssetFolderParentFolder))]
	public virtual AssetFolder ParentFolder { get; set; } = null!;

}

