using api_zoologico.Interfaces.Service;
using api_zoologico.Query;
using Microsoft.AspNetCore.Mvc;

namespace api_zoologico.Controllers;

public class ZoologicosController : Controller
{
    private readonly IZoologicosService _zoologicosService;

    public ZoologicosController(IZoologicosService zoologicosService)
    {
        _zoologicosService = zoologicosService;
    }

    [HttpGet("zoologicos/GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _zoologicosService.GetAll();
        return Ok(response);
    }

    [HttpGet("zoologicos/GetById/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var response = await _zoologicosService.GetById(id);
        return Ok(response);
    }

    [HttpPost("zoologicos/PostZoo")]
    public async Task<IActionResult> PostZoologico([FromBody] NewZoologicoQuery query)
    {
        var response = await _zoologicosService.PostZoo(query);
        return Ok(response);
    }
}