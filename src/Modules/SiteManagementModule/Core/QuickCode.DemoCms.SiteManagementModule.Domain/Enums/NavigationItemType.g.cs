using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.DemoCms.SiteManagementModule.Domain.Enums;

public enum NavigationItemType{
	[Description("Links to an internal page within the CMS")]
	PageLink,
	[Description("Links to an absolute external URL")]
	ExternalUrl,
	[Description("A custom application route")]
	CustomRoute
}
