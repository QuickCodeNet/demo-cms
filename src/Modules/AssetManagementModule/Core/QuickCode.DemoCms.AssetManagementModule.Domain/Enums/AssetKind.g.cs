using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.DemoCms.AssetManagementModule.Domain.Enums;

public enum AssetKind{
	[Description("Image files like JPG, PNG, GIF")]
	Image,
	[Description("Video files like MP4, MOV")]
	Video,
	[Description("Document files like PDF, DOCX")]
	Document,
	[Description("Audio files like MP3, WAV")]
	Audio,
	[Description("Archive files like ZIP, RAR")]
	Archive,
	[Description("Uncategorized or unknown file types")]
	Unknown
}
