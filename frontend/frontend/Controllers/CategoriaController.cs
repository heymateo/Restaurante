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
    public class CategoriaController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoriaController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // GET: Categoria
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7061/api/Categoria");

            if (response.IsSuccessStatusCode)
            {
                var categoria = await response.Content.ReadFromJsonAsync<List<Categoria>>();
                return View(categoria);
            }
            else
            {
                // Manejar el error
                return View(new List<Categoria>());
            }
        }

        // GET: Categoria/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Categoria model)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.PostAsJsonAsync("https://localhost:7061/api/Categoria", model);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al crear la categoria.");
                }
            }
            return View(model);
        }

        // GET: Categoria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7061/api/Categoria/{id}");

            if (response.IsSuccessStatusCode)
            {
                var categoria = await response.Content.ReadFromJsonAsync<Categoria>();
                return View(categoria);
            }
            else
            {
                // Manejar el error
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Categoria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Categoria model)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.PutAsJsonAsync($"https://localhost:7061/api/Categoria/{id}", model);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al actualizar la categoria.");
                }
            }
            return View(model);
        }
    }
}
