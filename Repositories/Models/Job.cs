using System;
using System.Collections.Generic;

namespace Repositories.Models;

public partial class Job
{
    public int Code { get; set; }

    public int? SeveralYearsOfExperience { get; set; }

    public int? Salary { get; set; }

    public string Description { get; set; }

    public int EmployerCode { get; set; }

    public int FieldOfWorkCode { get; set; }

    public virtual Employer EmployerCodeNavigation { get; set; }

    public virtual FieldsOfWork FieldOfWorkCodeNavigation { get; set; }
}
