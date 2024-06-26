using api_zoologico.Interfaces;
using api_zoologico.Interfaces.Service;
using api_zoologico.Repositories.EspeciesAnimales;
using api_zoologico.Repositories.Zoologicos;
using api_zoologico.Service.Zoologico;

namespace api_zoologico;

public static class ConfigServiceCollectionExtensions
{
    public static IServiceCollection AddMyDependecyGroup(this IServiceCollection services)
    {
        services.AddScoped<IEspeciesAnimalesRepository, EspeciesAnimalesRepository>();
        services.AddScoped<IZoologicosRepository, ZoologicosRepository>();
        services.AddScoped<IZoologicosService, ZoologicosService>();

        return services;
    }
}