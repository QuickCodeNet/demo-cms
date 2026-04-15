using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.DemoCms.ContentManagementModule.Domain.Enums;

public enum ContentStatus{
	[Description("Content is in a draft state and not visible")]
	Draft,
	[Description("Content is awaiting approval")]
	PendingReview,
	[Description("Content is live and publicly visible")]
	Published,
	[Description("Content is no longer visible but retained")]
	Archived
}
