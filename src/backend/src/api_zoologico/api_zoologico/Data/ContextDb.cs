using api_zoologico.Models;
using Microsoft.EntityFrameworkCore;

namespace api_zoologico.Data;

public class ContextDb : DbContext
{
    public ContextDb(DbContextOptions<ContextDb> options) : base(options)
    {
        
    }

    public DbSet<EspeciesAnimales> EspeciesAnimales  { get; set; }
    public DbSet<Zoologicos> Zoologicos { get; set; }
}