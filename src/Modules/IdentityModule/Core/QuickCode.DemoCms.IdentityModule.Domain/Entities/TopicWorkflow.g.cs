using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using QuickCode.DemoCms.IdentityModule.Domain;
using QuickCode.DemoCms.Common;
using QuickCode.DemoCms.Common.Auditing;

namespace QuickCode.DemoCms.IdentityModule.Domain.Entities;

[Table("TopicWorkflows")]
public partial class TopicWorkflow : BaseSoftDeletable, IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("Id")]
	public int Id { get; set; }
	
	[Column("KafkaEventsTopicName")]
	[StringLength(1000)]
	public string KafkaEventsTopicName { get; set; }
	
	[Column("WorkflowContent")]
	[StringLength(int.MaxValue)]
	public string WorkflowContent { get; set; }
	
	[ForeignKey("KafkaEventsTopicName")]
	[InverseProperty(nameof(KafkaEvent.TopicWorkflows))]
	public virtual KafkaEvent KafkaEvent { get; set; } = null!;

}

