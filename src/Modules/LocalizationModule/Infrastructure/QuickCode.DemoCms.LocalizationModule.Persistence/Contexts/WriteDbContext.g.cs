using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickCode.DemoCms.LocalizationModule.Domain.Entities;
using QuickCode.DemoCms.LocalizationModule.Domain.Enums;

namespace QuickCode.DemoCms.LocalizationModule.Persistence.Contexts;

public partial class WriteDbContext : DbContext
{
	public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options) { }


	public virtual DbSet<Language> Language { get; set; }

	public virtual DbSet<LanguageFallback> LanguageFallback { get; set; }

	public virtual DbSet<Namespace> Namespace { get; set; }

	public virtual DbSet<TranslationKey> TranslationKey { get; set; }

	public virtual DbSet<TranslationValue> TranslationValue { get; set; }

	public virtual DbSet<ResourceFile> ResourceFile { get; set; }

	public virtual DbSet<AuditLog> AuditLog { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Language>()
		.Property(b => b.IsDefault)
		.IsRequired()
		.HasDefaultValue(false);

		modelBuilder.Entity<Language>()
		.Property(b => b.IsActive)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<Namespace>()
		.Property(b => b.IsActive)
		.IsRequired()
		.HasDefaultValue(true);


		var converterResourceFileFormat = new ValueConverter<ResourceFileFormat, string>(
		v => v.ToString(),
		v => (ResourceFileFormat)Enum.Parse(typeof(ResourceFileFormat), v));

		modelBuilder.Entity<ResourceFile>()
		.Property(b => b.Format)
		.HasConversion(converterResourceFileFormat);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsChanged)
		.IsRequired()
		.HasDefaultValue(false);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsSuccess)
		.IsRequired()
		.HasDefaultValue(false);

		modelBuilder.Entity<Language>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Language>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<Namespace>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Namespace>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<TranslationKey>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<TranslationKey>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<TranslationValue>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<TranslationValue>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<ResourceFile>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<ResourceFile>().HasQueryFilter(r => !r.IsDeleted);


		modelBuilder.Entity<Language>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<Namespace>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<TranslationKey>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<TranslationValue>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<ResourceFile>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");


		modelBuilder.Entity<LanguageFallback>()
			.HasOne(e => e.FallbackLanguage)
			.WithMany(p => p.LanguageFallbackFallbackLanguage)
			.HasForeignKey(e => e.FallbackLanguageId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<LanguageFallback>()
			.HasOne(e => e.Language)
			.WithMany(p => p.LanguageFallbackLanguage)
			.HasForeignKey(e => e.LanguageId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<TranslationKey>()
			.HasOne(e => e.Namespace)
			.WithMany(p => p.TranslationKeys)
			.HasForeignKey(e => e.NamespaceId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<TranslationValue>()
			.HasOne(e => e.TranslationKey)
			.WithMany(p => p.TranslationValues)
			.HasForeignKey(e => e.KeyId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<TranslationValue>()
			.HasOne(e => e.Language)
			.WithMany(p => p.TranslationValues)
			.HasForeignKey(e => e.LanguageId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<ResourceFile>()
			.HasOne(e => e.Language)
			.WithMany(p => p.ResourceFiles)
			.HasForeignKey(e => e.LanguageId)
			.OnDelete(DeleteBehavior.Restrict);

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
