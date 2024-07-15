using System;
using System.Collections.Generic;

namespace Repositiries.Models;

public partial class Employer
{
    public int Code { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string Phone { get; set; }

    public string Firstname { get; set; }

    public string Lastname { get; set; }

    public string CompanyName { get; set; }

    public string CompanyAddress { get; set; }

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
