using Microsoft.AspNetCore.Mvc;
using backend.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;
using frontend.Controllers;

public class AccountController : Controller
{
    private readonly BackendDbContext _context;

    public AccountController(BackendDbContext context)
    {
        _context = context;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Lógica de autenticación
            var admin = await _context.Administrador
                .FirstOrDefaultAsync(a => a.Correo == model.Correo && a.Contrasena == model.Contrasena);

            var empleado = await _context.Empleado
                .FirstOrDefaultAsync(e => e.Correo == model.Correo && e.Contrasena == model.Contrasena);

            if (admin != null)
            {
                // Guardar el nombre del administrador en la sesión
                HttpContext.Session.SetString("UserName", admin.Nombre);
                return RedirectToAction("Index", "Home");
            }
            else if (empleado != null)
            {
                // Guardar el nombre del empleado en la sesión
                HttpContext.Session.SetString("UserName", empleado.Nombre);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Correo o contraseña incorrectos");
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (model.TipoUsuario == "Administrador")
            {
                var admin = new Administrador
                {
                    Nombre = model.Nombre,
                    Correo = model.Correo,
                    Contrasena = model.Contrasena,
                    Activo = true
                };

                _context.Administrador.Add(admin);
            }
            else if (model.TipoUsuario == "Empleado")
            {
                var empleado = new Empleado
                {
                    Nombre = model.Nombre,
                    Correo = model.Correo,
                    Contrasena = model.Contrasena,
                    Activo = true
                };

                _context.Empleado.Add(empleado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Login");
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult Profile()
    {
        // Obtener el perfil del usuario autenticado
        return View();
    }

    [HttpGet]
    public IActionResult EditProfile() => View();

    [HttpPost]
    public async Task<IActionResult> EditProfile(EditProfileViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Lógica de actualización del perfil
            await _context.SaveChangesAsync();
            return RedirectToAction("Profile");
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult Logout()
    {
        // Lógica de cierre de sesión
        return RedirectToAction("Login");
    }
}
