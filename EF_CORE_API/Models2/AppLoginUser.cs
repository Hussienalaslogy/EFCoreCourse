using System;
using System.Collections.Generic;

namespace EF_CORE_API.Models2;

public partial class AppLoginUser
{
    public string Username { get; set; } = null!;

    public byte[] PasswordHash { get; set; } = null!;
}
