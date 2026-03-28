using practica.Models;

namespace practica.Services;

public class CampanaService
{
    private static readonly List<Campana> Campanas =
    [
        new Campana
        {
            Id = 1,
            Nombre = "CyberWow Electro",
            Categoria = "Electro",
            Estado = "Vigente",
            FechaInicio = new DateOnly(2026, 3, 30),
            FechaFin = new DateOnly(2026, 4, 15),
            DescuentoPct = 35,
            Canal = "Web",
            Descripcion = "Promocion en electrodomesticos y audio durante la campana digital."
        },
        new Campana
        {
            Id = 2,
            Nombre = "Renueva tu Hogar",
            Categoria = "Hogar",
            Estado = "Vigente",
            FechaInicio = new DateOnly(2026, 3, 25),
            FechaFin = new DateOnly(2026, 4, 1),
            DescuentoPct = 25,
            Canal = "Tienda",
            Descripcion = "Promociones en menaje, decoracion y organizacion del hogar."
        },
        new Campana
        {
            Id = 3,
            Nombre = "Fashion Week Lima",
            Categoria = "Moda",
            Estado = "Proxima",
            FechaInicio = new DateOnly(2026, 4, 4),
            FechaFin = new DateOnly(2026, 4, 10),
            DescuentoPct = 40,
            Canal = "App",
            Descripcion = "Campana de temporada para colecciones de moda urbana y casual."
        },
        new Campana
        {
            Id = 4,
            Nombre = "Tech Days",
            Categoria = "Tecnologia",
            Estado = "Proxima",
            FechaInicio = new DateOnly(2026, 5, 1),
            FechaFin = new DateOnly(2026, 5, 3),
            DescuentoPct = 35,
            Canal = "Web",
            Descripcion = "Ofertas por tiempo limitado en laptops, celulares y accesorios."
        },
        new Campana
        {
            Id = 5,
            Nombre = "Liquidacion Verano",
            Categoria = "Moda",
            Estado = "Finalizada",
            FechaInicio = new DateOnly(2026, 1, 10),
            FechaFin = new DateOnly(2026, 2, 10),
            DescuentoPct = 50,
            Canal = "Tienda",
            Descripcion = "Salida de stock de verano con promociones de alto impacto."
        },
        new Campana
        {
            Id = 6,
            Nombre = "Electro Fiestas Patrias",
            Categoria = "Electro",
            Estado = "Finalizada",
            FechaInicio = new DateOnly(2026, 7, 1),
            FechaFin = new DateOnly(2026, 7, 15),
            DescuentoPct = 20,
            Canal = "Web",
            Descripcion = "Campana de medio ano para linea blanca y pequenos electrodomesticos."
        }
    ];

    public IReadOnlyList<Campana> Listar(string? categoria, string? estado)
    {
        var query = Campanas.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(categoria))
        {
            query = query.Where(c => string.Equals(c.Categoria, categoria, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(estado))
        {
            query = query.Where(c => string.Equals(c.Estado, estado, StringComparison.OrdinalIgnoreCase));
        }

        return query.OrderBy(c => c.Nombre).ToList();
    }

    public IReadOnlyList<string> ObtenerCategorias()
    {
        return Campanas.Select(c => c.Categoria)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(c => c)
            .ToList();
    }

    public IReadOnlyList<string> ObtenerEstados()
    {
        return Campanas.Select(c => c.Estado)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(e => e)
            .ToList();
    }

    public Campana? ObtenerPorId(int id)
    {
        return Campanas.FirstOrDefault(c => c.Id == id);
    }

    public CampanasResumenViewModel ObtenerResumen()
    {
        var total = Campanas.Count;
        return new CampanasResumenViewModel
        {
            TotalCampanas = total,
            CampanasVigentes = Campanas.Count(c => c.Estado.Equals("Vigente", StringComparison.OrdinalIgnoreCase)),
            CampanasProximas = Campanas.Count(c => c.Estado.Equals("Proxima", StringComparison.OrdinalIgnoreCase)),
            PromedioDescuento = total == 0 ? 0 : Campanas.Average(c => c.DescuentoPct),
            CantidadPorCanal = Campanas
                .GroupBy(c => c.Canal)
                .OrderBy(g => g.Key)
                .ToDictionary(g => g.Key, g => g.Count())
        };
    }
}