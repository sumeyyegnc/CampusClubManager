using System;
using System.Collections.Generic;

namespace CampusClubManager.Models;

public partial class Membership
{
    public int MembershipId { get; set; }

    public int StudentId { get; set; }

    public int ClubId { get; set; }

    public DateTime? JoinDate { get; set; }

    public virtual Club Club { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
