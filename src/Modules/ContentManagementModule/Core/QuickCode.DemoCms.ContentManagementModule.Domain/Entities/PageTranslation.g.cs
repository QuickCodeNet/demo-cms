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

[Table("PAGE_TRANSLATIONS")]
public partial class PageTranslation : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("PAGE_ID")]
	public int PageId { get; set; }
	
	[Column("LANGUAGE_CODE")]
	[StringLength(50)]
	public string LanguageCode { get; set; }
	
	[Column("TITLE")]
	[StringLength(250)]
	public string Title { get; set; }
	
	[Column("SLUG")]
	[StringLength(50)]
	public string Slug { get; set; }
	
	[Column("CONTENT")]
	[StringLength(int.MaxValue)]
	public string Content { get; set; }
	
	[Column("SEO_TITLE")]
	[StringLength(250)]
	public string SeoTitle { get; set; }
	
	[Column("SEO_DESCRIPTION")]
	[StringLength(1000)]
	public string SeoDescription { get; set; }
	
	[ForeignKey("PageId")]
	[InverseProperty(nameof(Page.PageTranslations))]
	public virtual Page Page { get; set; } = null!;

}

