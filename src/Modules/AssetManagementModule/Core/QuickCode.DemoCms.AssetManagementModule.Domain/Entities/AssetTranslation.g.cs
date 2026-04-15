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

[Table("ASSET_TRANSLATIONS")]
public partial class AssetTranslation : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("ASSET_ID")]
	public int AssetId { get; set; }
	
	[Column("LANGUAGE_CODE")]
	[StringLength(50)]
	public string LanguageCode { get; set; }
	
	[Column("TITLE")]
	[StringLength(250)]
	public string Title { get; set; }
	
	[Column("ALT_TEXT")]
	[StringLength(250)]
	public string AltText { get; set; }
	
	[Column("CAPTION")]
	[StringLength(1000)]
	public string Caption { get; set; }
	
	[ForeignKey("AssetId")]
	[InverseProperty(nameof(Asset.AssetTranslations))]
	public virtual Asset Asset { get; set; } = null!;

}

