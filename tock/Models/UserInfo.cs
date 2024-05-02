using System;
using System.Collections.Generic;

namespace tock.Models;

public partial class UserInfo
{
    public int? UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? UserName { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }
}
