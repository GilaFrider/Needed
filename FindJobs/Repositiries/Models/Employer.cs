using System;
using System.Collections.Generic;

namespace Repositiries.Models;

public partial class Employer
{
    public int Code { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string CompanyName { get; set; } = null!;

    public string CompanyAddress { get; set; } = null!;

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
