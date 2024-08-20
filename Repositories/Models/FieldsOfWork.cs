using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Repositories.Models;

public partial class FieldsOfWork
{
    public int Code { get; set; }

    public string FieldOfWorkName { get; set; }

    [JsonIgnore]
    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
