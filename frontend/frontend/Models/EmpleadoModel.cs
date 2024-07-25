using System.ComponentModel.DataAnnotations;

namespace frontend.Models
{
    public class EmpleadoModel
    {
        [Key]
        public int Id_Empleado { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public bool Activo { get; set; }
    }
}
