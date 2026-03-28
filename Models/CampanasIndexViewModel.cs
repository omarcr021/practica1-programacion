namespace practica.Models;

public class CampanasIndexViewModel
{
    public IReadOnlyList<Campana> Campanas { get; init; } = [];
    public IReadOnlyList<string> Categorias { get; init; } = [];
    public IReadOnlyList<string> Estados { get; init; } = [];
    public string? CategoriaSeleccionada { get; init; }
    public string? EstadoSeleccionado { get; init; }
}