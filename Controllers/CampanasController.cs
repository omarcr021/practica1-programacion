using Microsoft.AspNetCore.Mvc;
using practica.Services;

namespace practica.Controllers;

public class CampanasController : Controller
{
    private readonly CampanaService _campanaService;

    public CampanasController(CampanaService campanaService)
    {
        _campanaService = campanaService;
    }

    public IActionResult Index()
    {
        var campanas = _campanaService.Listar();
        return View(campanas);
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