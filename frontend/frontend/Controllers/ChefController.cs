using backend.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace frontend.Controllers
{
    public class ChefController : Controller
    {
        private readonly FrontendDbContext _context;

        private readonly IHttpClientFactory _httpClientFactory;
        public ChefController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // GET: Chef
        // Método para mostrar la vista de crear nuevo chef
        public IActionResult Create()
        {
            return View();
        }

        // Método para listar chef
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7061/api/Chef");

            if (response.IsSuccessStatusCode)
            {
                var chefs = await response.Content.ReadFromJsonAsync<List<ChefModel>>();
                return View(chefs);
            }
            else
            {
                // Manejar el error
                return View(new List<ChefModel>());
            }
        }
        // Método para manejar la creación de nuevo chef
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ChefModel model)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.PostAsJsonAsync("https://localhost:7061/api/Chef", model);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al crear el Chef.");
                }
            }
            return View(model);
        }

        // Método para mostrar la vista de editar un Chef
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7061/api/Chef/{id}");

            if (response.IsSuccessStatusCode)
            {
                var Chef = await response.Content.ReadFromJsonAsync<ChefModel>();
                return View(Chef);
            }
            else
            {
                // Manejar el error
                return RedirectToAction(nameof(Index));
            }
        }

        // Método para manejar la edición de un Chef
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ChefModel model)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.PutAsJsonAsync($"https://localhost:7061/api/Chef/{id}", model);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al actualizar el Chef.");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> DeactivateView()
        {
            return View();
        }

        // Método para desactivar un Chef
        public async Task<IActionResult> Deactivate(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7061/api/Chef/{id}");

            if (response.IsSuccessStatusCode)
            {
                var Chef = await response.Content.ReadFromJsonAsync<ChefModel>();
                if (Chef != null)
                {
                    Chef.Activo = false;
                    var updateResponse = await client.PutAsJsonAsync($"https://localhost:7061/api/Chef/{id}", Chef);

                    if (updateResponse.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Error al desactivar el Chef.");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Chef no encontrado.");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error al obtener el Chef.");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
