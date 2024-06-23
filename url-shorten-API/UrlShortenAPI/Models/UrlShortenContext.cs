
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Url>(entity =>
        {
            entity.HasKey(e => e.Hash).HasName("PRIMARY");

            entity.ToTable("urls");

            entity.HasIndex(e => e.Hash, "hash_url_index");

            entity.Property(e => e.Hash)
                .HasMaxLength(100)
                .HasColumnName("hash");
            entity.Property(e => e.Expiration)
                .HasColumnType("timestamp")
                .HasColumnName("expiration");
            entity.Property(e => e.OriginalUrl).HasMaxLength(255);
            entity.Property(e => e.UserId).HasColumnName("userId");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Mail)
                .HasMaxLength(45)
                .HasColumnName("mail");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
