using practica.Models;

namespace practica.Services;

public class CampanaService
{
    private static readonly List<Campana> Campanas =
    [
        new Campana
        {
            Id = 1,
            Nombre = "Electro Flash Week",
            Categoria = "Electro",
            Estado = "Vigente",
            FechaInicio = new DateOnly(2026, 3, 20),
            FechaFin = new DateOnly(2026, 4, 5),
            DescuentoPct = 25,
            Canal = "Web",
            Descripcion = "Promocion de electrodomesticos y audio."
        },
        new Campana
        {
            Id = 2,
            Nombre = "Hogar Renovado",
            Categoria = "Hogar",
            Estado = "Proxima",
            FechaInicio = new DateOnly(2026, 4, 12),
            FechaFin = new DateOnly(2026, 4, 28),
            DescuentoPct = 18,
            Canal = "Tienda",
            Descripcion = "Campana de menaje y organizacion del hogar."
        },
        new Campana
        {
            Id = 3,
            Nombre = "Moda Cierre de Temporada",
            Categoria = "Moda",
            Estado = "Finalizada",
            FechaInicio = new DateOnly(2026, 1, 10),
            FechaFin = new DateOnly(2026, 2, 2),
            DescuentoPct = 40,
            Canal = "App",
            Descripcion = "Liquidacion de prendas y calzado seleccionados."
        },
        new Campana
        {
            Id = 4,
            Nombre = "Tech Weekend",
            Categoria = "Tecnologia",
            Estado = "Vigente",
            FechaInicio = new DateOnly(2026, 3, 24),
            FechaFin = new DateOnly(2026, 3, 31),
            DescuentoPct = 22,
            Canal = "Web",
            Descripcion = "Promocion de laptops y accesorios tecnologicos."
        }
    ];

    public IReadOnlyList<Campana> Listar()
    {
        return Campanas.OrderBy(c => c.FechaInicio).ToList();
    }

    public Campana? ObtenerPorId(int id)
    {
        return Campanas.FirstOrDefault(c => c.Id == id);
    }
}