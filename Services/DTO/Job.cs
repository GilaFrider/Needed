using System;
using System.Collections.Generic;

namespace Services.DTO;

public partial class JobDTO
{
    public int Code { get; set; }

    public int? SeveralYearsOfExperience { get; set; }

    public int? Salary { get; set; }

    public string? Description { get; set; }

    public int EmployerCode { get; set; }

    public int FieldOfWorkCode { get; set; }

    public virtual EmployerDTO EmployerCodeNavigation { get; set; }

    public virtual FieldsOfWorkDTO FieldOfWorkCodeNavigation { get; set; }
}
