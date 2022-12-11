using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Field
{
    public int IdField { get; set; }

    public int FieldArea { get; set; }

    public string FieldIdentifier { get; set; } = null!;

    public int FieldPlantId { get; set; }

    public virtual Plant FieldPlant { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; } = new List<Task>();
}
