namespace api_zoologico.Query;

public class UpdateZoologicoQuery
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public string Ciudad { get; set; }
    public double Tamanio { get; set; }
    public decimal PresupuestoAnual { get; set; }
    public DateTime AnioNacimiento { get; set; }
    public string PaisDeOrigen { get; set; }
    public string Continente { get; set; }
}