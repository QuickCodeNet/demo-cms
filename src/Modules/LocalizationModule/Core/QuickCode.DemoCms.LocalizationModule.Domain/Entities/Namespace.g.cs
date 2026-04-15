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

[Table("NAMESPACES")]
public partial class Namespace : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("NAME")]
	[StringLength(50)]
	public string Name { get; set; }
	
	[Column("DESCRIPTION")]
	[StringLength(1000)]
	public string Description { get; set; }
	
	[Column("IS_ACTIVE")]
	public bool IsActive { get; set; }
	
	[InverseProperty(nameof(TranslationKey.Namespace))]
	public virtual ICollection<TranslationKey> TranslationKeys { get; } = new List<TranslationKey>();

}

