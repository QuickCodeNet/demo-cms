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

[Table("POSTS")]
public partial class Post : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("ID")]
	public int Id { get; set; }
	
	[Column("CONTENT_TYPE_ID")]
	public int ContentTypeId { get; set; }
	
	[Column("AUTHOR_ID")]
	public int AuthorId { get; set; }
	
	[Column("STATUS", TypeName = "nvarchar(250)")]
	public ContentStatus Status { get; set; }
	
	[Column("PUBLISH_DATE")]
	public DateTime PublishDate { get; set; }
	
	[Column("CREATED_DATE")]
	public DateTime CreatedDate { get; set; }
	
	[Column("UPDATED_DATE")]
	public DateTime UpdatedDate { get; set; }
	
	[InverseProperty(nameof(PostTranslation.Post))]
	public virtual ICollection<PostTranslation> PostTranslations { get; } = new List<PostTranslation>();


	[ForeignKey("ContentTypeId")]
	[InverseProperty(nameof(ContentType.Posts))]
	public virtual ContentType ContentType { get; set; } = null!;

}

