using api_zoologico.Data;
using api_zoologico.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api_zoologico.Repositories.EspeciesAnimales;

public class EspeciesAnimalesRepository : IEspeciesAnimalesRepository
{
    private readonly ContextDb _contextDb;

    public EspeciesAnimalesRepository(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }
    
    public async Task<List<Models.EspeciesAnimales>> GetAll()
    {
        var especiesAnimales = await _contextDb.EspeciesAnimales.ToListAsync();
        return especiesAnimales;
    }

    public async Task<Models.EspeciesAnimales> GetById(Guid id)
    {
        var especies = await _contextDb.EspeciesAnimales.FirstOrDefaultAsync(e => e.Id == id);
        return especies;
    }
}