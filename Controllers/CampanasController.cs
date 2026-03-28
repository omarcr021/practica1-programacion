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
        var campanas = _campanaService.GetAll();
        return View(campanas);
    }

    public IActionResult Details(int id)
    {
        var campana = _campanaService.GetById(id);
        if (campana is null)
        {
            return NotFound();
        }

        return View(campana);
    }
}