using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tp05.Models;

namespace tp05.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]

    public IActionResult Login(string username, string password)
    {
        BD BD = new BD();
        Usuario usuario = BD.ValidarUsuario(username, password);

        if (usuario == null)
        {
            ViewBag.Error = "Usuario o contraseña incorrectos";
            return View();
        }

        HttpContext.Session.SetString("Username", usuario.Username);
        HttpContext.Session.SetString("Nombre", usuario.Nombre);
        HttpContext.Session.SetString("Apellido", usuario.Apellido);
        HttpContext.Session.SetString("TipoUsuario", usuario.TipoUsuario);

        return RedirectToAction("Bienvenida");
    }

    [HttpPost]

    public IActionResult CrearCuenta(string username, string nombre, string apellido, string password, string TipoUsuario)
    {
        BD BD = new BD();
        Usuario usuario = BD.ValidarUsername(username);

        if (usuario != null)
        {
            ViewBag.Error = "Error! ya existe un usuario con ese nombre de usuario";
            return View();
        }

        BD.NuevoUsuario(username, nombre, apellido, password, TipoUsuario);

        HttpContext.Session.SetString("Username", username);
        HttpContext.Session.SetString("Nombre", nombre);
        HttpContext.Session.SetString("Apellido", apellido);
        HttpContext.Session.SetString("TipoUsuario", TipoUsuario);

        return RedirectToAction("Bienvenida");
    }

    [HttpPost]

    public IActionResult LogOut()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    public IActionResult CrearCuentaHtml()
    {
        return View("CrearCuenta");
    }

    public IActionResult LoginHtml()
    {
        return View("Login");
    }

    [HttpGet]

    public IActionResult Bienvenida()
    {
        string username = HttpContext.Session.GetString("Username");

        //si no hay un usuario logueado en la sesion, redirigir al login
        if (string.IsNullOrEmpty(username))
        {
            return RedirectToAction("LoginHtml"); 
        }

        ViewBag.Nombre = HttpContext.Session.GetString("Nombre");
        ViewBag.Apellido = HttpContext.Session.GetString("Apellido");
        ViewBag.TipoUsuario = HttpContext.Session.GetString("TipoUsuario");

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
