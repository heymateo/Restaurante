using backend.Models;
using System.Security.Claims;

namespace backend.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<Administrador> AuthenticateAdministradorAsync(string email, string password);
        Task<Empleado> AuthenticateEmpleadoAsync(string email, string password);
    }
}
