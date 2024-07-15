using System;
using System.Collections.Generic;

namespace Repositiries.Models;

public partial class Job
{
    public int Code { get; set; }

    public int EmployersCode { get; set; }

    public int FieldOfWorkCode { get; set; }

    public int CriteriaCode { get; set; }

    public virtual Criterion CriteriaCodeNavigation { get; set; }

    public virtual Employer EmployersCodeNavigation { get; set; }

    public virtual FieldOfWork FieldOfWorkCodeNavigation { get; set; }
}
