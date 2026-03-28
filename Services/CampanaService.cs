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
            Descripcion = "Promocion de televisores, audio y pequenos electrodomesticos."
        },
        new Campana
        {
            Id = 2,
            Nombre = "Hogar Renovado",
            Categoria = "Hogar",
            Estado = "Vigente",
            FechaInicio = new DateOnly(2026, 3, 15),
            FechaFin = new DateOnly(2026, 4, 10),
            DescuentoPct = 18,
            Canal = "Tienda",
            Descripcion = "Campana para menaje, decoracion y organizacion del hogar."
        },
        new Campana
        {
            Id = 3,
            Nombre = "Moda Mid Season",
            Categoria = "Moda",
            Estado = "Proxima",
            FechaInicio = new DateOnly(2026, 4, 12),
            FechaFin = new DateOnly(2026, 4, 30),
            DescuentoPct = 30,
            Canal = "App",
            Descripcion = "Descuentos en colecciones de media temporada para mujer y hombre."
        },
        new Campana
        {
            Id = 4,
            Nombre = "Tech Weekend",
            Categoria = "Tecnologia",
            Estado = "Proxima",
            FechaInicio = new DateOnly(2026, 5, 8),
            FechaFin = new DateOnly(2026, 5, 10),
            DescuentoPct = 22,
            Canal = "Web",
            Descripcion = "Promocion de laptops, smartphones y accesorios tecnologicos."
        },
        new Campana
        {
            Id = 5,
            Nombre = "Liquidacion Verano",
            Categoria = "Moda",
            Estado = "Finalizada",
            FechaInicio = new DateOnly(2026, 1, 10),
            FechaFin = new DateOnly(2026, 2, 2),
            DescuentoPct = 40,
            Canal = "Tienda",
            Descripcion = "Salida de temporada en ropa y calzado de verano."
        },
        new Campana
        {
            Id = 6,
            Nombre = "Casa Inteligente",
            Categoria = "Tecnologia",
            Estado = "Finalizada",
            FechaInicio = new DateOnly(2026, 2, 5),
            FechaFin = new DateOnly(2026, 2, 20),
            DescuentoPct = 15,
            Canal = "App",
            Descripcion = "Ofertas en dispositivos smart home y automatizacion."
        }
    ];

    public IReadOnlyList<Campana> GetAll()
    {
        return Campanas
            .OrderBy(c => c.FechaInicio)
            .ToList();
    }

    public Campana? GetById(int id)
    {
        return Campanas.FirstOrDefault(c => c.Id == id);
    }
}