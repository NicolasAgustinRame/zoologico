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

    [HttpPut("zoologicos/UpdateZoo")]
    public async Task<IActionResult> UpdateZoologico([FromBody] UpdateZoologicoQuery query)
    {
        var response = await _zoologicosService.UpdateZoo(query);
        return Ok(response);
    }

    [HttpDelete("zoologicos/DeleteZoo")]
    public async Task<IActionResult> DeleteZoo(Guid id)
    {
        var response = await _zoologicosService.DeleteZoo(id);
        return Ok(response);
    }
}