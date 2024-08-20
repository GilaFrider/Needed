using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Services.DTO;

public partial class FieldsOfWorkDTO
{
    public int Code { get; set; }

    public string FieldOfWorkName { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<JobDTO> Jobs { get; set; } = new List<JobDTO>();
}
