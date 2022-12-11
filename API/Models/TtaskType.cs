using System;
using System.Collections.Generic;

namespace API.Models;

public partial class TtaskType
{
    public int IdTtaskType { get; set; }

    public string TtaskTypeName { get; set; } = null!;

    public int SuperiorTypeId { get; set; }

    public int? ChemicalId { get; set; }

    public int? ChemicalAmount { get; set; }

    public int AgriculturalMachineryId { get; set; }

    public virtual AgriculturalMachinery AgriculturalMachinery { get; set; } = null!;

    public virtual Chemical? Chemical { get; set; }

    public virtual ICollection<TtaskType> InverseSuperiorType { get; } = new List<TtaskType>();

    public virtual TtaskType SuperiorType { get; set; } = null!;

    public virtual ICollection<Ttask> Ttasks { get; } = new List<Ttask>();
}
