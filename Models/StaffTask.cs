using System;
using System.Collections.Generic;

namespace FrontDesk.Models;

public partial class StaffTask
{
    public Guid StaffTaskId { get; set; }

    public string Name { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime DueDateTime { get; set; }

    public int RoomNumber { get; set; }

    public virtual Room RoomNumberNavigation { get; set; } = null!;
}
