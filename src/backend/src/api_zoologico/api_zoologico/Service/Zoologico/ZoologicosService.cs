using System.Net;
using api_zoologico.Dtos;
using api_zoologico.Interfaces;
using api_zoologico.Interfaces.Service;
using api_zoologico.Response;
using AutoMapper;

namespace api_zoologico.Service.Zoologico;

public class ZoologicosService : IZoologicosService
{
    private readonly IZoologicosRepository _zoologicosRepository;
    private readonly IMapper _mapper;

    public ZoologicosService(IZoologicosRepository zoologicosRepository, IMapper mapper)
    {
        _zoologicosRepository = zoologicosRepository;
        _mapper = mapper;
    }
    
    public async Task<ApiResponse<List<ZooDto>>> GetAll()
    {
        var response = new ApiResponse<List<ZooDto>>();
        var zoologicos = await _zoologicosRepository.GetAll();
        if (zoologicos != null && zoologicos.Count > 0)
        {
            response.Data = _mapper.Map<List<ZooDto>>(zoologicos);
        }
        else
        {
            response.SetError("No hay zoologicos en la base de datos", HttpStatusCode.NotFound);
        }

        return response;
    }

    public async Task<ApiResponse<ZooDto>> GetById(Guid id)
    {
        var response = new ApiResponse<ZooDto>();
        var zoo = await _zoologicosRepository.GetById(id);
        if (zoo != null)
        {
            response.Data = _mapper.Map<ZooDto>(zoo);
        }
        else
        {
            response.SetError("Zoologico no registrado", HttpStatusCode.BadRequest);
        }

        return response;
    }
}