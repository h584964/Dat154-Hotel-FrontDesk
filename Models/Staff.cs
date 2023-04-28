using System;
using System.Collections.Generic;

namespace FrontDesk.Models;

public partial class Staff
{
    public Guid StaffId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Role { get; set; } = null!;
}
