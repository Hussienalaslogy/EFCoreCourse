using System;
using System.Collections.Generic;

namespace EF_CORE_API.Models;

public partial class User
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string HashPassword { get; set; } = null!;

    public string Role { get; set; } = null!;
}
