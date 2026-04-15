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

[Table("POST_TRANSLATIONS")]
public partial class PostTranslation : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("POST_ID")]
	public int PostId { get; set; }
	
	[Column("LANGUAGE_CODE")]
	[StringLength(50)]
	public string LanguageCode { get; set; }
	
	[Column("TITLE")]
	[StringLength(250)]
	public string Title { get; set; }
	
	[Column("SLUG")]
	[StringLength(50)]
	public string Slug { get; set; }
	
	[Column("EXCERPT")]
	[StringLength(1000)]
	public string Excerpt { get; set; }
	
	[Column("CONTENT")]
	[StringLength(int.MaxValue)]
	public string Content { get; set; }
	
	[ForeignKey("PostId")]
	[InverseProperty(nameof(Post.PostTranslations))]
	public virtual Post Post { get; set; } = null!;

}

