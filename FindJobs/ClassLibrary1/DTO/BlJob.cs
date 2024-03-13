using System;
using System.Collections.Generic;

namespace Bl.Bl_Models;

public partial class Job
{
    public int Code { get; set; }

    public int EmployersCode { get; set; }

    public int FieldOfWorkCode { get; set; }

    public int CriteriaCode { get; set; }

    public virtual BlCriterion CriteriaCodeNavigation { get; set; } = null!;

    public virtual BlEmployer EmployersCodeNavigation { get; set; } = null!;

    public virtual FieldOfWork FieldOfWorkCodeNavigation { get; set; } = null!;
}
