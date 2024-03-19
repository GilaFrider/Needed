using System;
using System.Collections.Generic;

namespace Bl.DTO;

public partial class FieldOfWorkDTO
{
    public int Code { get; set; }

    public string FieldOfWorkName { get; set; } = null!;

    public virtual ICollection<JobDTO> Jobs { get; set; } = new List<JobDTO>();
}
