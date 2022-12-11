using System;
using System.Collections.Generic;

namespace API.Models;

public partial class AgriculturalMachineryType
{
    public int IdAgriculturalMachineryType { get; set; }

    public string AgriculturalMachineryTypeName { get; set; } = null!;

    public virtual ICollection<AgriculturalMachinery> AgriculturalMachineries { get; } = new List<AgriculturalMachinery>();
}
