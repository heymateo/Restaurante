using frontend.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace frontend.Controllers
{
    public class AdministradorController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdministradorController(IHttpClientFactory httpClientFactory) 
        {
            _httpClientFactory = httpClientFactory;
        }

        // Método para listar administradores
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7061/api/Administrador");

            if (response.IsSuccessStatusCode)
            {
                var administradores = await response.Content.ReadFromJsonAsync<List<AdministradorModel>>();
                return View(administradores);
            }
            else
            {
                // Manejar el error
                return View(new List<AdministradorModel>());
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
        public async Task<IActionResult> Create(AdministradorModel model)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.PostAsJsonAsync("https://localhost:7061/api/Administrador", model);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al crear el administrador.");
                }
            }
            return View(model);
        }

        // Método para mostrar la vista de editar un administrador
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7061/api/Administrador/{id}");

            if (response.IsSuccessStatusCode)
            {
                var administrador = await response.Content.ReadFromJsonAsync<AdministradorModel>();
                return View(administrador);
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
        public async Task<IActionResult> Edit(int id, AdministradorModel model)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.PutAsJsonAsync($"https://localhost:7061/api/Administrador/{id}", model);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al actualizar el administrador.");
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
            var response = await client.GetAsync($"https://localhost:7061/api/Administrador/{id}");

            if (response.IsSuccessStatusCode)
            {
                var administrador = await response.Content.ReadFromJsonAsync<AdministradorModel>();
                if (administrador != null)
                {
                    administrador.Activo = false;
                    var updateResponse = await client.PutAsJsonAsync($"https://localhost:7061/api/Administrador/{id}", administrador);

                    if (updateResponse.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Error al desactivar el administrador.");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Administrador no encontrado.");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error al obtener el administrador.");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
