using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.DemoCms.LocalizationModule.Domain.Enums;

public enum ResourceFileFormat{
	[Description("Standard JSON format")]
	Json,
	[Description("YAML format")]
	Yaml,
	[Description("Gettext PO file format")]
	Po
}
