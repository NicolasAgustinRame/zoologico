using System.ComponentModel.DataAnnotations.Schema;

namespace api_zoologico.Models;
[Table("zoologicos")]
public class Zoologicos
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public string Ciudad { get; set; }
    public string Pais { get; set; }
    public double Tamanio { get; set; }
    public decimal PresupuestoAnual { get; set; }
    public Guid IdAnimal { get; set; }
    public Guid IdEspecie { get; set; }
    [ForeignKey("IdEspecie")] public EspeciesAnimales Especie { get; set; }
    public string Sexo { get; set; }
    public DateTime AnioNacimiento { get; set; }
    public string PaisDeOrigen { get; set; }
    public string Continente { get; set; }
}