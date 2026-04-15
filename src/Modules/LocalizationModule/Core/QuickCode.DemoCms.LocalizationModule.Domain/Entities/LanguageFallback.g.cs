using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoCms.LocalizationModule.Domain;
using QuickCode.DemoCms.Common;
using QuickCode.DemoCms.Common.Auditing;

namespace QuickCode.DemoCms.LocalizationModule.Domain.Entities;

[PrimaryKey("LanguageId", "FallbackLanguageId")]
[Table("LANGUAGE_FALLBACKS")]
public partial class LanguageFallback : IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	[Column("LANGUAGE_ID")]
	public int LanguageId { get; set; }
	
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	[Column("FALLBACK_LANGUAGE_ID")]
	public int FallbackLanguageId { get; set; }
	
	[Column("PRIORITY")]
	public int Priority { get; set; }
	
	[ForeignKey("LanguageId")]
	[InverseProperty(nameof(Language.LanguageFallbackLanguage))]
	public virtual Language Language { get; set; } = null!;


	[ForeignKey("FallbackLanguageId")]
	[InverseProperty(nameof(Language.LanguageFallbackFallbackLanguage))]
	public virtual Language FallbackLanguage { get; set; } = null!;

}

