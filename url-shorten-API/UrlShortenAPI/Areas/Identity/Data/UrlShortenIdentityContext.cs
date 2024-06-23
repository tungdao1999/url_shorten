using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UrlShortenAPI.Data;

public class UrlShortenIdentityContext : IdentityDbContext<IdentityUser>
{
    public UrlShortenIdentityContext(DbContextOptions<UrlShortenIdentityContext> options)
        : base(options)
    {
    }

    protected UrlShortenIdentityContext(DbContextOptions options)
      : base(options)
    {
    }
    public UrlShortenIdentityContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseMySql("server=url-shorten.cfqqouewii7m.ap-southeast-2.rds.amazonaws.com;database=URL_Shorten;user id=admin;password=016485tung", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.35-mysql"));

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
