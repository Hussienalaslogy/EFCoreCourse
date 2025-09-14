using System;
using System.Collections.Generic;

namespace EF_CORE_API.Models2;

public partial class ApiActivityLog
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Endpoint { get; set; }

    public string? TableName { get; set; }

    public string? Param { get; set; }

    public DateTime? AccessedAt { get; set; }

    public string? Status { get; set; }

    public string? ErrorMessage { get; set; }
}
