using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Task
{
    public int IdTask { get; set; }

    public int? TaskExecutorId { get; set; }

    public int TaskFieldId { get; set; }

    public int TaskTypeId { get; set; }

    public int TaskStatusId { get; set; }

    public DateTime TaskDate { get; set; }

    public TimeSpan? TaskStartTime { get; set; }

    public TimeSpan? TaskFinishingTime { get; set; }

    public string? TaskDescription { get; set; }

    public string? TaskWeatherInfo { get; set; }

    public virtual User? TaskExecutor { get; set; }

    public virtual Field TaskField { get; set; } = null!;

    public virtual TaskStatus TaskStatus { get; set; } = null!;

    public virtual TaskType TaskType { get; set; } = null!;
}
