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

[Table("LANGUAGES")]
public partial class Language : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("CODE")]
	[StringLength(50)]
	public string Code { get; set; }
	
	[Column("NAME")]
	[StringLength(250)]
	public string Name { get; set; }
	
	[Column("IS_DEFAULT")]
	public bool IsDefault { get; set; }
	
	[Column("IS_ACTIVE")]
	public bool IsActive { get; set; }
	
	[InverseProperty(nameof(LanguageFallback.Language))]
	public virtual ICollection<LanguageFallback> LanguageFallbackLanguage { get; } = new List<LanguageFallback>();


	[InverseProperty(nameof(LanguageFallback.FallbackLanguage))]
	public virtual ICollection<LanguageFallback> LanguageFallbackFallbackLanguage { get; } = new List<LanguageFallback>();


	[InverseProperty(nameof(TranslationValue.Language))]
	public virtual ICollection<TranslationValue> TranslationValues { get; } = new List<TranslationValue>();


	[InverseProperty(nameof(ResourceFile.Language))]
	public virtual ICollection<ResourceFile> ResourceFiles { get; } = new List<ResourceFile>();

}

