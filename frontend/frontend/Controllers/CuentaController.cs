using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using frontend.Models;

namespace frontend.Controllers
{
    public class CuentaController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CuentaController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // Método para listar administradores
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7061/api/Cuenta");

            if (response.IsSuccessStatusCode)
            {
                var administradores = await response.Content.ReadFromJsonAsync<List<CuentaModel>>();
                return View(administradores);
            }
            else
            {
                // Manejar el error
                return View(new List<CuentaModel>());
            }
        }

        
    }
}
