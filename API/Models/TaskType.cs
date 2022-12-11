using System;
using System.Collections.Generic;

namespace API.Models;

public partial class TaskType
{
    public int IdTaskType { get; set; }

    public string TaskTypeName { get; set; } = null!;

    public int SuperiorTypeId { get; set; }

    public int? ChemicalId { get; set; }

    public int? ChemicalAmount { get; set; }

    public int AgriculturalMachineryId { get; set; }

    public virtual AgriculturalMachinery AgriculturalMachinery { get; set; } = null!;

    public virtual Chemical? Chemical { get; set; }

    public virtual ICollection<TaskType> InverseSuperiorType { get; } = new List<TaskType>();

    public virtual TaskType SuperiorType { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; } = new List<Task>();
}
