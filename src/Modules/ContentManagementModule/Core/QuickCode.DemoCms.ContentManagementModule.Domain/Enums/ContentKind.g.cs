using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.DemoCms.ContentManagementModule.Domain.Enums;

public enum ContentKind{
	[Description("A standard web page")]
	Page,
	[Description("A blog post or article")]
	Post,
	[Description("A reusable block of content")]
	Block,
	[Description("A smaller, embeddable content component")]
	Component
}
