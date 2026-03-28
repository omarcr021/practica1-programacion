namespace practica.Models;

public class CampanasResumenViewModel
{
    public int TotalCampanas { get; init; }
    public int CampanasVigentes { get; init; }
    public int CampanasProximas { get; init; }
    public decimal PromedioDescuento { get; init; }
    public IReadOnlyDictionary<string, int> CantidadPorCanal { get; init; } =
        new Dictionary<string, int>();
}