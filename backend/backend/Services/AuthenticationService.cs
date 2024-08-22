using backend.Models;
using backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace backend.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly BackendDbContext _context;

        public AuthenticationService(BackendDbContext context)
        {
            _context = context;
        }

        public async Task<Administrador> AuthenticateAdministradorAsync(string email, string password)
        {
            // Buscar un administrador con el email y la contraseña proporcionados
            return await _context.Administrador
                .FirstOrDefaultAsync(a => a.Correo == email && a.Contrasena == password && a.Activo);
        }

        public async Task<Empleado> AuthenticateEmpleadoAsync(string email, string password)
        {
            // Buscar un empleado con el email y la contraseña proporcionados
            return await _context.Empleado
                .FirstOrDefaultAsync(e => e.Correo == email && e.Contrasena == password && e.Activo);
        }
    }
}
