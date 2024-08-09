using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace frontend.Controllers
{
    public class BebidaController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BebidaController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // GET: Bebida
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7061/api/Bebida");

            if (response.IsSuccessStatusCode)
            {
                var bebida = await response.Content.ReadFromJsonAsync<List<Bebida>>();
                return View(bebida);
            }
            else
            {
                // Manejar el error
                return View(new List<Bebida>());
            }
        }

        // GET: Bebida/Create
        public async Task<IActionResult> Create()
        {
            var model = new Bebida();

            // Llama a la API o servicio para obtener las categorías
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7061/api/Categoria"); // Ajusta la URL según tu API

            if (response.IsSuccessStatusCode)
            {
                model.ListaCategorias = await response.Content.ReadFromJsonAsync<List<Categoria>>();
            }
            else
            {
                model.ListaCategorias = new List<Categoria>(); // Manejo del caso en que no se obtengan categorías
            }

            return View(model);
        }

        // POST: Bebida/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Bebida model)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.PostAsJsonAsync("https://localhost:7061/api/Bebida", model);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "MenuView");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al crear la bebida.");
                }
            }
            return View(model);
        }

        // GET: Bebida/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var client = _httpClientFactory.CreateClient();
            var bebidaResponse = await client.GetAsync($"https://localhost:7061/api/Bebida/{id}");
            var categoriaResponse = await client.GetAsync("https://localhost:7061/api/Categoria");

            if (bebidaResponse.IsSuccessStatusCode && categoriaResponse.IsSuccessStatusCode)
            {
                var bebida = await bebidaResponse.Content.ReadFromJsonAsync<Bebida>();
                var categorias = await categoriaResponse.Content.ReadFromJsonAsync<List<Categoria>>();

                bebida.ListaCategorias = categorias;

                return View(bebida);
            }
            else
            {
                // Manejar el error
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Bebida/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Bebida model)
        {

            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.PutAsJsonAsync($"https://localhost:7061/api/Bebida/{id}", model);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al actualizar la bebida.");
                }
            }
            return View(model);
        }

    }
}
