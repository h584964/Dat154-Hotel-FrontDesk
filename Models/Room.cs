using System;
using System.Collections.Generic;

namespace FrontDesk.Models;

public partial class Room
{
    public int RoomNumber { get; set; }

    public int Beds { get; set; }

    public int Capacity { get; set; }

    public bool HasView { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<StaffTask> StaffTasks { get; set; } = new List<StaffTask>();
}
