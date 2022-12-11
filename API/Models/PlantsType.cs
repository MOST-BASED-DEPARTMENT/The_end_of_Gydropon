using System;
using System.Collections.Generic;

namespace API.Models;

public partial class PlantsType
{
    public int IdPlantType { get; set; }

    public string PlantTypeName { get; set; } = null!;

    public virtual ICollection<Plant> Plants { get; } = new List<Plant>();
}
