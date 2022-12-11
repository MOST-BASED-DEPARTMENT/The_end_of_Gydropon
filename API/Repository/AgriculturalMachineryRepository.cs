using API.Interface;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository;

public class AgriculturalMachineryRepository : IAgriculturalMachinery
{
    private readonly AgronomicAppTestUserContext _appDBContext;
    public AgriculturalMachineryRepository(AgronomicAppTestUserContext context)
    {
        _appDBContext = context ??
                        throw new ArgumentNullException(nameof(context));
    }
    public async Task<IEnumerable<AgriculturalMachinery>> GetAgriculturalMachinery()
    {
        return await _appDBContext.AgriculturalMachineries.ToListAsync();
    }

    public async Task<AgriculturalMachinery> GetAgriculturalMachineryById(int id)
    {
        return await _appDBContext.AgriculturalMachineries.FindAsync(id);
    }

    public async Task<AgriculturalMachinery> InsertAgriculturalMachinery(AgriculturalMachinery objAM)
    {
        _appDBContext.AgriculturalMachineries.Add(objAM);
        await _appDBContext.SaveChangesAsync();
        return objAM;
    }

    public async Task<AgriculturalMachinery> UpdateAgriculturalMachinery(AgriculturalMachinery objAM)
    {
        _appDBContext.Entry(objAM).State = EntityState.Modified;
        await _appDBContext.SaveChangesAsync();
        return objAM;
    }

    public bool DeleteAgriculturalMachinery(int id)
    {
        bool result;
        var department = _appDBContext.AgriculturalMachineries.Find(id);
        if (department != null)
        {
            _appDBContext.Entry(department).State = EntityState.Deleted;
            _appDBContext.SaveChanges();
            result = true;
        }
        else
        {
            result = false;
        }
        return result;
    }
}