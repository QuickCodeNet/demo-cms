using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickCode.DemoCms.ContentManagementModule.Domain.Entities;
using QuickCode.DemoCms.ContentManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.ContentManagementModule.Persistence.Contexts;

public partial class ReadDbContext : DbContext
{
	public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options) { }


	public virtual DbSet<ContentType> ContentType { get; set; }

	public virtual DbSet<Page> Page { get; set; }

	public virtual DbSet<PageTranslation> PageTranslation { get; set; }

	public virtual DbSet<Post> Post { get; set; }

	public virtual DbSet<PostTranslation> PostTranslation { get; set; }

	public virtual DbSet<ContentBlock> ContentBlock { get; set; }

	public virtual DbSet<BlockTranslation> BlockTranslation { get; set; }

	public virtual DbSet<ContentVersion> ContentVersion { get; set; }

	public virtual DbSet<Tag> Tag { get; set; }

	public virtual DbSet<ContentTag> ContentTag { get; set; }

	public virtual DbSet<AuditLog> AuditLog { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<ContentType>()
		.Property(b => b.IsActive)
		.IsRequired()
		.HasDefaultValue(true);


		var converterContentTypeKind = new ValueConverter<ContentKind, string>(
		v => v.ToString(),
		v => (ContentKind)Enum.Parse(typeof(ContentKind), v));

		modelBuilder.Entity<ContentType>()
		.Property(b => b.Kind)
		.HasConversion(converterContentTypeKind);

		modelBuilder.Entity<Page>()
		.Property(b => b.Status)
		.IsRequired()
		.HasDefaultValueSql("'DRAFT'");


		var converterPageStatus = new ValueConverter<ContentStatus, string>(
		v => v.ToString(),
		v => (ContentStatus)Enum.Parse(typeof(ContentStatus), v));

		modelBuilder.Entity<Page>()
		.Property(b => b.Status)
		.HasConversion(converterPageStatus);

		modelBuilder.Entity<Post>()
		.Property(b => b.Status)
		.IsRequired()
		.HasDefaultValueSql("'DRAFT'");


		var converterPostStatus = new ValueConverter<ContentStatus, string>(
		v => v.ToString(),
		v => (ContentStatus)Enum.Parse(typeof(ContentStatus), v));

		modelBuilder.Entity<Post>()
		.Property(b => b.Status)
		.HasConversion(converterPostStatus);

		modelBuilder.Entity<ContentBlock>()
		.Property(b => b.IsActive)
		.IsRequired()
		.HasDefaultValue(true);


		var converterContentVersionContentTypeKind = new ValueConverter<ContentKind, string>(
		v => v.ToString(),
		v => (ContentKind)Enum.Parse(typeof(ContentKind), v));

		modelBuilder.Entity<ContentVersion>()
		.Property(b => b.ContentTypeKind)
		.HasConversion(converterContentVersionContentTypeKind);


		var converterContentTagContentTypeKind = new ValueConverter<ContentKind, string>(
		v => v.ToString(),
		v => (ContentKind)Enum.Parse(typeof(ContentKind), v));

		modelBuilder.Entity<ContentTag>()
		.Property(b => b.ContentTypeKind)
		.HasConversion(converterContentTagContentTypeKind);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsChanged)
		.IsRequired()
		.HasDefaultValue(false);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsSuccess)
		.IsRequired()
		.HasDefaultValue(false);

		modelBuilder.Entity<ContentType>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<ContentType>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<Page>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Page>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<PageTranslation>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<PageTranslation>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<Post>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Post>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<PostTranslation>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<PostTranslation>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<ContentBlock>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<ContentBlock>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<BlockTranslation>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<BlockTranslation>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<ContentVersion>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<ContentVersion>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<Tag>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Tag>().HasQueryFilter(r => !r.IsDeleted);


		modelBuilder.Entity<ContentType>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<Page>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<PageTranslation>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<Post>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<PostTranslation>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<ContentBlock>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<BlockTranslation>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<ContentVersion>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<Tag>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");


		modelBuilder.Entity<Page>()
			.HasOne(e => e.ContentType)
			.WithMany(p => p.Pages)
			.HasForeignKey(e => e.ContentTypeId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<Page>()
			.HasOne(e => e.ParentPage)
			.WithMany(p => p.PageParentPage)
			.HasForeignKey(e => e.ParentPageId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<PageTranslation>()
			.HasOne(e => e.Page)
			.WithMany(p => p.PageTranslations)
			.HasForeignKey(e => e.PageId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<Post>()
			.HasOne(e => e.ContentType)
			.WithMany(p => p.Posts)
			.HasForeignKey(e => e.ContentTypeId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<PostTranslation>()
			.HasOne(e => e.Post)
			.WithMany(p => p.PostTranslations)
			.HasForeignKey(e => e.PostId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<ContentBlock>()
			.HasOne(e => e.ContentType)
			.WithMany(p => p.ContentBlocks)
			.HasForeignKey(e => e.ContentTypeId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<BlockTranslation>()
			.HasOne(e => e.ContentBlock)
			.WithMany(p => p.BlockTranslations)
			.HasForeignKey(e => e.BlockId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<ContentTag>()
			.HasOne(e => e.Tag)
			.WithMany(p => p.ContentTags)
			.HasForeignKey(e => e.TagId)
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
