using System;
using System.Collections.Generic;

namespace CampusClubManager.Models;

public partial class Event
{
    public int EventId { get; set; }

    public int ClubId { get; set; }

    public string? EventName { get; set; }

    public DateTime? EventDate { get; set; }

    public string? Location { get; set; }

    public virtual Club Club { get; set; } = null!;
}
