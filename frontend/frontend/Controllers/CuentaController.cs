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

            // Get the list of accounts
            var response = await client.GetAsync("https://localhost:7061/api/Cuenta");
            if (!response.IsSuccessStatusCode)
            {
                return View(new List<Cuenta>()); // Simple error handling
            }

            var cuentas = await response.Content.ReadFromJsonAsync<List<Cuenta>>();

            // Get a list of client IDs to make an additional call
            var clienteIds = cuentas.Select(c => c.Id_Cliente).Distinct().ToList();
            var clientesResponse = await client.GetAsync("https://localhost:7061/api/Cliente");
            if (!clientesResponse.IsSuccessStatusCode)
            {
                return View(cuentas); // Error handling
            }

            var clientes = await clientesResponse.Content.ReadFromJsonAsync<List<Cliente>>();

            // Associate clients with the accounts
            foreach (var cuenta in cuentas)
            {
                cuenta.Cliente = clientes.FirstOrDefault(c => c.Id_Cliente == cuenta.Id_Cliente);
            }

            // Get a list of order IDs to make an additional call
            var ordenIds = cuentas.Select(c => c.Id_Orden).Distinct().ToList();
            var ordenesResponse = await client.GetAsync("https://localhost:7061/api/Orden");
            if (!ordenesResponse.IsSuccessStatusCode)
            {
                return View(cuentas); // Error handling
            }

            var ordenes = await ordenesResponse.Content.ReadFromJsonAsync<List<Orden>>();

            // Associate orders with the accounts
            foreach (var cuenta in cuentas)
            {
                cuenta.Orden = ordenes.FirstOrDefault(o => o.Id_Orden == cuenta.Id_Orden);
            }

            return View(cuentas);
        }



    }
}
