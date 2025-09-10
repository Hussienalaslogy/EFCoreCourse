using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EF_CORE_API.Models;

public partial class ItemsList
{
    [Key] 
    public string ItemNo { get; set; } = null!;

    public string VendorItemNo { get; set; } = null!;

    public string? ItemDesc { get; set; }

    public string? Unit { get; set; }

    public decimal? Price { get; set; }


    public virtual ICollection<SalesOrderLinesItem> SalesOrderLinesItems { get; set; } = new List<SalesOrderLinesItem>();
}
