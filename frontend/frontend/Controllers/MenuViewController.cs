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
           
            if (bebidaResponse.IsSuccessStatusCode && platilloResponse.IsSuccessStatusCode)
            {
                var bebidas = await bebidaResponse.Content.ReadFromJsonAsync<List<Bebida>>();
                var platillos = await platilloResponse.Content.ReadFromJsonAsync<List<Platillo>>();
                
                var viewModel = new MenuViewModel
                {
                    Bebidas = bebidas,
                    Platillos = platillos
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
