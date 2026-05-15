using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EjemploMVC4C.Models;

namespace EjemploMVC4C.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private List<Alumno> alumnos = new List<Alumno>
    {
        new Alumno(1, "Juan", 16, "4IC", "juan@ort.edu.ar"),
        new Alumno(2, "Sofi", 17, "5IA", "sofi@ort.edu.ar"),
        new Alumno(3, "Lucas", 14, "2M", "lucas@ort.edu.ar")
    };

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.Alumnos = alumnos;
        return View();
    }

    public IActionResult DetalleAlumno(int id)
    {
        Alumno alumno = BuscarAlumno(id);
        if(alumno != null)
        {
            ViewBag.Alumno = alumno;
            return View();
        }
        else
        {
            return RedirectToAction("Index");
        }
    }

    public Alumno BuscarAlumno(int id)
    {
        int i = 0;

        while(i<alumnos.Count && alumnos[i].ObtenerId()!= id)
            i++;

        if(i == alumnos.Count)
            return null;
        else
            return alumnos[i];
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
