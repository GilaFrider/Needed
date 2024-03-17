using System;
using System.Collections.Generic;

namespace DataBase.Models;

public partial class EmployerDTO
{
    public int Code { get; set; }

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string CompanyName { get; set; } = null!;

    public string CompanyAddress { get; set; } = null!;

    public virtual ICollection<JobDTO> Jobs { get; set; } = new List<JobDTO>();
}
