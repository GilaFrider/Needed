using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Repositories.Models;

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

    [JsonIgnore]
    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
