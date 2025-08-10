using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EF_CORE_API.Models;

public partial class SmarterASPContext : DbContext
{
    public SmarterASPContext()
    {
    }

    public SmarterASPContext(DbContextOptions<SmarterASPContext> options)
        : base(options)
    {
    }

    //=============================================================================
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    //=============================================================================
    public virtual DbSet<CustomersListH> CustomersListHs { get; set; }

    public virtual DbSet<ItemsList> ItemsLists { get; set; }

    public virtual DbSet<SalesOrderHead> SalesOrderHeads { get; set; }

    public virtual DbSet<SalesOrderLinesItem> SalesOrderLinesItems { get; set; }

    public virtual DbSet<User> Users { get; set; }

    //==============================================================================
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomersListH>(entity =>
        {
            entity.HasKey(e => e.CustomerNo);

            entity.ToTable("CustomersListH");
        });

        modelBuilder.Entity<ItemsList>(entity =>
        {
            entity.HasKey(e => e.ItemNo);

            entity.ToTable("ItemsList");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<SalesOrderHead>(entity =>
        {
            entity.ToTable("SalesOrderHead");

            entity.HasIndex(e => e.CustomerId, "IX_SalesOrderHead_CustomerId");

            entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Freight).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Tax).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.SalesOrderHeads).HasForeignKey(d => d.CustomerId);
        });

        modelBuilder.Entity<SalesOrderLinesItem>(entity =>
        {
            entity.ToTable("SalesOrderLinesItem");

            entity.HasIndex(e => e.ItemNumber, "IX_SalesOrderLinesItem_ItemNumber");

            entity.HasIndex(e => e.SoHeadId, "IX_SalesOrderLinesItem_SoHeadId");

            entity.Property(e => e.ExtendedPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.ItemNumberNavigation).WithMany(p => p.SalesOrderLinesItems).HasForeignKey(d => d.ItemNumber);

            entity.HasOne(d => d.SoHead).WithMany(p => p.SalesOrderLinesItems).HasForeignKey(d => d.SoHeadId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    
}
