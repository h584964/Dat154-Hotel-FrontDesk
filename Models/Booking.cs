using System;
using System.Collections.Generic;

namespace FrontDesk.Models;

public partial class Booking
{
    public Guid BookingId { get; set; }

    public Guid CustomerId { get; set; }

    public int RoomNumber { get; set; }

    public DateTime CheckInDate { get; set; }

    public DateTime CheckOutDate { get; set; }

    public int NumberOfGuests { get; set; }

    public decimal TotalPrice { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Room RoomNumberNavigation { get; set; } = null!;
}
