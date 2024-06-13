using System;
using System.Collections.Generic;

namespace Repositiries.Models;

public partial class Criterion
{
    public int Code { get; set; }

    public int? SeveralYearsOfExperience { get; set; }

    public bool? Car { get; set; }

    public int? NumberOfCvsSent { get; set; }

    public int? Salary { get; set; }

    public string? Descriptions { get; set; }

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
