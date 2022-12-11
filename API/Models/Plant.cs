using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Plant
{
    public int IdPlant { get; set; }

    public string PlantName { get; set; } = null!;

    public int PlantTypeId { get; set; }

    public virtual ICollection<Field> Fields { get; } = new List<Field>();

    public virtual PlantsType PlantType { get; set; } = null!;
}
