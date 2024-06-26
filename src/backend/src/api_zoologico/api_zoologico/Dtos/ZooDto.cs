namespace api_zoologico.Dtos;

public class ZooDto
{
    public string Nombre { get; set; }
    public string Ciudad { get; set; }
    public double Tamanio { get; set; }
    public decimal PresupuestoAnual { get; set; }
    public Guid IdAnimal { get; set; }
    public EspecieDto Especie { get; set; }
    public DateTime AnioNacimiento { get; set; }
    public string PaisDeOrigen { get; set; }
    public string Continente { get; set; }
}