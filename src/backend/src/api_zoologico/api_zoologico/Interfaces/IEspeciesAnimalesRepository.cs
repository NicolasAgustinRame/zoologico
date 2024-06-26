using api_zoologico.Models;

namespace api_zoologico.Interfaces;

public interface IEspeciesAnimalesRepository
{
    Task<List<EspeciesAnimales>> GetAll();
    Task<EspeciesAnimales> GetById(Guid id);
}