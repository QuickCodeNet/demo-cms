using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickCode.DemoCms.AssetManagementModule.Domain.Entities;
using QuickCode.DemoCms.AssetManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.AssetManagementModule.Persistence.Contexts;

public partial class ReadDbContext : DbContext
{
	public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options) { }


	public virtual DbSet<AssetFolder> AssetFolder { get; set; }

	public virtual DbSet<Asset> Asset { get; set; }

	public virtual DbSet<AssetTranslation> AssetTranslation { get; set; }

	public virtual DbSet<AssetMetadatum> AssetMetadatum { get; set; }

	public virtual DbSet<AssetRendition> AssetRendition { get; set; }

	public virtual DbSet<StorageProvider> StorageProvider { get; set; }

	public virtual DbSet<AuditLog> AuditLog { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{

		var converterAssetKind = new ValueConverter<AssetKind, string>(
		v => v.ToString(),
		v => (AssetKind)Enum.Parse(typeof(AssetKind), v));

		modelBuilder.Entity<Asset>()
		.Property(b => b.Kind)
		.HasConversion(converterAssetKind);

		modelBuilder.Entity<StorageProvider>()
		.Property(b => b.IsDefault)
		.IsRequired()
		.HasDefaultValue(false);

		modelBuilder.Entity<StorageProvider>()
		.Property(b => b.IsActive)
		.IsRequired()
		.HasDefaultValue(true);


		var converterStorageProviderType = new ValueConverter<StorageProviderType, string>(
		v => v.ToString(),
		v => (StorageProviderType)Enum.Parse(typeof(StorageProviderType), v));

		modelBuilder.Entity<StorageProvider>()
		.Property(b => b.Type)
		.HasConversion(converterStorageProviderType);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsChanged)
		.IsRequired()
		.HasDefaultValue(false);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsSuccess)
		.IsRequired()
		.HasDefaultValue(false);

		modelBuilder.Entity<AssetFolder>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<AssetFolder>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<Asset>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Asset>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<AssetTranslation>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<AssetTranslation>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<AssetMetadatum>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<AssetMetadatum>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<AssetRendition>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<AssetRendition>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<StorageProvider>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<StorageProvider>().HasQueryFilter(r => !r.IsDeleted);


		modelBuilder.Entity<AssetFolder>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<Asset>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<AssetTranslation>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<AssetMetadatum>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<AssetRendition>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<StorageProvider>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");


		modelBuilder.Entity<AssetFolder>()
			.HasOne(e => e.ParentFolder)
			.WithMany(p => p.AssetFolderParentFolder)
			.HasForeignKey(e => e.ParentFolderId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<Asset>()
			.HasOne(e => e.AssetFolder)
			.WithMany(p => p.Assets)
			.HasForeignKey(e => e.FolderId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<Asset>()
			.HasOne(e => e.StorageProvider)
			.WithMany(p => p.Assets)
			.HasForeignKey(e => e.StorageProviderId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<AssetTranslation>()
			.HasOne(e => e.Asset)
			.WithMany(p => p.AssetTranslations)
			.HasForeignKey(e => e.AssetId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<AssetMetadatum>()
			.HasOne(e => e.Asset)
			.WithMany(p => p.AssetMetadata)
			.HasForeignKey(e => e.AssetId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<AssetRendition>()
			.HasOne(e => e.Asset)
			.WithMany(p => p.AssetRenditions)
			.HasForeignKey(e => e.OriginalAssetId)
			.OnDelete(DeleteBehavior.Restrict);

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    public override int SaveChanges()
    {
        throw new InvalidOperationException("ReadDbContext is read-only.");
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new InvalidOperationException("ReadDbContext is read-only.");
    }

}
