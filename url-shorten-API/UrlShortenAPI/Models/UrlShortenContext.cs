using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace UrlShortenAPI.Models;

public partial class UrlShortenContext : DbContext
{
    public UrlShortenContext()
    {
    }

    public UrlShortenContext(DbContextOptions<UrlShortenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Url> Urls { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=url-shorten.cfqqouewii7m.ap-southeast-2.rds.amazonaws.com;database=URL_Shorten;user id=admin;password=016485tung", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.35-mysql"));

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
