using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoCms.ContentManagementModule.Domain;
using QuickCode.DemoCms.Common;
using QuickCode.DemoCms.Common.Auditing;

namespace QuickCode.DemoCms.ContentManagementModule.Domain.Entities;

[Table("TAGS")]
public partial class Tag : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("NAME")]
	[StringLength(50)]
	public string Name { get; set; }
	
	[Column("SLUG")]
	[StringLength(50)]
	public string Slug { get; set; }
	
	[InverseProperty(nameof(ContentTag.Tag))]
	public virtual ICollection<ContentTag> ContentTags { get; } = new List<ContentTag>();

}

