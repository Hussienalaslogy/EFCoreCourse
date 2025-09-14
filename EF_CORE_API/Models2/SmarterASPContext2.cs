using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EF_CORE_API.Models2;

public partial class SmarterASPContext2 : DbContext
{
    public SmarterASPContext2()
    {
    }

    public SmarterASPContext2(DbContextOptions<SmarterASPContext2> options)
        : base(options)
    {
    }

    public virtual DbSet<ApiActivityLog> ApiActivityLogs { get; set; }

    public virtual DbSet<AppLoginUser> AppLoginUsers { get; set; }

    public virtual DbSet<CustomersListH> CustomersListHs { get; set; }

    public virtual DbSet<DeliveryRequest> DeliveryRequests { get; set; }

    public virtual DbSet<SalesOrderLinesItem> SalesOrderLinesItems { get; set; }

    public virtual DbSet<SalesOrdersHead> SalesOrdersHeads { get; set; }

    public virtual DbSet<TableChangesLog> TableChangesLogs { get; set; }

    public virtual DbSet<TermsCondition> TermsConditions { get; set; }

    public virtual DbSet<User> Users { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApiActivityLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ApiActiv__3214EC0775F07CF9");

            entity.Property(e => e.AccessedAt).HasColumnType("datetime");
            entity.Property(e => e.Endpoint).HasMaxLength(100);
            entity.Property(e => e.Param).HasMaxLength(200);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TableName).HasMaxLength(100);
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        modelBuilder.Entity<AppLoginUser>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK__AppLogin__536C85E5A0D803BA");

            entity.Property(e => e.Username).HasMaxLength(50);
            entity.Property(e => e.PasswordHash).HasMaxLength(64);
        });

        modelBuilder.Entity<CustomersListH>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC077B2788AE");

            entity.ToTable("CustomersListH", tb => tb.HasTrigger("trg_CustomersListH_Update"));

            entity.Property(e => e.BuildingNo).HasMaxLength(50);
            entity.Property(e => e.City).HasMaxLength(255);
            entity.Property(e => e.CrNo).HasMaxLength(50);
            entity.Property(e => e.CustomerEname).HasMaxLength(255);
            entity.Property(e => e.CustomerName).HasMaxLength(255);
            entity.Property(e => e.CustomerNo).HasMaxLength(50);
            entity.Property(e => e.District).HasMaxLength(255);
            entity.Property(e => e.MobileNo).HasMaxLength(50);
            entity.Property(e => e.SalesMan).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Street).HasMaxLength(255);
            entity.Property(e => e.VatId).HasMaxLength(50);
            entity.Property(e => e.ZipCode).HasMaxLength(255);
        });

        modelBuilder.Entity<DeliveryRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Delivery__3214EC27A5B0E9C7");

            entity.ToTable("DeliveryRequest");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Area).HasMaxLength(100);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.DocumentNo).HasMaxLength(50);
            entity.Property(e => e.DocumentStatus).HasMaxLength(50);
            entity.Property(e => e.ItemDescription).HasMaxLength(255);
            entity.Property(e => e.ItemNumber).HasMaxLength(50);
            entity.Property(e => e.LineItemRindex).HasColumnName("LineItemRIndex");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.OriginalDocumentNo).HasMaxLength(50);
            entity.Property(e => e.SiteId)
                .HasMaxLength(50)
                .HasColumnName("SiteID");
            entity.Property(e => e.VendorNo).HasMaxLength(50);

            entity.HasOne(d => d.OriginalDocumentNoNavigation).WithMany(p => p.DeliveryRequests)
                .HasForeignKey(d => d.OriginalDocumentNo)
                .HasConstraintName("FK_DeliveryRequest_SalesOrdersHead");
        });

        modelBuilder.Entity<SalesOrderLinesItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SalesOrd__3214EC27169770F7");

            entity.ToTable("SalesOrderLinesItem");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Area).HasMaxLength(100);
            entity.Property(e => e.DocumentNo).HasMaxLength(50);
            entity.Property(e => e.ExtendedPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Extended_Price");
            entity.Property(e => e.ItemDescription)
                .HasMaxLength(300)
                .HasColumnName("Item_Description");
            entity.Property(e => e.ItemNumber)
                .HasMaxLength(100)
                .HasColumnName("Item_Number");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Unit_Price");
            entity.Property(e => e.VendorNo)
                .HasMaxLength(100)
                .HasColumnName("Vendor_no");

            entity.HasOne(d => d.DocumentNoNavigation).WithMany(p => p.SalesOrderLinesItems)
                .HasForeignKey(d => d.DocumentNo)
                .HasConstraintName("FK_SalesOrderLinesItem_SalesOrdersHead");
        });

        modelBuilder.Entity<SalesOrdersHead>(entity =>
        {
            entity.HasKey(e => e.DocumentNo).HasName("PK__SalesOrd__1ABE364F6518DD9E");

            entity.ToTable("SalesOrdersHead");

            entity.Property(e => e.DocumentNo).HasMaxLength(50);
            entity.Property(e => e.BatchId)
                .HasMaxLength(50)
                .HasColumnName("BatchID");
            entity.Property(e => e.CustomerEname)
                .HasMaxLength(200)
                .HasColumnName("CustomerEName");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(50)
                .HasColumnName("CustomerID");
            entity.Property(e => e.CustomerName).HasMaxLength(200);
            entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DynStatus).HasMaxLength(50);
            entity.Property(e => e.Freight).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PoNo).HasMaxLength(50);
            entity.Property(e => e.SalesMan).HasMaxLength(100);
            entity.Property(e => e.SiteId)
                .HasMaxLength(50)
                .HasColumnName("SiteID");
            entity.Property(e => e.SubTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Tax).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Type).HasMaxLength(20);
            entity.Property(e => e.TypeId)
                .HasMaxLength(10)
                .HasColumnName("TypeID");
        });

        modelBuilder.Entity<TableChangesLog>(entity =>
        {
            entity.HasKey(e => e.TableName).HasName("PK__TableCha__733652EF10346EF4");

            entity.ToTable("TableChangesLog");

            entity.Property(e => e.TableName).HasMaxLength(100);
            entity.Property(e => e.LastModified).HasColumnType("datetime");
            entity.Property(e => e.LastOperation).HasMaxLength(10);
        });

        modelBuilder.Entity<TermsCondition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TermsCon__3214EC07DEA73269");

            entity.HasIndex(e => new { e.FieldName, e.Content }, "UQ__TermsCon__A45F5166B00027FD").IsUnique();

            entity.Property(e => e.Content).HasMaxLength(200);
            entity.Property(e => e.FieldName).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07EB2BDCBF");

            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
