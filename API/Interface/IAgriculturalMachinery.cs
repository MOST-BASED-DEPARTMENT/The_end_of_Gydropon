using API.Models;

namespace API.Interface;

public interface IAgriculturalMachinery
{
    Task<IEnumerable<AgriculturalMachinery>> GetAgriculturalMachinery();
    Task<AgriculturalMachinery> GetAgriculturalMachineryById(int id);
    Task<AgriculturalMachinery> InsertAgriculturalMachinery(AgriculturalMachinery objAM);
    Task<AgriculturalMachinery> UpdateAgriculturalMachinery(AgriculturalMachinery objAM);
    bool DeleteAgriculturalMachinery(int id);
}