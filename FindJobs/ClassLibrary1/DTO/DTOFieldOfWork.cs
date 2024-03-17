using System;
using System.Collections.Generic;

namespace Bl.Bl_Models;

public partial class DTOFieldOfWork
{
    public int Code { get; set; }

    public string FieldOfWorkName { get; set; } = null!;

    public virtual ICollection<DTOJob> Jobs { get; set; } = new List<DTOJob>();
}
