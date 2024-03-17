using Bl.DTO;
using System;
using System.Collections.Generic;

namespace Bl.Bl_Models;

public partial class DTOJob
{
    public int Code { get; set; }

    public int EmployersCode { get; set; }

    public int FieldOfWorkCode { get; set; }

    public int CriteriaCode { get; set; }

    public virtual DTOCriterion CriteriaCodeNavigation { get; set; } = null!;

    public virtual DTOEmployer EmployersCodeNavigation { get; set; } = null!;

    public virtual DTOFieldOfWork FieldOfWorkCodeNavigation { get; set; } = null!;
}
