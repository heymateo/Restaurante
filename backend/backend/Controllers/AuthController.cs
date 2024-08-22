using Microsoft.AspNetCore.Mvc;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly BackendDbContext _context;

        public AccountController(BackendDbContext context)
        {
            _context = context;
        }

        // POST: api/Account/Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Email and password are required.");
            }

            // Check if user is an Admin
            var admin = await _context.Administrador
                .FirstOrDefaultAsync(a => a.Correo == request.Email && a.Contrasena == request.Password && a.Activo);

            if (admin != null)
            {
                return Ok(new LoginResponse
                {
                    UserId = admin.Id_Administrador,
                    UserName = admin.Nombre,
                    Role = "Administrador"
                });
            }

            // Check if user is an Employee
            var employee = await _context.Empleado
                .FirstOrDefaultAsync(e => e.Correo == request.Email && e.Contrasena == request.Password && e.Activo);

            if (employee != null)
            {
                return Ok(new LoginResponse
                {
                    UserId = employee.Id_Empleado,
                    UserName = employee.Nombre,
                    Role = "Empleado"
                });
            }

            // If no match found
            return Unauthorized("Invalid credentials or inactive user.");
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
    }
}
