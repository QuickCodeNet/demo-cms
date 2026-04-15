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

[Table("AspNetRoleClaims")]
public partial class AspNetRoleClaim : IAuditableEntity 
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column("Id")]
	public int Id { get; set; }
	
	[Column("RoleId")]
	[StringLength(450)]
	public string RoleId { get; set; }
	
	[Column("ClaimType")]
	[StringLength(int.MaxValue)]
	public string? ClaimType { get; set; }
	
	[Column("ClaimValue")]
	[StringLength(int.MaxValue)]
	public string? ClaimValue { get; set; }
	
	[ForeignKey("RoleId")]
	[InverseProperty(nameof(AspNetRole.AspNetRoleClaims))]
	public virtual AspNetRole AspNetRole { get; set; } = null!;

}

