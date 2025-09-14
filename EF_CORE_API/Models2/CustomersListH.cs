using System;
using System.Collections.Generic;

namespace EF_CORE_API.Models2;

public partial class CustomersListH
{
    public int Id { get; set; }

    public string CustomerNo { get; set; } = null!;

    public string CustomerName { get; set; } = null!;

    public string CustomerEname { get; set; } = null!;

    public string SalesMan { get; set; } = null!;

    public string MobileNo { get; set; } = null!;

    public string? BuildingNo { get; set; }

    public string? Street { get; set; }

    public string? District { get; set; }

    public string? City { get; set; }

    public string? ZipCode { get; set; }

    public string? VatId { get; set; }

    public string? CrNo { get; set; }

    public string? Status { get; set; }
}
