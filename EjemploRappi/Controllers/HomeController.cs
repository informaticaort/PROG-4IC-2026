using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EjemploRappi.Models;

namespace EjemploRappi.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    private List<Plato> ObtenerPlatos(){
        return new List<Plato>
        {
            new Plato {Nombre = "Hamburguesa clasica", Precio = 8000, Categoria="Hamburguesas"},
            new Plato {Nombre = "Hamburguesa con cheddar", Precio = 8500, Categoria="Hamburguesas"},
            new Plato {Nombre = "Ensalada rusa", Precio = 6000, Categoria="Ensaladas"}
        };
    }

    public IActionResult Index(string categoria)
    {
        List<Plato> todos = ObtenerPlatos();
        List<Plato> filtrado = new List<Plato>();

        foreach(Plato plato in todos)
        {
            if(categoria == plato.Categoria || categoria == null)
            {
                filtrado.Add(plato);
            }
        }

        ViewBag.Categoria = categoria;
        ViewBag.Platos = filtrado;
        return View();
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
