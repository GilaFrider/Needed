using System;
using System.Collections.Generic;

namespace DataBase.Models;

public partial class CriterionDTO
{
    public int Code { get; set; }

    public int? SeveralYearsOfExperience { get; set; }

    public bool? Car { get; set; }

    public int? NumberOfCvsSent { get; set; }

    public int? Salary { get; set; }

    public string? Descriptions { get; set; }

    public virtual ICollection<JobDTO> Jobs { get; set; } = new List<JobDTO>();
}
