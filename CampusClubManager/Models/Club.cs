using System;
using System.Collections.Generic;

namespace CampusClubManager.Models;

public partial class Club
{
    public int ClubId { get; set; }

    public string? ClubName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<Membership> Memberships { get; set; } = new List<Membership>();
}
