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

[Table("TRANSLATION_KEYS")]
public partial class TranslationKey : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("NAMESPACE_ID")]
	public int NamespaceId { get; set; }
	
	[Column("KEY")]
	[StringLength(250)]
	public string Key { get; set; }
	
	[Column("DEFAULT_VALUE")]
	[StringLength(1000)]
	public string DefaultValue { get; set; }
	
	[Column("CREATED_DATE")]
	public DateTime CreatedDate { get; set; }
	
	[InverseProperty(nameof(TranslationValue.TranslationKey))]
	public virtual ICollection<TranslationValue> TranslationValues { get; } = new List<TranslationValue>();


	[ForeignKey("NamespaceId")]
	[InverseProperty(nameof(Namespace.TranslationKeys))]
	public virtual Namespace Namespace { get; set; } = null!;

}

