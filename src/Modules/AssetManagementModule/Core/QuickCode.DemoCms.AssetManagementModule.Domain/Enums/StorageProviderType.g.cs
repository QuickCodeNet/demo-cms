using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace QuickCode.DemoCms.AssetManagementModule.Domain.Enums;

public enum StorageProviderType{
	[Description("Stored on the local server disk")]
	LocalFilesystem,
	[Description("Amazon S3 cloud storage")]
	AwsS3,
	[Description("Microsoft Azure Blob Storage")]
	AzureBlob,
	[Description("Google Cloud Platform Storage")]
	GcpStorage
}
