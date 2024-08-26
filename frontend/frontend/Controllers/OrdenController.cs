using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using backend.Models;
using frontend.Models;

namespace frontend.Controllers
{
    public class OrdenController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OrdenController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // GET: Orden
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            // Obtener la lista de órdenes desde la API
            var response = await client.GetAsync("https://localhost:7061/api/Orden");
            if (!response.IsSuccessStatusCode)
            {
                return View(new List<Orden>()); // Manejo simple de error
            }

            var ordenes = await response.Content.ReadFromJsonAsync<List<Orden>>();

            return View(ordenes);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest("Invalid order ID");
            }

            var client = _httpClientFactory.CreateClient();

            // Obtener la orden específica desde la API
            var response = await client.GetAsync($"https://localhost:7061/api/Orden/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return NotFound(); // Si no encuentra la orden o hay un error en la API
            }

            var orden = await response.Content.ReadFromJsonAsync<Orden>();

            if (orden == null)
            {
                return NotFound();
            }

            // Chequear si Id_Detalle_Orden es válido antes de hacer la solicitud
            if (orden.Id_Detalle_Orden == null || orden.Id_Detalle_Orden <= 0)
            {
                return NotFound("DetalleOrden ID is not valid.");
            }

            // Obtener el DetalleOrden asociado
            var detalleOrdenResponse = await client.GetAsync($"https://localhost:7061/api/DetalleOrden/{orden.Id_Detalle_Orden}");
            if (!detalleOrdenResponse.IsSuccessStatusCode)
            {
                return NotFound(); // Si no encuentra el detalle de la orden
            }

            var detalleOrden = await detalleOrdenResponse.Content.ReadFromJsonAsync<DetalleOrden>();

            if (detalleOrden == null)
            {
                return NotFound();
            }

            // Asigna el DetalleOrden a la propiedad correspondiente en el modelo Orden
            orden.DetalleOrden = detalleOrden;

            // Devolver la vista con los detalles de la orden y su detalle
            return View(orden);
        }

        // GET: Orden/Create
        public async Task<IActionResult> Create()
        {
            var client = _httpClientFactory.CreateClient();

            // Obtener listas desplegables desde la API
            var chefs = await client.GetFromJsonAsync<List<Chef>>("https://localhost:7061/api/Chef");
            var clientes = await client.GetFromJsonAsync<List<Cliente>>("https://localhost:7061/api/Cliente");
            var empleados = await client.GetFromJsonAsync<List<Empleado>>("https://localhost:7061/api/Empleado");
            var mesas = await client.GetFromJsonAsync<List<Mesa>>("https://localhost:7061/api/Mesa");

            ViewData["Id_Chef"] = new SelectList(chefs, "Id_Chef", "Correo");
            ViewData["Id_Cliente"] = new SelectList(clientes, "Id_Cliente", "Apellido");
            ViewData["Id_Empleado"] = new SelectList(empleados, "Id_Empleado", "Contrasena");
            ViewData["Id_Mesa"] = new SelectList(mesas, "Id_Mesa", "Numero_Mesa");

            return View();
        }

        // POST: Orden/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Orden orden)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();

                // Enviar la nueva orden a la API
                var response = await client.PostAsJsonAsync("https://localhost:7061/api/Orden", orden);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, "Error al crear la orden.");
            }

            return View(orden);
        }

        // GET: Orden/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = _httpClientFactory.CreateClient();

            // Obtener la orden a editar desde la API
            var ordenResponse = await client.GetAsync($"https://localhost:7061/api/Orden/{id}");
            if (!ordenResponse.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var orden = await ordenResponse.Content.ReadFromJsonAsync<Orden>();

            // Obtener listas desplegables desde la API
            var chefs = await client.GetFromJsonAsync<List<Chef>>("https://localhost:7061/api/Chef");
            var clientes = await client.GetFromJsonAsync<List<Cliente>>("https://localhost:7061/api/Cliente");
            var empleados = await client.GetFromJsonAsync<List<Empleado>>("https://localhost:7061/api/Empleado");
            var mesas = await client.GetFromJsonAsync<List<Mesa>>("https://localhost:7061/api/Mesa");

            ViewData["Id_Chef"] = new SelectList(chefs, "Id_Chef", "Correo", orden.Id_Chef);
            ViewData["Id_Cliente"] = new SelectList(clientes, "Id_Cliente", "Apellido", orden.Id_Cliente);
            ViewData["Id_Empleado"] = new SelectList(empleados, "Id_Empleado", "Contrasena", orden.Id_Empleado);
            ViewData["Id_Mesa"] = new SelectList(mesas, "Id_Mesa", "Numero_Mesa", orden.Id_Mesa);

            return View(orden);
        }

        // POST: Orden/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Orden,Fecha,Hora,Numero_Orden,Cantidad_Personas,Cancelado,Id_Empleado,Id_Cliente,Id_Mesa,Id_Chef")] Orden orden)
        {
            if (id != orden.Id_Orden)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();

                try
                {
                    // Enviar la actualización a la API
                    var response = await client.PutAsJsonAsync($"https://localhost:7061/api/Orden/{id}", orden);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    ModelState.AddModelError(string.Empty, "Error al actualizar la orden.");
                }
                catch (HttpRequestException)
                {
                    ModelState.AddModelError(string.Empty, "Error de comunicación con la API.");
                }
            }

            return View(orden);
        }

        [HttpGet]
        public IActionResult CreateCliente()
        {
            // Devuelve la vista para crear un cliente
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCliente([Bind("Nombre,Apellido")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.PostAsJsonAsync("https://localhost:7061/api/Cliente", cliente);

                if (response.IsSuccessStatusCode)
                {
                    var createdCliente = await response.Content.ReadFromJsonAsync<Cliente>();

                    // Devuelve a la vista de Crear Orden, incluyendo el nuevo cliente en la lista desplegable
                    TempData["MensajeExito"] = "Cliente creado con éxito.";
                    TempData["Id_Cliente"] = createdCliente.Id_Cliente; // Guardar el nuevo ID de cliente
                    return RedirectToAction("Create", "Orden");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al crear el cliente.");
                }
            }

            return RedirectToAction("Create", "Orden");
        }

    }
}
