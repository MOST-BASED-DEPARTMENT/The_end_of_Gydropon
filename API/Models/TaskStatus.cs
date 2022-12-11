using System;
using System.Collections.Generic;

namespace API.Models;

public partial class TaskStatus
{
    public int IdTaskStatus { get; set; }

    public string TaskStatusName { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; } = new List<Task>();
}
