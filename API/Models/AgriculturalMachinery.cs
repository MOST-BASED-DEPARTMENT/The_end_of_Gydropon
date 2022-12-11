using System;
using System.Collections.Generic;

namespace API.Models;

public partial class AgriculturalMachinery
{
    public int IdAgriculturalMachinery { get; set; }

    public string AgriculturalMachineryName { get; set; } = null!;

    public int AgriculturalMachineryTypeId { get; set; }

    public virtual AgriculturalMachineryType AgriculturalMachineryType { get; set; } = null!;

    public virtual ICollection<TtaskType> TtaskTypes { get; } = new List<TtaskType>();
}
