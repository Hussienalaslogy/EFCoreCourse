using System;
using System.Collections.Generic;

namespace EF_CORE_API.Models2;

public partial class DeliveryRequest
{
    public int Id { get; set; }

    public int? LineItemRindex { get; set; }

    public DateTimeOffset DocumentDate { get; set; }

    public string SiteId { get; set; } = null!;

    public string DocumentNo { get; set; } = null!;

    public string OriginalDocumentNo { get; set; } = null!;

    public string DocumentStatus { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public string? ModifiedBy { get; set; }

    public DateTimeOffset? DateModified { get; set; }

    public string Area { get; set; } = null!;

    public string VendorNo { get; set; } = null!;

    public string ItemDescription { get; set; } = null!;

    public string ItemNumber { get; set; } = null!;

    public double OrderedQty { get; set; }

    public double RequestedQty { get; set; }

    public virtual SalesOrdersHead OriginalDocumentNoNavigation { get; set; } = null!;
}
