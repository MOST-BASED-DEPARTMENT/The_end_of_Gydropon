namespace API.Models;

public partial class ChemicalsType
{
    public int IdChemicalType { get; set; }

    public string ChemicalTypeName { get; set; } = null!;

    public virtual ICollection<Chemical> Chemicals { get; } = new List<Chemical>();
}
