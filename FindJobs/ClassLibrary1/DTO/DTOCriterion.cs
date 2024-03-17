using System;
using System.Collections.Generic;

namespace Bl.DTO;

public partial class DTOCriterion
{
    public int Code { get; set; }

    public int? SeveralYearsOfExperience { get; set; }

    public bool? Car { get; set; }

    public int? NumberOfCvsSent { get; set; }

    public int? Salary { get; set; }

    public string? Descriptions { get; set; }

    public virtual ICollection<DTOjob> Jobs { get; set; } = new List<DTOJob>();
}
