using System;
using System.Collections.Generic;

namespace EF_CORE_API.Models2;

public partial class TermsCondition
{
    public int Id { get; set; }

    public string? FieldName { get; set; }

    public string? Content { get; set; }
}
