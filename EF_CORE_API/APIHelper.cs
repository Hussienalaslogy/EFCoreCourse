using EF_CORE_API.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_CORE_API.Models
{
    partial class SmarterASPContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            //Forign Key Between Head And LinesItems
            modelBuilder.Entity<SalesOrderLinesItem>()
                        .HasOne(line => line.SoHead)
                        .WithMany(head => head.SalesOrderLinesItems)
                        .HasForeignKey(line => line.SoHeadId)
                        .HasPrincipalKey(head => head.Id)
                        .IsRequired(false)
                        .OnDelete(DeleteBehavior.Cascade);


            //Forign Key Between Customer And SalesOrders
            modelBuilder.Entity<SalesOrderHead>()
                .HasOne(order => order.Customer)
                .WithMany(customer => customer.SalesOrderHeads)
                .HasForeignKey(order => order.CustomerId)
                .HasPrincipalKey(customer => customer.CustomerNo)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            //Forign Key Between Item And LinesItems
            modelBuilder.Entity<SalesOrderLinesItem>()
                .HasOne(line => line.ItemNumberNavigation)
                .WithMany(item => item.SalesOrderLinesItems)
                .HasForeignKey(line => line.ItemNumber)
                .HasPrincipalKey(item => item.ItemNo)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            //forign Key Between Customer And Adress
            modelBuilder.Entity<CustomersListH>()
                .HasOne(customer => customer.Adress)
                .WithOne(adress => adress.Customer)
                .HasForeignKey<CustomersAdresses>(adress => adress.CustomerNo) 
                .HasPrincipalKey<CustomersListH>(customer => customer.CustomerNo)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            //PK For Customer List
            modelBuilder.Entity<CustomersListH>(entity =>
            {
                entity.HasKey(e => e.CustomerNo);
            });
        }
    }

    public static class Credintials
    {
        public static string? connectionString = Environment.GetEnvironmentVariable("DynamicsDb");
    }

    public class DTOs
    {
        public class LinesItems
        {
            public string VendorNo { get; set; }
            public string ItemDescription { get; set; }
            public decimal Quantity { get; set; }
            public decimal UnitPrice { get; set; }
            public int SoHeadId { get; set; }
            public SalesOrderHead SalesOrdersHead { get; set; }
        }
    }

    

   
    

   

}
