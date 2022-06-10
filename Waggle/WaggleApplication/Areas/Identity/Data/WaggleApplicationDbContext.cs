using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WaggleApplication.Areas.Identity.Data;

namespace WaggleApplication.Areas.Identity.Data;

public class WaggleApplicationDbContext : IdentityDbContext<WaggleApplicationUser>
{
    public WaggleApplicationDbContext(DbContextOptions<WaggleApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new WaggleApplicationUserEntityConfiguration());
    }
}
public class WaggleApplicationUserEntityConfiguration : IEntityTypeConfiguration<WaggleApplicationUser>
{
    public void Configure(EntityTypeBuilder<WaggleApplicationUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(255);
        builder.Property(u => u.LastName).HasMaxLength(255);
    }
}
