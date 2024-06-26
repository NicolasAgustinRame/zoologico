﻿using api_zoologico.Dtos;
using api_zoologico.Query;
using api_zoologico.Response;

namespace api_zoologico.Interfaces.Service;

public interface IZoologicosService
{
    Task<ApiResponse<List<ZooDto>>> GetAll();
    Task<ApiResponse<ZooDto>> GetById(Guid id);
    Task<ApiResponse<ZooDto>> PostZoo(NewZoologicoQuery query);
    Task<ApiResponse<ZooDto>> UpdateZoo(UpdateZoologicoQuery query);
    Task<ApiResponse<ZooDto>> DeleteZoo(Guid id);
}