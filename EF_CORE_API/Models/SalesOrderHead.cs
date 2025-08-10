using System;
using System.Collections.Generic;

namespace EF_CORE_API.Models;

public partial class SalesOrderHead
{
    public int Id { get; set; }

    public string DocumentNo { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string TypeId { get; set; } = null!;

    public string SalesMan { get; set; } = null!;

    public string? CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string CustomerEname { get; set; } = null!;

    public DateTimeOffset Date { get; set; }

    public string? BatchId { get; set; }

    public string? PoNo { get; set; }

    public string SiteId { get; set; } = null!;

    public decimal SubTotal { get; set; }

    public decimal Discount { get; set; }

    public decimal Freight { get; set; }

    public decimal Tax { get; set; }

    public decimal Total { get; set; }

    public int PrintOpt { get; set; }

    public string? DynStatus { get; set; }

    public virtual CustomersListH? Customer { get; set; }

    public virtual ICollection<SalesOrderLinesItem> SalesOrderLinesItems { get; set; } = new List<SalesOrderLinesItem>();
}
