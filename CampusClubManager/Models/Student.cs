using System;
using System.Collections.Generic;

namespace CampusClubManager.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Department { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Membership> Memberships { get; set; } = new List<Membership>();
}
