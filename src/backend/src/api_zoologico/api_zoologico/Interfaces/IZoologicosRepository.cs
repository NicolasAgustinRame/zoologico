using api_zoologico.Models;

namespace api_zoologico.Interfaces;

public interface IZoologicosRepository
{
    Task<List<Zoologicos>> GetAll();
    Task<Zoologicos> GetById(Guid id);
    Task<Zoologicos> PostZoologico(Zoologicos zoo);
    Task<Zoologicos> UpdateZoologico(Zoologicos zoo);
    Task<Zoologicos> DeletaZoologico(Guid id);

}