using System;
using System.Collections.Generic;

namespace API.Models;

public partial class TtaskStatus
{
    public int IdTtaskStatus { get; set; }

    public string TtaskStatusName { get; set; } = null!;

    public virtual ICollection<Ttask> Ttasks { get; } = new List<Ttask>();
}
