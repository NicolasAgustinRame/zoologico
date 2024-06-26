using System.Net;
using api_zoologico.Dtos;
using api_zoologico.Interfaces;
using api_zoologico.Interfaces.Service;
using api_zoologico.Models;
using api_zoologico.Query;
using api_zoologico.Response;
using AutoMapper;

namespace api_zoologico.Service.Zoologico;

public class ZoologicosService : IZoologicosService
{
    private readonly IZoologicosRepository _zoologicosRepository;
    private readonly IEspeciesAnimalesRepository _especiesAnimalesRepository;
    private readonly IMapper _mapper;

    public ZoologicosService(IZoologicosRepository zoologicosRepository, IMapper mapper, IEspeciesAnimalesRepository especiesAnimalesRepository)
    {
        _zoologicosRepository = zoologicosRepository;
        _especiesAnimalesRepository = especiesAnimalesRepository;
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

    public async Task<ApiResponse<ZooDto>> PostZoo(NewZoologicoQuery query)
    {
        var response = new ApiResponse<ZooDto>();
        var zoologico = await _zoologicosRepository.GetById(query.Id);
        if (zoologico != null)
        {
            response.SetError("El zoologico ya existe", HttpStatusCode.BadRequest);
            return response;
        }

        var especie = await _especiesAnimalesRepository.GetById(query.IdEspecie);
        if (especie == null)
        {
            response.SetError("La especie no existe", HttpStatusCode.BadRequest);
            return response;
        }

        var newZoologico = new Zoologicos()
        {
            Id = query.Id,
            Nombre = query.Nombre,
            Ciudad = query.Ciudad,
            Pais = query.Pais,
            Tamanio = query.Tamanio,
            PresupuestoAnual = query.PresupuestoAnual,
            IdAnimal = query.IdAnimal,
            Especie = especie,
            Sexo = query.Sexo,
            AnioNacimiento = query.AnioNacimiento,
            PaisDeOrigen = query.PaisDeOrigen,
            Continente = query.Continente
        };

        newZoologico = await _zoologicosRepository.PostZoologico(newZoologico);
        response.Data = _mapper.Map<ZooDto>(newZoologico);
        return response;
    }

    public async Task<ApiResponse<ZooDto>> UpdateZoo(UpdateZoologicoQuery query)
    {
        var response = new ApiResponse<ZooDto>();
        var zoologico = await _zoologicosRepository.GetById(query.Id);
        if (zoologico == null)
        {
            response.SetError("El zoologico no existe", HttpStatusCode.BadRequest);
            return response;
        }

        var updateZoologico = new Zoologicos()
        {
            Id = query.Id,
            Nombre = query.Nombre,
            Ciudad = query.Ciudad,
            Tamanio = query.Tamanio,
            PresupuestoAnual = query.PresupuestoAnual,
            AnioNacimiento = query.AnioNacimiento,
            PaisDeOrigen = query.PaisDeOrigen,
            Continente = query.Continente
        };

        await _zoologicosRepository.UpdateZoologico(updateZoologico);
        response.Data = _mapper.Map<ZooDto>(updateZoologico);
        return response;
    }

    public async Task<ApiResponse<ZooDto>> DeleteZoo(Guid id)
    {
        var response = new ApiResponse<ZooDto>();
        var zoologico = await _zoologicosRepository.GetById(id);
        if (zoologico == null)
        {
            response.SetError("El zoologico no existe", HttpStatusCode.BadRequest);
            return response;
        }

        zoologico = await _zoologicosRepository.DeletaZoologico(id);
        response.Data = _mapper.Map<ZooDto>(zoologico);
        return response;

    }
}