using System;
using System.Collections.Generic;

namespace Services.DTO;

public partial class JobDTO
{
    public int Code { get; set; }

    public int EmployersCode { get; set; }

    public int FieldOfWorkCode { get; set; }

    public int CriteriaCode { get; set; }

    public virtual CriterionDTO CriteriaCodeNavigation { get; set; }

    public virtual EmployerDTO EmployersCodeNavigation { get; set; }

    public virtual FieldOfWorkDTO FieldOfWorkCodeNavigation { get; set; }
}
