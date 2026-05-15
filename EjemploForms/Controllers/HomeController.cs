using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EjemploForms.Models;

namespace EjemploForms.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.Autos = Catalogo.obtenerAutos();
        return View();
    }

    [HttpPost]
    public IActionResult CargarAuto(string patente, string marca, string modelo, int año, string color){
        bool existe = Catalogo.ExisteAuto(patente);
        if(existe){
            ViewBag.Error = "Ese auto ya existe";
        }else{
            Catalogo.agregarAuto(patente, marca, modelo, color, año);
        }

        ViewBag.Autos = Catalogo.obtenerAutos();
        return View("Index");

    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
