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

    //-------------------------------------------------------------------------
    public virtual DbSet<CustomersListH> CustomersListH { get; set; }

    public virtual DbSet<CustomersAdresses> CustomersAdresses { get; set; }

    public virtual DbSet<ItemsList> ItemsList { get; set; }

    public virtual DbSet<SalesOrderHead> SalesOrderHead { get; set; }

    public virtual DbSet<SalesOrderLinesItem> SalesOrderLinesItem { get; set; }

    public virtual DbSet<User> Users { get; set; }
    

    //------------------------------------------------------------------------
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    
}
