using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using frontend.Models;
using System.Net.Http;
using backend.Models;

namespace frontend.Controllers
{
    public class PlatilloController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PlatilloController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // GET: Platillo
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7061/api/Platillo");

            if (response.IsSuccessStatusCode)
            {
                var platillo = await response.Content.ReadFromJsonAsync<List<Platillo>>();
                return View(platillo);
            }
            else
            {
                // Manejar el error
                return View(new List<Platillo>());
            }
        }

        // GET: Platillo/Create
        public async Task<IActionResult> Create()
        {
            var model = new Platillo();

            // Llama a la API o servicio para obtener las categorías
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7061/api/Categoria"); // Ajusta la URL según tu API

            if (response.IsSuccessStatusCode)
            {
                model.Categoria = await response.Content.ReadFromJsonAsync<Categoria>();
            }
            else
            {
                model.Categoria = new Categoria(); // Manejo del caso en que no se obtengan categorías
            }

            return View(model);
        }



        // POST: Platillo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Platillo model)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.PostAsJsonAsync("https://localhost:7061/api/Platillo", model);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "MenuView");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al crear el platillo.");
                }
            }
            return View(model);
        }

        // GET: Platillo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var client = _httpClientFactory.CreateClient();
            var platilloResponse = await client.GetAsync($"https://localhost:7061/api/Platillo/{id}");
            var categoriaResponse = await client.GetAsync("https://localhost:7061/api/Categoria");

            if (platilloResponse.IsSuccessStatusCode && categoriaResponse.IsSuccessStatusCode)
            {
                var platillo = await platilloResponse.Content.ReadFromJsonAsync<Platillo>();
                var categorias = await categoriaResponse.Content.ReadFromJsonAsync<List<Categoria>>();

                platillo.ListaCategorias = categorias;

                return View(platillo);
            }
            else
            {
                // Manejar el error
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Platillo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, Platillo model)
{
    if (ModelState.IsValid)
    {
        var client = _httpClientFactory.CreateClient();

        // Actualizar la categoría del platillo
        var categoriaResponse = await client.GetAsync($"https://localhost:7061/api/Categoria/{model.Id_Categoria}");
        if (categoriaResponse.IsSuccessStatusCode)
        {
            var categoria = await categoriaResponse.Content.ReadFromJsonAsync<List<Categoria>>();
            model.ListaCategorias = categoria;
                    
            // Actualizar el platillo con la categoría
            var response = await client.PutAsJsonAsync($"https://localhost:7061/api/Platillo/{id}", model);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "MenuView");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error al actualizar el platillo.");
            }
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Error al obtener la categoría.");
        }
    }
    return View(model);
}


    }
}
