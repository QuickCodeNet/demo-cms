using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoCms.ContentManagementModule.Domain;
using QuickCode.DemoCms.Common;
using QuickCode.DemoCms.Common.Auditing;
using QuickCode.DemoCms.ContentManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.ContentManagementModule.Domain.Entities;

[Table("CONTENT_VERSIONS")]
public partial class ContentVersion : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("CONTENT_TYPE_KIND", TypeName = "nvarchar(250)")]
	public ContentKind ContentTypeKind { get; set; }
	
	[Column("CONTENT_ID")]
	public int ContentId { get; set; }
	
	[Column("TRANSLATION_ID")]
	public int TranslationId { get; set; }
	
	[Column("VERSION_NUMBER")]
	public int VersionNumber { get; set; }
	
	[Column("CONTENT_SNAPSHOT")]
	[StringLength(int.MaxValue)]
	public string ContentSnapshot { get; set; }
	
	[Column("CREATED_BY_USER_ID")]
	public int CreatedByUserId { get; set; }
	
	[Column("CREATED_DATE")]
	public DateTime CreatedDate { get; set; }
	}

