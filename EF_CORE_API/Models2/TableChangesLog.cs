using System;
using System.Collections.Generic;

namespace EF_CORE_API.Models2;

public partial class TableChangesLog
{
    public string TableName { get; set; } = null!;

    public DateTime? LastModified { get; set; }

    public string? LastOperation { get; set; }
}
