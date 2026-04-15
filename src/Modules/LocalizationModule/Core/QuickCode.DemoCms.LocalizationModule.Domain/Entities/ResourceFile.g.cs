using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoCms.LocalizationModule.Domain;
using QuickCode.DemoCms.Common;
using QuickCode.DemoCms.Common.Auditing;
using QuickCode.DemoCms.LocalizationModule.Domain.Enums;

namespace QuickCode.DemoCms.LocalizationModule.Domain.Entities;

[Table("RESOURCE_FILES")]
public partial class ResourceFile : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("FILENAME")]
	[StringLength(250)]
	public string Filename { get; set; }
	
	[Column("FORMAT", TypeName = "nvarchar(250)")]
	public ResourceFileFormat Format { get; set; }
	
	[Column("LANGUAGE_ID")]
	public int LanguageId { get; set; }
	
	[Column("UPLOADED_BY_USER_ID")]
	public int UploadedByUserId { get; set; }
	
	[Column("UPLOADED_DATE")]
	public DateTime UploadedDate { get; set; }
	
	[Column("PROCESSED_DATE")]
	public DateTime ProcessedDate { get; set; }
	
	[Column("STATUS")]
	[StringLength(50)]
	public string Status { get; set; }
	
	[ForeignKey("LanguageId")]
	[InverseProperty(nameof(Language.ResourceFiles))]
	public virtual Language Language { get; set; } = null!;

}

