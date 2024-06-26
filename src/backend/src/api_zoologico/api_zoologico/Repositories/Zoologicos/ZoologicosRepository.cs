using api_zoologico.Data;
using api_zoologico.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api_zoologico.Repositories.Zoologicos;

public class ZoologicosRepository : IZoologicosRepository
{
    private readonly ContextDb _contextDb;

    public ZoologicosRepository(ContextDb contextDb)
    {
        _contextDb = contextDb;
    }
    
    public async Task<List<Models.Zoologicos>> GetAll()
    {
        var zoos = await _contextDb.Zoologicos
            .Include(z => z.Especie)
            .ToListAsync();
        return zoos;
    }

    public async Task<Models.Zoologicos> GetById(Guid id)
    {
        var zoo = await _contextDb.Zoologicos
            .Include(z => z.Especie)
            .FirstOrDefaultAsync(z => z.Id == id);
        return zoo;
    }

    public async Task<Models.Zoologicos> PostZoologico(Models.Zoologicos zoo)
    {
        await _contextDb.AddAsync(zoo);
        await _contextDb.SaveChangesAsync();
        return zoo;
    }

    public async Task<Models.Zoologicos> UpdateZoologico(Models.Zoologicos zoo)
    {
        var zoologico = await _contextDb.Zoologicos
            .Include(z => z.Especie)
            .FirstOrDefaultAsync(z => z.Id == zoo.Id);
        
        zoo.Nombre = zoologico.Nombre;
        zoo.Ciudad = zoologico.Ciudad;
        zoo.Tamanio = zoologico.Tamanio;
        zoo.PresupuestoAnual = zoologico.PresupuestoAnual;
        zoo.AnioNacimiento = zoologico.AnioNacimiento;
        zoo.PaisDeOrigen = zoologico.PaisDeOrigen;
        zoo.Continente = zoologico.Continente;

        _contextDb.Update(zoologico);
        _contextDb.SaveChanges();
        
        return zoologico;
    }

    public async Task<Models.Zoologicos> DeletaZoologico(Guid id)
    {
        var zoologico = await _contextDb.Zoologicos
            .Include(z => z.Especie)
            .FirstOrDefaultAsync(z => z.Id == id);

        _contextDb.Remove(zoologico);
        _contextDb.SaveChanges();
        return zoologico;
    }
}