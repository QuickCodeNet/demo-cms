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

[Table("TRANSLATION_VALUES")]
public partial class TranslationValue : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("KEY_ID")]
	public int KeyId { get; set; }
	
	[Column("LANGUAGE_ID")]
	public int LanguageId { get; set; }
	
	[Column("VALUE")]
	[StringLength(int.MaxValue)]
	public string Value { get; set; }
	
	[Column("UPDATED_DATE")]
	public DateTime UpdatedDate { get; set; }
	
	[ForeignKey("KeyId")]
	[InverseProperty(nameof(TranslationKey.TranslationValues))]
	public virtual TranslationKey TranslationKey { get; set; } = null!;


	[ForeignKey("LanguageId")]
	[InverseProperty(nameof(Language.TranslationValues))]
	public virtual Language Language { get; set; } = null!;

}

