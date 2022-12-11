using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Tasks
{
    public int IdTask { get; set; }

    public int? TasksExecutorId { get; set; }

    public int TasksFieldId { get; set; }

    public int TasksTypeId { get; set; }

    public int TasksStatusId { get; set; }

    public DateTime TasksDate { get; set; }

    public TimeSpan? TasksStartTime { get; set; }

    public TimeSpan? TasksFinishingTime { get; set; }

    public string? TasksDescription { get; set; }

    public string? TasksWeatherInfo { get; set; }

    public virtual User? TasksExecutor { get; set; }

    public virtual Field TasksField { get; set; } = null!;

    public virtual TaskStatus TasksStatus { get; set; } = null!;

    public virtual TaskType TasksType { get; set; } = null!;
}
