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

        // GET: Platillo/Create
        public async Task<IActionResult> Create()
        {
            var model = new Platillo();

            // Llama a la API o servicio para obtener las categorías
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7061/api/Categoria"); // Ajusta la URL según tu API

            if (response.IsSuccessStatusCode)
            {
                //model.ListaCategorias = await response.Content.ReadFromJsonAsync<List<Categoria>>();
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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient();

            // Obtener el platillo para la edición
            var platilloResponse = await client.GetAsync($"https://localhost:7061/api/Platillo/{id}");
            if (!platilloResponse.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var platillo = await platilloResponse.Content.ReadFromJsonAsync<Platillo>();

            // Obtener todas las categorías para la vista
            var categoriaResponse = await client.GetAsync("https://localhost:7061/api/Categoria");
            if (!categoriaResponse.IsSuccessStatusCode)
            {
                return View(platillo); // Puedes manejar el error de la categoría aquí
            }

            var categorias = await categoriaResponse.Content.ReadFromJsonAsync<List<Categoria>>();

            var model = new PlatilloViewModel
            {
                Id_Platillo = platillo.Id_Platillo,
                Nombre = platillo.Nombre,
                Descripcion = platillo.Descripcion,
                Precio = platillo.Precio,
                Id_Categoria = platillo.Id_Categoria,
                Categorias = categorias // Asignar la lista de categorías a la vista
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Platillo,Nombre,Descripcion,Precio,Id_Categoria")] PlatilloViewModel model)
        {
            ModelState.Remove("Platillo");
            ModelState.Remove("Categorias");

            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();

                // Actualizar el platillo con la categoría seleccionada
                var updatedPlatillo = new Platillo
                {
                    Id_Platillo = model.Id_Platillo,
                    Nombre = model.Nombre,
                    Descripcion = model.Descripcion,
                    Precio = model.Precio,
                    Id_Categoria = model.Id_Categoria // La categoría seleccionada
                };

                var response = await client.PutAsJsonAsync($"https://localhost:7061/api/Platillo/{id}", updatedPlatillo);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "MenuView");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al actualizar el platillo.");
                }
            }


            return View(model);
        }

    }
}
