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

[Table("Modules")]
public partial class Module : IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	[Column("Name")]
	[StringLength(1000)]
	public string Name { get; set; }
	
	[Column("Description")]
	[StringLength(1000)]
	public string Description { get; set; }
	
	[InverseProperty(nameof(Model.Module))]
	public virtual ICollection<Model> Models { get; } = new List<Model>();


	[InverseProperty(nameof(ApiMethodDefinition.Module))]
	public virtual ICollection<ApiMethodDefinition> ApiMethodDefinitions { get; } = new List<ApiMethodDefinition>();


	[InverseProperty(nameof(PortalPageDefinition.Module))]
	public virtual ICollection<PortalPageDefinition> PortalPageDefinitions { get; } = new List<PortalPageDefinition>();

}

