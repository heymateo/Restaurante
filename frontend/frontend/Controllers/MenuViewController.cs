using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using frontend.Models;

namespace frontend.Controllers
{
    public class MenuViewController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MenuViewController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // GET: MenuView
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var bebidaResponse = await client.GetAsync("https://localhost:7061/api/Bebida");
            var platilloResponse = await client.GetAsync("https://localhost:7061/api/Platillo");
            var categoriaResponse = await client.GetAsync("https://localhost:7061/api/Categoria");

            if (bebidaResponse.IsSuccessStatusCode && platilloResponse.IsSuccessStatusCode && categoriaResponse.IsSuccessStatusCode)
            {
                var bebidas = await bebidaResponse.Content.ReadFromJsonAsync<List<Bebida>>();
                var platillos = await platilloResponse.Content.ReadFromJsonAsync<List<Platillo>>();
                var categorias = await categoriaResponse.Content.ReadFromJsonAsync<List<Categoria>>();

                // Mapear categorías a platillos
                foreach (var platillo in platillos)
                {
                    platillo.Categoria = categorias.FirstOrDefault(c => c.Id_Categoria == platillo.Id_Categoria);
                }

                // Mapear categorías a bebidas
                foreach (var bebida in bebidas)
                {
                    bebida.Categoria = categorias.FirstOrDefault(c => c.Id_Categoria == bebida.Id_Categoria);
                }

                var viewModel = new MenuViewModel
                {
                    Bebidas = bebidas,
                    Platillos = platillos,
                    Categorias = categorias
                };

                return View(viewModel);
            }
            else
            {
                // Manejar el error
                return View(new MenuViewModel());
            }
        }


    }
}
