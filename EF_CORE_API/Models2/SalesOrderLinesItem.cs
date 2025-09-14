using System;
using System.Collections.Generic;

namespace EF_CORE_API.Models2;

public partial class SalesOrderLinesItem
{
    public int Id { get; set; }

    public string DocumentNo { get; set; } = null!;

    public string Area { get; set; } = null!;

    public string VendorNo { get; set; } = null!;

    public string ItemDescription { get; set; } = null!;

    public string ItemNumber { get; set; } = null!;

    public decimal Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal ExtendedPrice { get; set; }

    public virtual SalesOrdersHead DocumentNoNavigation { get; set; } = null!;
}
