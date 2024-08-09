using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace frontend.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public EmpleadoController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // Método para listar administradores
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7061/api/Empleado");

            if (response.IsSuccessStatusCode)
            {
                var empleados = await response.Content.ReadFromJsonAsync<List<Empleado>>();
                return View(empleados);
            }
            else
            {
                // Manejar el error
                return View(new List<Empleado>());
            }
        }

        // Método para mostrar la vista de crear nuevo administrador
        public IActionResult Create()
        {
            return View();
        }

        // Método para manejar la creación de nuevo administrador
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Empleado model)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.PostAsJsonAsync("https://localhost:7061/api/Empleado", model);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index","Empleado");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al crear el empleado" +
                        ".");
                }
            }
            return View(model);
        }

        // Método para mostrar la vista de editar un administrador
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7061/api/Empleado/{id}");

            if (response.IsSuccessStatusCode)
            {
                var empleado = await response.Content.ReadFromJsonAsync<Empleado>();
                return View(empleado);
            }
            else
            {
                // Manejar el error
                return RedirectToAction(nameof(Index));
            }
        }

        // Método para manejar la edición de un administrador
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Empleado model)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.PutAsJsonAsync($"https://localhost:7061/api/Empleado/{id}", model);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al actualizar el empleado.");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> DeactivateView()
        {
            return View();
        }

        // Método para desactivar un administrador
        public async Task<IActionResult> Deactivate(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7061/api/Empleado/{id}");

            if (response.IsSuccessStatusCode)
            {
                var empleado = await response.Content.ReadFromJsonAsync<Empleado>();
                if (empleado != null)
                {
                    empleado.Activo = false;
                    var updateResponse = await client.PutAsJsonAsync($"https://localhost:7061/api/Empleado/{id}", empleado);

                    if (updateResponse.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Error al desactivar el empleado.");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Empleado no encontrado.");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error al obtener el empleado.");
            }

            return RedirectToAction(nameof(Index));
        }
    }
    
}


