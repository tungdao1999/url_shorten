
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UrlShortenAPI.Data;

namespace UrlShortenAPI.Models;

public partial class UrlShortenContext : UrlShortenIdentityContext
{
    public UrlShortenContext(DbContextOptions<UrlShortenContext> options)
        : base(options)
    {
    }

    public UrlShortenContext() { }

    public virtual DbSet<Url> Urls { get; set; }

    public override DbSet<IdentityUser> Users { get; set; }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
