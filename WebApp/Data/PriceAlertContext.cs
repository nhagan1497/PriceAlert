using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data;

public partial class PriceAlertContext : DbContext
{
    public PriceAlertContext()
    {
    }

    public PriceAlertContext(DbContextOptions<PriceAlertContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BitcoinPrice> BitcoinPrices { get; set; }

    public virtual DbSet<BitcoinPriceAlert> BitcoinPriceAlerts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost:5432;Username=price;Password=price;Database=PriceAlert");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BitcoinPrice>(entity =>
        {
            entity.HasKey(e => e.Date).HasName("bitcoin_prices_pkey");

            entity.ToTable("bitcoin_prices");

            entity.Property(e => e.Date)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
        });

        modelBuilder.Entity<BitcoinPriceAlert>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("bitcoin_price_alerts_pkey");

            entity.ToTable("bitcoin_price_alerts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.HighPrice)
                .HasPrecision(10, 2)
                .HasColumnName("high_price");
            entity.Property(e => e.LowPrice)
                .HasPrecision(10, 2)
                .HasColumnName("low_price");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
