using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Chemical
{
    public int IdChemical { get; set; }

    public string ChemicalName { get; set; } = null!;

    public int ChemicalsTypeId { get; set; }

    public virtual ChemicalsType ChemicalsType { get; set; } = null!;

    public virtual ICollection<TtaskType> TtaskTypes { get; } = new List<TtaskType>();
}
