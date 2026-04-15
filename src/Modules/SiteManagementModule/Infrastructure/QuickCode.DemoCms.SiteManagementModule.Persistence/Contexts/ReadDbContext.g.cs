using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickCode.DemoCms.SiteManagementModule.Domain.Entities;
using DomainEntity = QuickCode.DemoCms.SiteManagementModule.Domain.Entities.Domain;
using QuickCode.DemoCms.SiteManagementModule.Domain.Enums;

namespace QuickCode.DemoCms.SiteManagementModule.Persistence.Contexts;

public partial class ReadDbContext : DbContext
{
	public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options) { }


	public virtual DbSet<Site> Site { get; set; }

	public virtual DbSet<DomainEntity> Domain { get; set; }

	public virtual DbSet<SiteSetting> SiteSetting { get; set; }

	public virtual DbSet<SiteLanguage> SiteLanguage { get; set; }

	public virtual DbSet<Theme> Theme { get; set; }

	public virtual DbSet<Template> Template { get; set; }

	public virtual DbSet<NavigationMenu> NavigationMenu { get; set; }

	public virtual DbSet<NavigationItem> NavigationItem { get; set; }

	public virtual DbSet<AuditLog> AuditLog { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Site>()
		.Property(b => b.IsActive)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<DomainEntity>()
		.Property(b => b.IsPrimary)
		.IsRequired()
		.HasDefaultValue(false);

		modelBuilder.Entity<DomainEntity>()
		.Property(b => b.IsActive)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<SiteSetting>()
		.Property(b => b.IsSecret)
		.IsRequired()
		.HasDefaultValue(false);

		modelBuilder.Entity<SiteLanguage>()
		.Property(b => b.IsEnabled)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<Theme>()
		.Property(b => b.IsActive)
		.IsRequired()
		.HasDefaultValue(true);

		modelBuilder.Entity<NavigationItem>()
		.Property(b => b.SortOrder)
		.IsRequired()
		.HasDefaultValueSql("0");

		modelBuilder.Entity<NavigationItem>()
		.Property(b => b.IsVisible)
		.IsRequired()
		.HasDefaultValue(true);


		var converterNavigationItemType = new ValueConverter<NavigationItemType, string>(
		v => v.ToString(),
		v => (NavigationItemType)Enum.Parse(typeof(NavigationItemType), v));

		modelBuilder.Entity<NavigationItem>()
		.Property(b => b.Type)
		.HasConversion(converterNavigationItemType);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsChanged)
		.IsRequired()
		.HasDefaultValue(false);

		modelBuilder.Entity<AuditLog>()
		.Property(b => b.IsSuccess)
		.IsRequired()
		.HasDefaultValue(false);

		modelBuilder.Entity<Site>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Site>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<DomainEntity>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<DomainEntity>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<SiteSetting>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<SiteSetting>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<Theme>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Theme>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<Template>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<Template>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<NavigationMenu>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<NavigationMenu>().HasQueryFilter(r => !r.IsDeleted);

		modelBuilder.Entity<NavigationItem>().Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
		modelBuilder.Entity<NavigationItem>().HasQueryFilter(r => !r.IsDeleted);


		modelBuilder.Entity<Site>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<DomainEntity>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<SiteSetting>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<Theme>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<Template>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<NavigationMenu>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");
		modelBuilder.Entity<NavigationItem>().HasIndex(r => r.IsDeleted).HasFilter("IsDeleted = 0");


		modelBuilder.Entity<Site>()
			.HasOne(e => e.Theme)
			.WithMany(p => p.Sites)
			.HasForeignKey(e => e.ThemeId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<DomainEntity>()
			.HasOne(e => e.Site)
			.WithMany(p => p.Domains)
			.HasForeignKey(e => e.SiteId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<SiteSetting>()
			.HasOne(e => e.Site)
			.WithMany(p => p.SiteSettings)
			.HasForeignKey(e => e.SiteId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<SiteLanguage>()
			.HasOne(e => e.Site)
			.WithMany(p => p.SiteLanguages)
			.HasForeignKey(e => e.SiteId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<Template>()
			.HasOne(e => e.Theme)
			.WithMany(p => p.Templates)
			.HasForeignKey(e => e.ThemeId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<NavigationMenu>()
			.HasOne(e => e.Site)
			.WithMany(p => p.NavigationMenus)
			.HasForeignKey(e => e.SiteId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<NavigationItem>()
			.HasOne(e => e.NavigationMenu)
			.WithMany(p => p.NavigationItems)
			.HasForeignKey(e => e.MenuId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<NavigationItem>()
			.HasOne(e => e.ParentItem)
			.WithMany(p => p.NavigationItemParentItem)
			.HasForeignKey(e => e.ParentItemId)
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
