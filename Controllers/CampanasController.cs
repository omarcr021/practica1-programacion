using Microsoft.AspNetCore.Mvc;
using practica.Models;
using practica.Services;

namespace practica.Controllers;

public class CampanasController : Controller
{
    private readonly CampanaService _campanaService;

    public CampanasController(CampanaService campanaService)
    {
        _campanaService = campanaService;
    }

    [HttpGet("Campanas")]
    public IActionResult Index(string? categoria, string? estado)
    {
        var viewModel = new CampanasIndexViewModel
        {
            Campanas = _campanaService.Listar(categoria, estado),
            Categorias = _campanaService.ObtenerCategorias(),
            Estados = _campanaService.ObtenerEstados(),
            CategoriaSeleccionada = categoria,
            EstadoSeleccionado = estado
        };

        return View(viewModel);
    }

    [HttpGet("Campanas/Detalle/{id:int}")]
    public IActionResult Detalle(int id)
    {
        var campana = _campanaService.ObtenerPorId(id);
        if (campana is null)
        {
            return NotFound();
        }

        return View(campana);
    }
}