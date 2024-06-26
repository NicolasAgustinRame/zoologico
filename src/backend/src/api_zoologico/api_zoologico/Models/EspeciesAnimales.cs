using System.ComponentModel.DataAnnotations.Schema;

namespace api_zoologico.Models;
[Table("especies_animales")]
public class EspeciesAnimales
{
    public Guid Id { get; set; }
    public string NombreCientifico { get; set; }
    public string NombreVulgar { get; set; }
    public string Familia { get; set; }
    public bool PeligroExtincion { get; set; }
}