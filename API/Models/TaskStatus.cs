using System;
using System.Collections.Generic;

namespace API.Models;

public partial class TaskStatus
{
    public int IdTaskStatus { get; set; }

    public string TaskStatusName { get; set; } = null!;

    public virtual ICollection<Task> TaskList { get; } = new List<Task>();
}